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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnNuGetConfigBrowse = new Button();
            lblNuGetConfigPath = new Label();
            txtNuGetConfigPath = new TextBox();
            nuGetFeedBrowserControl = new NuGetFeedBrowserControl();
            btnExtractPat = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnNuGetConfigBrowse, 2, 0);
            tableLayoutPanel1.Controls.Add(lblNuGetConfigPath, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNuGetConfigPath, 1, 0);
            tableLayoutPanel1.Controls.Add(nuGetFeedBrowserControl, 0, 1);
            tableLayoutPanel1.Controls.Add(btnExtractPat, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(8, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(761, 524);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnNuGetConfigBrowse
            // 
            btnNuGetConfigBrowse.AutoSize = true;
            btnNuGetConfigBrowse.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNuGetConfigBrowse.Location = new Point(661, 3);
            btnNuGetConfigBrowse.Name = "btnNuGetConfigBrowse";
            btnNuGetConfigBrowse.Size = new Size(26, 25);
            btnNuGetConfigBrowse.TabIndex = 2;
            btnNuGetConfigBrowse.Text = "...";
            btnNuGetConfigBrowse.UseVisualStyleBackColor = true;
            btnNuGetConfigBrowse.Click += btnNuGetConfigBrowse_Click;
            // 
            // lblNuGetConfigPath
            // 
            lblNuGetConfigPath.AutoSize = true;
            lblNuGetConfigPath.Dock = DockStyle.Fill;
            lblNuGetConfigPath.Location = new Point(3, 0);
            lblNuGetConfigPath.Name = "lblNuGetConfigPath";
            lblNuGetConfigPath.Size = new Size(116, 31);
            lblNuGetConfigPath.TabIndex = 0;
            lblNuGetConfigPath.Text = "Path to nuget.config";
            lblNuGetConfigPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNuGetConfigPath
            // 
            txtNuGetConfigPath.Dock = DockStyle.Fill;
            txtNuGetConfigPath.Location = new Point(125, 3);
            txtNuGetConfigPath.Name = "txtNuGetConfigPath";
            txtNuGetConfigPath.ReadOnly = true;
            txtNuGetConfigPath.Size = new Size(530, 23);
            txtNuGetConfigPath.TabIndex = 1;
            // 
            // nuGetFeedBrowserControl
            // 
            nuGetFeedBrowserControl.AutoSize = true;
            nuGetFeedBrowserControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.SetColumnSpan(nuGetFeedBrowserControl, 4);
            nuGetFeedBrowserControl.Dock = DockStyle.Fill;
            nuGetFeedBrowserControl.Enabled = false;
            nuGetFeedBrowserControl.Location = new Point(3, 34);
            nuGetFeedBrowserControl.Name = "nuGetFeedBrowserControl";
            nuGetFeedBrowserControl.Size = new Size(755, 487);
            nuGetFeedBrowserControl.TabIndex = 4;
            // 
            // btnExtractPat
            // 
            btnExtractPat.AutoSize = true;
            btnExtractPat.Location = new Point(693, 3);
            btnExtractPat.Name = "btnExtractPat";
            btnExtractPat.Size = new Size(65, 25);
            btnExtractPat.TabIndex = 3;
            btnExtractPat.Text = "Load PAT";
            btnExtractPat.UseVisualStyleBackColor = true;
            btnExtractPat.Click += btnExtractPat_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(777, 540);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Name = "MainForm";
            Padding = new Padding(8);
            Text = "DevDiv NuGet Feed Browser";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnNuGetConfigBrowse;
        private Label lblNuGetConfigPath;
        private TextBox txtNuGetConfigPath;
        private NuGetFeedBrowserControl nuGetFeedBrowserControl;
        private Button btnExtractPat;
    }
}

