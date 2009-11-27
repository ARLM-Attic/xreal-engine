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
            System.Windows.Forms.Button button1;
            XRealEngine.Editor.Components.SpritesSheetViewer spritesSheetViewer1;
            this.label1 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSpritesSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            button1 = new System.Windows.Forms.Button();
            spritesSheetViewer1 = new XRealEngine.Editor.Components.SpritesSheetViewer();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(381, 401);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // spritesSheetViewer1
            // 
            spritesSheetViewer1.Location = new System.Drawing.Point(12, 28);
            spritesSheetViewer1.Name = "spritesSheetViewer1";
            spritesSheetViewer1.Size = new System.Drawing.Size(466, 268);
            spritesSheetViewer1.TabIndex = 2;
            spritesSheetViewer1.Text = "spritesSheetViewer1";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(499, 24);
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
            // SpritesSheetEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 436);
            this.Controls.Add(spritesSheetViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(button1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "SpritesSheetEditorView";
            this.Text = "Form1";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSpritesSheetToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}

