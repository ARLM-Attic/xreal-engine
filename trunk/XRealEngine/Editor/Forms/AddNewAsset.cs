using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRealEngine.Framework.Sprites;

namespace Editor.Forms
{
    public partial class AddNewAsset : Form
    {
        private string assetType;
        private string assetName;

        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }
        
        public string AssetType
        {
            get { return assetType; }
            set 
            {
                switch (value)
                {
                    case SpritesSheet.AssetTypeName:
                        this.labelAssetDescription.Text = "Create a new sprites sheet";
                        break;
                    default:
                        this.labelAssetDescription.Text = "";
                        break;
                }
                assetType = value; 
            }
        }

        public AddNewAsset()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                this.AssetType = listView1.SelectedItems[0].Tag.ToString();
            }
            else
            {
                this.AssetType = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.AssetName = textBox1.Text;
        } 
    }
}
