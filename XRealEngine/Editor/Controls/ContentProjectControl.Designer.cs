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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentProjectControl));
            this.assetsTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addNewAssetButton = new System.Windows.Forms.ToolStripButton();
            this.addExistingAssetButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // assetsTreeView
            // 
            this.assetsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetsTreeView.ImageIndex = 0;
            this.assetsTreeView.ImageList = this.imageList;
            this.assetsTreeView.Location = new System.Drawing.Point(0, 0);
            this.assetsTreeView.Name = "assetsTreeView";
            this.assetsTreeView.SelectedImageIndex = 0;
            this.assetsTreeView.Size = new System.Drawing.Size(290, 258);
            this.assetsTreeView.TabIndex = 0;
            this.assetsTreeView.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ASSET_IMAGE");
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewAssetButton,
            this.addExistingAssetButton});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(58, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // addNewAssetButton
            // 
            this.addNewAssetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNewAssetButton.Image = ((System.Drawing.Image)(resources.GetObject("addNewAssetButton.Image")));
            this.addNewAssetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNewAssetButton.Name = "addNewAssetButton";
            this.addNewAssetButton.Size = new System.Drawing.Size(23, 22);
            this.addNewAssetButton.Text = "Add a new asset";
            this.addNewAssetButton.ToolTipText = "Add a new asset";
            this.addNewAssetButton.Click += new System.EventHandler(this.addNewAssetButton_Click);
            // 
            // addExistingAssetButton
            // 
            this.addExistingAssetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addExistingAssetButton.Image = ((System.Drawing.Image)(resources.GetObject("addExistingAssetButton.Image")));
            this.addExistingAssetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addExistingAssetButton.Name = "addExistingAssetButton";
            this.addExistingAssetButton.Size = new System.Drawing.Size(23, 22);
            this.addExistingAssetButton.Text = "Add an existing asset";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.assetsTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(290, 258);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(290, 283);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // ContentProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ContentProjectControl";
            this.Size = new System.Drawing.Size(290, 283);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView assetsTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton addExistingAssetButton;
        private System.Windows.Forms.ToolStripButton addNewAssetButton;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}
