using XRealEngine.Editor.Components;
namespace XRealEngine.Editor.Views
{
    partial class SpritesSheetEditorView
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSpritesSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spritesSheetViewer1 = new XRealEngine.Editor.Components.SpritesSheetViewer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.spritesSheetList1 = new XRealEngine.Editor.Components.SpritesSheetList();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(703, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSpritesSheetToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSpritesSheetToolStripMenuItem
            // 
            this.openSpritesSheetToolStripMenuItem.Name = "openSpritesSheetToolStripMenuItem";
            this.openSpritesSheetToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openSpritesSheetToolStripMenuItem.Text = "Open Sprites Sheet";
            this.openSpritesSheetToolStripMenuItem.Click += new System.EventHandler(this.openSpritesSheetToolStripMenuItem_Click);
            // 
            // openDialog
            // 
            this.openDialog.Filter = "SpritesSheet File|*.xml";
            this.openDialog.Title = "Open a Sprites Sheet";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.spritesSheetViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(703, 502);
            this.splitContainer1.SplitterDistance = 477;
            this.splitContainer1.TabIndex = 5;
            // 
            // spritesSheetViewer1
            // 
            this.spritesSheetViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesSheetViewer1.Location = new System.Drawing.Point(0, 0);
            this.spritesSheetViewer1.Name = "spritesSheetViewer1";
            this.spritesSheetViewer1.SelectedSprite = null;
            this.spritesSheetViewer1.Size = new System.Drawing.Size(477, 502);
            this.spritesSheetViewer1.SpritesSheet = null;
            this.spritesSheetViewer1.TabIndex = 2;
            this.spritesSheetViewer1.Text = "spritesSheetViewer1";
            this.spritesSheetViewer1.SelectedSpriteChanged += new XRealEngine.Editor.Components.SpriteEventHandler(this.spritesSheetViewer1_SelectedSpriteChanged);
            this.spritesSheetViewer1.OperationEnded += new XRealEngine.Editor.Components.SpriteEventHandler(this.spritesSheetViewer1_OperationEnded);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.spritesSheetList1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Size = new System.Drawing.Size(222, 502);
            this.splitContainer2.SplitterDistance = 196;
            this.splitContainer2.TabIndex = 0;
            // 
            // spritesSheetList1
            // 
            this.spritesSheetList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesSheetList1.Location = new System.Drawing.Point(0, 0);
            this.spritesSheetList1.Name = "spritesSheetList1";
            this.spritesSheetList1.SelectedSheet = null;
            this.spritesSheetList1.SelectedSprite = null;
            this.spritesSheetList1.Size = new System.Drawing.Size(222, 196);
            this.spritesSheetList1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(222, 302);
            this.propertyGrid1.TabIndex = 0;
            // 
            // SpritesSheetEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "SpritesSheetEditorView";
            this.Text = "Sprites Sheet Editor";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSpritesSheetToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private XRealEngine.Editor.Components.SpritesSheetViewer spritesSheetViewer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private XRealEngine.Editor.Components.SpritesSheetList spritesSheetList1;
    }
}

