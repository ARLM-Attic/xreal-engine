using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using XRealEngine.Framework.Graphics;

namespace XRealEngine.Editor.Components
{
    public partial class SpritesSheetList : UserControl
    {
        public event SpriteEventHandler SelectedSpriteChanged;
        public event SpriteEventHandler SpriteRemoved;
        public event SpriteEventHandler SpriteAdded;

        private SpritesSheetCollection sheets;
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
                        if (!this.listView1.Items[value.Name].Selected)
                        {
                            this.listView1.Items[value.Name].Selected = true;
                            this.listView1.Refresh();
                        }
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

            sheets = new SpritesSheetCollection();
        }

        public void AddSpritesSheet(SpritesSheet sheet)
        {
            sheets.Add(sheet);
            FillCombo();
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
                    AddSprite(sprite);
                }
            }
        }

        private void FillCombo()
        {
            this.comboBox1.Items.Clear();
            for (int i = 0; i < sheets.Count; i++)
            {
                this.comboBox1.Items.Add(String.Format("Sprites Sheet {0}", i));
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



            return ResizeBitmap(bitmap, this.imageList1.ImageSize);
        }

        private Bitmap ResizeBitmap(Bitmap b, Size newSize)
        {
            Bitmap result = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(b, 0, 0, newSize.Width, newSize.Height);
            return result;
        }

        public void RefreshSpriteImage(SpriteDefinition sprite)
        {
            Bitmap bitmap = GetImageFromTexture(sprite.Rectangle, SelectedSheet.Texture);
            this.imageList1.Images.RemoveByKey(sprite.Name);
            this.imageList1.Images.Add(sprite.Name, bitmap);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count == 1)
            {
                this.SelectedSpriteChanged(this, new SpriteEventArgs(selectedSheet[listView1.SelectedIndices[0]]));
            }
            else
            {
                this.SelectedSpriteChanged(this, new SpriteEventArgs(null));
            }
        }

        private void toolRemoveSprite_Click(object sender, EventArgs e)
        {
            RemoveSprite(this.SelectedSprite);
        }

        public void RemoveSprite(SpriteDefinition sprite)
        {
            if (sprite != null)
            {
                if (SelectedSheet.Contains(sprite))
                {
                    SpriteEventArgs e = new SpriteEventArgs(sprite);
                    this.imageList1.Images.RemoveByKey(sprite.Name);
                    this.listView1.Items.RemoveByKey(sprite.Name);
                    SelectedSheet.Remove(sprite);
                    if (sprite == SelectedSprite)
                    {
                        SelectedSprite = null;
                        
                    }
                    SpriteRemoved(this, e);
                }
                
            }
        }

        public void AddNewSprite()
        {
            SpriteDefinition sprite = new SpriteDefinition();
            sprite.X = 50;
            sprite.Y = 50;
            sprite.Width = 50;
            sprite.Height = 50;

            AddSprite(sprite);
            SpriteAdded(this, new SpriteEventArgs(sprite));
            this.SelectedSprite = sprite;
        }

        public void AddSprite(SpriteDefinition sprite)
        {
            if (!this.SelectedSheet.Contains(sprite)) this.SelectedSheet.Add(sprite);
            if (!this.imageList1.Images.ContainsKey(sprite.Name))
            {
                Bitmap bitmap = GetImageFromTexture(sprite.Rectangle, SelectedSheet.Texture);
                this.imageList1.Images.Add(sprite.Name, bitmap);
                this.listView1.Items.Add(sprite.Name, sprite.Name, sprite.Name);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddNewSprite();
        }
    }
}
