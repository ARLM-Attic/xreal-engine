namespace Editor
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
            this.xnaViewer1 = new XRealEngine.Framework.XnaViewer();
            this.SuspendLayout();
            // 
            // xnaViewer1
            // 
            this.xnaViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xnaViewer1.Location = new System.Drawing.Point(0, 0);
            this.xnaViewer1.Name = "xnaViewer1";
            this.xnaViewer1.Size = new System.Drawing.Size(284, 264);
            this.xnaViewer1.TabIndex = 0;
            this.xnaViewer1.Text = "xnaViewer1";
            // 
            // SpriteSheetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.xnaViewer1);
            this.Name = "SpriteSheetEditor";
            this.Text = "SpriteSheetEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private XRealEngine.Framework.XnaViewer xnaViewer1;
    }
}