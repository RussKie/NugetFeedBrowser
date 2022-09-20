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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuGetConfigBrowse = new System.Windows.Forms.Button();
            this.lblNuGetConfigPath = new System.Windows.Forms.Label();
            this.txtNuGetConfigPath = new System.Windows.Forms.TextBox();
            this.nuGetFeedBrowserControl = new NugetFeedBrowser.NuGetFeedBrowserControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 524);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnNuGetConfigBrowse
            // 
            this.btnNuGetConfigBrowse.AutoSize = true;
            this.btnNuGetConfigBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuGetConfigBrowse.Location = new System.Drawing.Point(732, 3);
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
            this.txtNuGetConfigPath.Size = new System.Drawing.Size(601, 23);
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
            this.nuGetFeedBrowserControl.Size = new System.Drawing.Size(755, 487);
            this.nuGetFeedBrowserControl.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(777, 540);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "DevDiv NuGet Feed Browser";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnNuGetConfigBrowse;
        private Label lblNuGetConfigPath;
        private TextBox txtNuGetConfigPath;
        private NuGetFeedBrowserControl nuGetFeedBrowserControl;
    }
}

