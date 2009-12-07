namespace XRealEngine.Editor.Views
{
    partial class MapEditorView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mapViewer1 = new XRealEngine.Editor.Components.MapViewer();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mapViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(827, 401);
            this.splitContainer1.SplitterDistance = 525;
            this.splitContainer1.TabIndex = 0;
            // 
            // mapViewer1
            // 
            this.mapViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewer1.Location = new System.Drawing.Point(0, 0);
            this.mapViewer1.Name = "mapViewer1";
            this.mapViewer1.Size = new System.Drawing.Size(298, 401);
            this.mapViewer1.TabIndex = 0;
            this.mapViewer1.Text = "mapViewer1";
            // 
            // MapEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 401);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MapEditorView";
            this.Text = "MapEditorView";
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private XRealEngine.Editor.Components.MapViewer mapViewer1;
    }
}