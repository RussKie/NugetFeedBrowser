// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using NugetFeedBrowser.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NugetFeedBrowser
{
    public partial class MainForm : Form
    {
        private static readonly NugetConfigParser s_nugetConfigParser = new();
        private readonly ImageList _imageList = new ImageList();
        private readonly WaitSpinner _waitSpinner;
        private bool _operationInProgress;

        public MainForm()
        {
            InitializeComponent();

            _imageList.Images.Add(new Bitmap(1, 1)); // default
            //_imageList.Images.Add(Properties.Resources.arrow_join); // target
            //_imageList.Images.Add(Properties.Resources.arrow_split); // source
            //_imageList.Images.Add(Properties.Resources.branch_document); // branch
            //_imageList.Images.Add(Properties.Resources.block); // channel

            _waitSpinner = new WaitSpinner
            {
                BackColor = SystemColors.Window,
                //Visible = false,
                Size = new Size(50, 50) // DpiUtil.Scale(new Size(50, 50))
            };


            //var parser = new NugetConfigParser(@"D:\Development\dotnet-winforms\NuGet.config");
            //parser.LoadAsync().GetAwaiter().GetResult();


            Text = Application.ProductName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostControl">The control to have the "loading" overlay for.</param>
        /// <param name="asyncMethod">
        ///  A method that does heavy-lifting work.
        ///  This method is run on a background thread.
        /// </param>
        /// <param name="onCompleteMethod">
        ///  A method to execute once the <paramref name="asyncMethod"/> has completed.
        ///  This method is run on the UI thread.
        /// </param>
        /// <returns>An awaitable.</returns>
        private async Task InvokeAsync(Control hostControl, Func<Task> asyncMethod, Action? onCompleteMethod = null)
        {
            if (!_operationInProgress)
            {
                Debug.Assert(!_operationInProgress);
            }

            Debug.Assert(!hostControl.InvokeRequired);
            BeginUIOperation();

            await Task.Run(async () =>
            {
                try
                {
                    await asyncMethod();
                }
                finally
                {
                    hostControl.Invoke((Action)(() =>
                    {
                        onCompleteMethod?.Invoke();
                        EndUIOperation();
                    }));
                }
            });

            void BeginUIOperation()
            {
                _operationInProgress = true;
                tsbtnRefresh.Enabled = false;
                tabControl.Enabled = false;
                ShowSpinner(visible: true, hostControl);
            }

            void EndUIOperation()
            {
                _operationInProgress = false;
                ShowSpinner(visible: false);
                tabControl.Enabled = true;
                tsbtnRefresh.Enabled = true;
            }

            void ShowSpinner(bool visible, Control? hostControl = null)
            {
                if (!visible)
                {
                    _waitSpinner.Host = null;
                    Controls.Remove(_waitSpinner);
                    return;
                }

                Controls.Add(_waitSpinner);
                _waitSpinner.Host = hostControl ?? this;
                _waitSpinner.BringToFront();
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            //await BindSubscriptionsAsync(forceReload: true);
        }

        private async void btnNuGetConfigBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                CheckFileExists = true,
                InitialDirectory = ".",
                Filter = "nuget.config|nuget.config",
                Title = "Browse for NuGet.config",
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtNuGetConfigPath.Text = dialog.FileName;

                IReadOnlyList<NugetFeedDefinition>? nugetFeedDefinitions = null;
                await InvokeAsync(nuGetFeedBrowserControl,
                    async () =>
                    {
                        nuGetFeedBrowserControl.Enabled = false;

                        nugetFeedDefinitions = await s_nugetConfigParser.LoadAsync(dialog.FileName);
                    },
                    () =>
                    {
                        nuGetFeedBrowserControl.BindFeeds(nugetFeedDefinitions);

                        if (nugetFeedDefinitions is not null)
                        {
                            nuGetFeedBrowserControl.Enabled = true;
                        }
                    });
            }
        }
    }
}
