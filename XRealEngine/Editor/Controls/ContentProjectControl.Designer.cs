namespace Editor.Controls
{
    partial class ContentProjectControl
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
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // assetsTreeView
            // 
            this.assetsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsTreeView.Location = new System.Drawing.Point(0, 0);
            this.assetsTreeView.Name = "assetsTreeView";
            this.assetsTreeView.Size = new System.Drawing.Size(290, 283);
            this.assetsTreeView.TabIndex = 0;
            this.assetsTreeView.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(290, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ContentProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.assetsTreeView);
            this.Name = "ContentProjectControl";
            this.Size = new System.Drawing.Size(290, 283);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView assetsTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
    }
}
