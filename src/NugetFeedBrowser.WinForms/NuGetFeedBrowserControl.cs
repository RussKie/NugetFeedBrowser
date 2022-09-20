// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using NugetFeedBrowser.Shared;
using NugetFeedBrowser.Shared.Descriptors;

namespace NugetFeedBrowser
{
    public partial class NuGetFeedBrowserControl : UserControl
    {
        private ListViewItem? _hoveredItem;
        private Brush _hoverColorBrush = new SolidBrush(SystemColors.InactiveCaption);
        private readonly Font _primaryFont;
        private readonly Font _secondaryFont;

        public NuGetFeedBrowserControl()
        {
            InitializeComponent();

            _primaryFont = new Font(Font, FontStyle.Bold);
            _secondaryFont = Font;
        }

        private ListViewItem? HoveredItem
        {
            get => _hoveredItem;
            set
            {
                if (value == _hoveredItem)
                {
                    return;
                }

                if (_hoveredItem is not null)
                {
                    // The previously hovered item may be already removed from the view, example:
                    // user locates mouse pointer over an item and triggers data refresh by pressing F5
                    if (lvSearchResults.Items.Contains(_hoveredItem))
                    {
                        lvSearchResults.Invalidate(lvSearchResults.GetItemRect(_hoveredItem.Index));
                    }
                }

                if (value is not null)
                {
                    lvSearchResults.Invalidate(lvSearchResults.GetItemRect(value.Index));
                }

                _hoveredItem = value;
            }
        }

        public void BindFeeds(IReadOnlyList<NugetFeedDefinition>? nugetFeedDefinitions)
        {
            lvSearchResults.BeginUpdate();
            lvSearchResults.Clear();
            lvSearchResults.Groups.Clear();

            if (nugetFeedDefinitions is null)
            {
                lvSearchResults.EndUpdate();
                return;
            }

            foreach (NugetFeedDefinition feedDefinition in nugetFeedDefinitions.OrderBy(d => d.Name))
            {
                string name = feedDefinition.IsSupported ? feedDefinition.Name : $"{feedDefinition.Name} (not supported)";
                ListViewGroup group = new(name)
                {
                    CollapsedState = feedDefinition.IsSupported ? ListViewGroupCollapsedState.Expanded : ListViewGroupCollapsedState.Collapsed,
                    Tag = feedDefinition
                };
                lvSearchResults.Groups.Add(group);
            }

            Reset();

            lvSearchResults.EndUpdate();
        }

        private void Reset()
        {
            lvSearchResults.BeginUpdate();
            lvSearchResults.Clear();

            foreach (ListViewGroup group in lvSearchResults.Groups)
            {
                if (group.Tag is not NugetFeedDefinition feedDefinition)
                {
                    continue;
                }

                if (feedDefinition.IsSupported)
                {
                    group.Subtitle = "0 packages";
                }

                ListViewItem empty = new()
                {
                    Group = group,
                };
                lvSearchResults.Items.Add(empty);

                group.CollapsedState = ListViewGroupCollapsedState.Collapsed;
            }

            lvSearchResults.EndUpdate();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Reset();

            if (string.IsNullOrWhiteSpace(txtNuGetPackageName.Text))
            {
                return;
            }

            List<Task> tasks = new();
            NuGetSearch s = new();
            foreach (ListViewGroup group in lvSearchResults.Groups)
            {
                if (group.Tag is not NugetFeedDefinition feedDefinition)
                {
                    continue;
                }

                tasks.Add(DisplaySearchResultsAsync(feedDefinition, txtNuGetPackageName.Text, group));
            }

            lvSearchResults.BeginUpdate();
            await Task.WhenAll(tasks);
            lvSearchResults.EndUpdate();

            return;

            Task DisplaySearchResultsAsync(NugetFeedDefinition nugetFeed, string filter, ListViewGroup group)
            {
                return Task.Run(async () =>
                {
                    IReadOnlyList<PackageDataDescriptor> results = await s.FindPackageAsync(nugetFeed, txtNuGetPackageName.Text);

                    lvSearchResults.Invoke(() =>
                    {
                        if (results.Count == 0)
                        {
                            group.Subtitle = "0 packages";
                            group.CollapsedState = ListViewGroupCollapsedState.Collapsed;
                            return;
                        }

                        group.Subtitle = $"{results.Count} packages";
                        group.CollapsedState = ListViewGroupCollapsedState.Expanded;
                        lvSearchResults.Items.Remove(group.Items[0]);

                        foreach (PackageDataDescriptor packageData in results)
                        {
                            ListViewItem package = new(packageData.Id)
                            {
                                Group = group,
                                Tag = packageData,
                                ToolTipText = packageData.Id
                            };
                            package.SubItems.Add(packageData.Version);
                            lvSearchResults.Items.Add(package);
                        }
                    });
                });
            }

        }

