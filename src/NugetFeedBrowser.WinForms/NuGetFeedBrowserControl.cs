// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using NugetFeedBrowser.Shared;

namespace NugetFeedBrowser
{
    public partial class NuGetFeedBrowserControl : UserControl
    {
        public NuGetFeedBrowserControl()
        {
            InitializeComponent();
        }

        public void BindFeeds(IReadOnlyList<NugetFeedDefinition>? nugetFeedDefinitions)
        {
            listView1.BeginUpdate();
            listView1.Clear();
            listView1.Groups.Clear();

            if (nugetFeedDefinitions is null)
            {
                listView1.EndUpdate();
                return;
            }

            foreach (NugetFeedDefinition nugetFeedDefinition in nugetFeedDefinitions.OrderBy(d => d.Name))
            {
                ListViewGroup listViewGroup = new(nugetFeedDefinition.Name)
                {
                    CollapsedState = ListViewGroupCollapsedState.Expanded
                };
                listView1.Groups.Add(listViewGroup);

                ListViewItem empty = new()
                {
                    Group = listViewGroup,
                };
                listView1.Items.Add(empty);
            }

            listView1.EndUpdate();
        }
    }
}
