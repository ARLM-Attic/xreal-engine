namespace Editor
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabBottom = new System.Windows.Forms.TabControl();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.tabLeftPanel = new System.Windows.Forms.TabControl();
            this.tabProjectExplorer = new System.Windows.Forms.TabPage();
            this.projectExplorer = new Editor.Controls.ContentProjectControl();
            this.backgroundBuilder = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabBottom.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabLeftPanel.SuspendLayout();
            this.tabProjectExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(673, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menu
            // 
            this.menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openProjectToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(37, 20);
            this.menu.Text = "File";
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 375);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(673, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(627, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabLeftPanel);
            this.splitContainer1.Size = new System.Drawing.Size(673, 351);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabBottom);
            this.splitContainer2.Size = new System.Drawing.Size(481, 351);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabBottom
            // 
            this.tabBottom.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabBottom.Controls.Add(this.tabLog);
            this.tabBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBottom.Location = new System.Drawing.Point(0, 0);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.SelectedIndex = 0;
            this.tabBottom.Size = new System.Drawing.Size(481, 187);
            this.tabBottom.TabIndex = 0;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.listViewLog);
            this.tabLog.Location = new System.Drawing.Point(4, 4);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(473, 161);
            this.tabLog.TabIndex = 0;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // listViewLog
            // 
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDescription});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.GridLines = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLog.Location = new System.Drawing.Point(3, 3);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(467, 155);
            this.listViewLog.TabIndex = 0;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "";
            this.columnDescription.Width = 500;
            // 
            // tabLeftPanel
            // 
            this.tabLeftPanel.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabLeftPanel.Controls.Add(this.tabProjectExplorer);
            this.tabLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.tabLeftPanel.Name = "tabLeftPanel";
            this.tabLeftPanel.SelectedIndex = 0;
            this.tabLeftPanel.Size = new System.Drawing.Size(188, 351);
            this.tabLeftPanel.TabIndex = 0;
            // 
            // tabProjectExplorer
            // 
            this.tabProjectExplorer.Controls.Add(this.projectExplorer);
            this.tabProjectExplorer.Location = new System.Drawing.Point(4, 4);
            this.tabProjectExplorer.Name = "tabProjectExplorer";
            this.tabProjectExplorer.Size = new System.Drawing.Size(180, 325);
            this.tabProjectExplorer.TabIndex = 0;
            this.tabProjectExplorer.Text = "Project Explorer";
            this.tabProjectExplorer.UseVisualStyleBackColor = true;
            // 
            // projectExplorer
            // 
            this.projectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectExplorer.Location = new System.Drawing.Point(0, 0);
            this.projectExplorer.Logger = null;
            this.projectExplorer.Name = "projectExplorer";
            this.projectExplorer.ProjectFullPath = null;
            this.projectExplorer.Size = new System.Drawing.Size(180, 325);
            this.projectExplorer.TabIndex = 0;
            // 
            // backgroundBuilder
            // 
            this.backgroundBuilder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundBuilder_DoWork);
            this.backgroundBuilder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundBuilder_RunWorkerCompleted);
            this.backgroundBuilder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundBuilder_ProgressChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 397);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabBottom.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabLeftPanel.ResumeLayout(false);
            this.tabProjectExplorer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menu;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabLeftPanel;
        private System.Windows.Forms.TabPage tabProjectExplorer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabBottom;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.ListView listViewLog;
        private Editor.Controls.ContentProjectControl projectExplorer;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.ComponentModel.BackgroundWorker backgroundBuilder;
    }
}