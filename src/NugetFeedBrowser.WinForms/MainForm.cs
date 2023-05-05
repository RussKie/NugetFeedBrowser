// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using Newtonsoft.Json;
using NugetFeedBrowser.Shared;

namespace NugetFeedBrowser
{
    public partial class MainForm : Form
    {
        private static readonly NugetConfigParser s_nugetConfigParser = new();
        private readonly WaitSpinner _waitSpinner;
        private bool _operationInProgress;

        public MainForm()
        {
            InitializeComponent();

            _waitSpinner = new WaitSpinner
            {
                BackColor = SystemColors.Window,
                Size = new Size(50, 50)
            };

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
                    hostControl.Invoke(() =>
                    {
                        onCompleteMethod?.Invoke();
                        EndUIOperation();
                    });
                }
            });

            void BeginUIOperation()
            {
                _operationInProgress = true;
                ShowSpinner(visible: true, hostControl);
            }

            void EndUIOperation()
            {
                _operationInProgress = false;
                ShowSpinner(visible: false);
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

        private async Task LoadFeedsAsync(string nugetConfig)
        {
            IReadOnlyList<NugetFeedDefinition>? nugetFeedDefinitions = null;
            await InvokeAsync(nuGetFeedBrowserControl,
                async () =>
                {
                    nuGetFeedBrowserControl.Invoke(() =>
                    {
                        nuGetFeedBrowserControl.Enabled = false;
                    });

                    nugetFeedDefinitions = await s_nugetConfigParser.LoadAsync(nugetConfig);
                },
                () =>
                {
                    nuGetFeedBrowserControl.Invoke(() =>
                    {
                        nuGetFeedBrowserControl.BindFeeds(nugetFeedDefinitions);

                        if (nugetFeedDefinitions is not null)
                        {
                            nuGetFeedBrowserControl.Enabled = true;
                        }
                    });
                });
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

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            txtNuGetConfigPath.Text = dialog.FileName;
            await LoadFeedsAsync(dialog.FileName);
        }

        private async void btnExtractPat_Click(object sender, EventArgs e)
        {
            Global.SetAccessToken(null);

            ExecutionResult? executionResult;
            try
            {
                Executable azureClient = new("az.bat");
                executionResult = await azureClient.GetOutputAsync("account get-access-token");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (executionResult is null || executionResult.ExitCode != 0)
            {
                MessageBox.Show("Failed to retrieve access token. Is Azure CLI installed and configured?");
                return;
            }

            AzAccessToken descriptor = JsonConvert.DeserializeObject<AzAccessToken>(executionResult.Output)!;
            Global.SetAccessToken(descriptor.AccessToken);

            if (!string.IsNullOrEmpty(descriptor.AccessToken))
            {
                await LoadFeedsAsync(txtNuGetConfigPath.Text);
            }
        }

        private record AzAccessToken
        {
            public string? AccessToken { get; set; }
        }
    }
}
