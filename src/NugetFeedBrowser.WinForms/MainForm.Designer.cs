namespace NugetFeedBrowser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFeeds = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuGetConfigBrowse = new System.Windows.Forms.Button();
            this.lblNuGetConfigPath = new System.Windows.Forms.Label();
            this.txtNuGetConfigPath = new System.Windows.Forms.TextBox();
            this.nuGetFeedBrowserControl = new NugetFeedBrowser.NuGetFeedBrowserControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tabControl.SuspendLayout();
            this.tabPageFeeds.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFeeds);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(58, 32);
            this.tabControl.Location = new System.Drawing.Point(8, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(761, 507);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageFeeds
            // 
            this.tabPageFeeds.Controls.Add(this.tableLayoutPanel1);
            this.tabPageFeeds.Location = new System.Drawing.Point(4, 36);
            this.tabPageFeeds.Name = "tabPageFeeds";
            this.tabPageFeeds.Padding = new System.Windows.Forms.Padding(8);
            this.tabPageFeeds.Size = new System.Drawing.Size(753, 467);
            this.tabPageFeeds.TabIndex = 0;
            this.tabPageFeeds.Text = "NuGet Feeds";
            this.tabPageFeeds.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnNuGetConfigBrowse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNuGetConfigPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNuGetConfigPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nuGetFeedBrowserControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnNuGetConfigBrowse
            // 
            this.btnNuGetConfigBrowse.AutoSize = true;
            this.btnNuGetConfigBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuGetConfigBrowse.Location = new System.Drawing.Point(708, 3);
            this.btnNuGetConfigBrowse.Name = "btnNuGetConfigBrowse";
            this.btnNuGetConfigBrowse.Size = new System.Drawing.Size(26, 25);
            this.btnNuGetConfigBrowse.TabIndex = 2;
            this.btnNuGetConfigBrowse.Text = "...";
            this.btnNuGetConfigBrowse.UseVisualStyleBackColor = true;
            this.btnNuGetConfigBrowse.Click += new System.EventHandler(this.btnNuGetConfigBrowse_Click);
            // 
            // lblNuGetConfigPath
            // 
            this.lblNuGetConfigPath.AutoSize = true;
            this.lblNuGetConfigPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNuGetConfigPath.Location = new System.Drawing.Point(3, 0);
            this.lblNuGetConfigPath.Name = "lblNuGetConfigPath";
            this.lblNuGetConfigPath.Size = new System.Drawing.Size(116, 31);
            this.lblNuGetConfigPath.TabIndex = 0;
            this.lblNuGetConfigPath.Text = "Path to nuget.config";
            this.lblNuGetConfigPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNuGetConfigPath
            // 
            this.txtNuGetConfigPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNuGetConfigPath.Location = new System.Drawing.Point(125, 3);
            this.txtNuGetConfigPath.Name = "txtNuGetConfigPath";
            this.txtNuGetConfigPath.ReadOnly = true;
            this.txtNuGetConfigPath.Size = new System.Drawing.Size(577, 23);
            this.txtNuGetConfigPath.TabIndex = 1;
            // 
            // nuGetFeedBrowserControl
            // 
            this.nuGetFeedBrowserControl.AutoSize = true;
            this.nuGetFeedBrowserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.nuGetFeedBrowserControl, 3);
            this.nuGetFeedBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuGetFeedBrowserControl.Enabled = false;
            this.nuGetFeedBrowserControl.Location = new System.Drawing.Point(3, 34);
            this.nuGetFeedBrowserControl.Name = "nuGetFeedBrowserControl";
            this.nuGetFeedBrowserControl.Size = new System.Drawing.Size(731, 414);
            this.nuGetFeedBrowserControl.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(8, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(761, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(50, 22);
            this.tsbtnRefresh.Text = "&Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(777, 540);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.Text = "NuGet Feed Browser";
            this.tabControl.ResumeLayout(false);
            this.tabPageFeeds.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFeeds;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnNuGetConfigBrowse;
        private Label lblNuGetConfigPath;
        private TextBox txtNuGetConfigPath;
        private NuGetFeedBrowserControl nuGetFeedBrowserControl;
    }
}

