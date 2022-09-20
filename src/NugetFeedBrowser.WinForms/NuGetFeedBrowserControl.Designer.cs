// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace NugetFeedBrowser
{
    partial class NuGetFeedBrowserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNuGetPackageName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvSearchResults = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNuGetPackageName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNuGetPackageName
            // 
            this.txtNuGetPackageName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNuGetPackageName.Location = new System.Drawing.Point(97, 3);
            this.txtNuGetPackageName.Name = "txtNuGetPackageName";
            this.txtNuGetPackageName.Size = new System.Drawing.Size(620, 23);
            this.txtNuGetPackageName.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lvSearchResults, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNuGetPackageName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNuGetPackageName, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 544);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvSearchResults
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lvSearchResults, 3);
            this.lvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSearchResults.Location = new System.Drawing.Point(3, 32);
            this.lvSearchResults.MultiSelect = false;
            this.lvSearchResults.Name = "lvSearchResults";
            this.lvSearchResults.OwnerDraw = true;
            this.lvSearchResults.ShowItemToolTips = true;
            this.lvSearchResults.Size = new System.Drawing.Size(795, 509);
            this.lvSearchResults.TabIndex = 3;
            this.lvSearchResults.TileSize = new System.Drawing.Size(300, 64);
            this.lvSearchResults.UseCompatibleStateImageBehavior = false;
            this.lvSearchResults.View = System.Windows.Forms.View.Tile;
            this.lvSearchResults.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvSearchResults_DrawItem);
            this.lvSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSearchResults_MouseDoubleClick);
            this.lvSearchResults.MouseLeave += new System.EventHandler(this.lvSearchResults_MouseLeave);
            this.lvSearchResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvSearchResults_MouseMove);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(723, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNuGetPackageName
            // 
            this.lblNuGetPackageName.AutoSize = true;
            this.lblNuGetPackageName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNuGetPackageName.Location = new System.Drawing.Point(3, 0);
            this.lblNuGetPackageName.Name = "lblNuGetPackageName";
            this.lblNuGetPackageName.Size = new System.Drawing.Size(88, 29);
            this.lblNuGetPackageName.TabIndex = 0;
            this.lblNuGetPackageName.Text = "NuGet package";
            this.lblNuGetPackageName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NuGetFeedBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "NuGetFeedBrowserControl";
            this.Size = new System.Drawing.Size(801, 544);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtNuGetPackageName;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView lvSearchResults;
        private Button btnSearch;
        private Label lblNuGetPackageName;
    }
}
