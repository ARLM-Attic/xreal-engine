namespace Editor.Forms
{
    partial class SpriteSheetEditor
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
            this.spriteSheetViewerControl1 = new Editor.Controls.SpriteSheetViewerControl();
            this.SuspendLayout();
            // 
            // spriteSheetViewerControl1
            // 
            this.spriteSheetViewerControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.spriteSheetViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteSheetViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.spriteSheetViewerControl1.Name = "spriteSheetViewerControl1";
            this.spriteSheetViewerControl1.Size = new System.Drawing.Size(284, 264);
            this.spriteSheetViewerControl1.TabIndex = 0;
            this.spriteSheetViewerControl1.Text = "spriteSheetViewerControl1";            
            // 
            // SpriteSheetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.spriteSheetViewerControl1);
            this.Name = "SpriteSheetEditor";
            this.Text = "SpriteSheetEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private Editor.Controls.SpriteSheetViewerControl spriteSheetViewerControl1;
    }
}