        private void lvSearchResults_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Tag is not PackageDataDescriptor packageData)
            {
                e.DrawDefault = true;
                return;
            }

            float spacing1 = 1f;
            float spacing2 = 2f;
            float spacing4 = 4f;
            float spacing6 = 6f;
            int imageWidth = 48;

            float textOffset = spacing2 + imageWidth + spacing2;
            int textWidth = e.Bounds.Width - (int)textOffset;

            if (e.Item == HoveredItem || e.Item.Selected)
            {
                e.Graphics.FillRectangle(_hoverColorBrush, e.Bounds);
            }
            else
            {
                e.DrawBackground();
            }

            PointF pointImage = new(e.Bounds.Left + spacing4, e.Bounds.Top + (spacing2 * 4));

            // render icon
            Image temp;
            if (packageData.Icon is null)
            {
                temp = global::NugetFeedBrowser.Properties.Resources.nuget48;
            }
            else
            {
                temp = new Bitmap(packageData.Icon, imageWidth, imageWidth);
            }
            e.Graphics.DrawImage(temp, pointImage);

            // render name
            PointF textPadding = new(e.Bounds.Left + spacing4, e.Bounds.Top + spacing6);
            PointF pointPath = new(textPadding.X + textOffset, textPadding.Y);
            var pathBounds = DrawText(e.Graphics, e.Item.Text, _primaryFont, SystemBrushes.ControlText, textWidth, pointPath, spacing4 * 2);

            // render version
            PointF pointBranch = new(pointPath.X, pointPath.Y + pathBounds.Height + spacing1);
            _ = DrawText(e.Graphics, e.Item.SubItems[1].Text, _secondaryFont, SystemBrushes.InfoText, textWidth, pointBranch, spacing4 * 2);

            RectangleF DrawText(Graphics g, string text, Font font, Brush brush, int maxTextWidth, PointF location, float spacing)
            {
                var textBounds = TextRenderer.MeasureText(text, font);
                var minWidth = Math.Min(textBounds.Width + spacing, maxTextWidth);
                RectangleF bounds = new(location, new SizeF(minWidth, textBounds.Height)); // StringFormatFlags.LineLimit | StringFormatFlags.NoWrap, 1003
                StringFormat sf = new(StringFormatFlags.NoWrap) { Trimming = StringTrimming.EllipsisWord };
                g.DrawString(text, font, brush, bounds, sf);

                return bounds;
            }
        }

        private void lvSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lvSearchResults.GetItemAt(e.X, e.Y);
            if (item is null || item.Tag is not PackageDataDescriptor packageData)
            {
                return;
            }

            if (packageData.WebGalleryUri is null)
            {
                Debug.Fail("WebGalleryUri is null");
            }

            string url = string.Format(packageData.WebGalleryUri, packageData.Id, packageData.Version);
            using Process process = new()
            {
                EnableRaisingEvents = false,
                StartInfo = { FileName = url, UseShellExecute = true },
            };
            process.Start();
        }

        private void lvSearchResults_MouseLeave(object sender, EventArgs e)
        {
            HoveredItem = null;
        }

        private void lvSearchResults_MouseMove(object sender, MouseEventArgs e)
        {
            HoveredItem = lvSearchResults.GetItemAt(e.X, e.Y);
        }
    }
}
