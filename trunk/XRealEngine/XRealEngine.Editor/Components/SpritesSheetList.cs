using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Editor.Components
{
    public partial class SpritesSheetList : UserControl
    {
        private List<SpritesSheet> sheets;
        private SpritesSheet selectedSheet;
        private SpriteDefinition selectedSprite;

        public SpriteDefinition SelectedSprite
        {
            get 
            { 
                return selectedSprite; 
            }
            set
            {
                if (selectedSprite != value)
                {
                    selectedSprite = value;
                    if (value != null)
                    {
                        this.listView1.Items[value.Name].Selected = true;
                        this.listView1.Refresh();
                    }
                    else
                    {
                        this.listView1.SelectedItems.Clear();
                    }
                }
            }
        }

        public SpritesSheet SelectedSheet
        {
            get { return selectedSheet; }
            set
            {
                if (selectedSheet != value)
                {
                    selectedSheet = value;
                    FillList();
                }
            }
        }

        public SpritesSheetList()
        {
            InitializeComponent();

            sheets = new List<SpritesSheet>();
        }

        public void AddSpritesSheet(SpritesSheet sheet)
        {
            sheets.Add(sheet);
            this.SelectedSheet = sheet;
        }

        private void FillList()
        {
            this.listView1.Items.Clear();
            this.imageList1.Images.Clear();

            if (SelectedSheet != null)
            {
                foreach (SpriteDefinition sprite in SelectedSheet)
                {
                    Bitmap bitmap = GetImageFromTexture(sprite.Rectangle, SelectedSheet.Texture);
                    this.imageList1.Images.Add(sprite.Name, bitmap);
                    this.listView1.Items.Add(sprite.Name, sprite.Name, sprite.Name);
                }
            }
        }


        private Bitmap GetImageFromTexture(Microsoft.Xna.Framework.Rectangle rect, Texture2D texture)
        {
            int[] data = new int[rect.Width * rect.Height];
            texture.GetData<int>(0, rect, data, 0, rect.Width * rect.Height);
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);

            for (int x = 0; x < rect.Width; ++x)
            {
                for (int y = 0; y < rect.Height; ++y)
                {
                    System.Drawing.Color bitmapColor = System.Drawing.Color.FromArgb(data[y * rect.Width + x]);
                    bitmap.SetPixel(x, y, bitmapColor);
                }
            }

            return bitmap;
        }
    }
}
