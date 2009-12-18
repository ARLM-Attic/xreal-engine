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
            this.spritesSheetList1 = new XRealEngine.Editor.Components.SpritesSheetList();
            this.splitContainer1.Panel1.SuspendLayout();
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
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mapViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.spritesSheetList1);
            this.splitContainer1.Size = new System.Drawing.Size(827, 404);
            this.splitContainer1.SplitterDistance = 525;
            this.splitContainer1.TabIndex = 0;
            // 
            // mapViewer1
            // 
            this.mapViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewer1.Location = new System.Drawing.Point(0, 0);
            this.mapViewer1.Name = "mapViewer1";
            this.mapViewer1.Size = new System.Drawing.Size(525, 404);
            this.mapViewer1.TabIndex = 1;
            this.mapViewer1.Text = "mapViewer1";
            // 
            // spritesSheetList1
            // 
            this.spritesSheetList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesSheetList1.Location = new System.Drawing.Point(0, 0);
            this.spritesSheetList1.Name = "spritesSheetList1";
            this.spritesSheetList1.SelectedSheet = null;
            this.spritesSheetList1.SelectedSprite = null;
            this.spritesSheetList1.Size = new System.Drawing.Size(298, 404);
            this.spritesSheetList1.TabIndex = 0;
            // 
            // MapEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 404);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MapEditorView";
            this.Text = "MapEditorView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private XRealEngine.Editor.Components.MapViewer mapViewer1;
        private XRealEngine.Editor.Components.SpritesSheetList spritesSheetList1;
    }
}