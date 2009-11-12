using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRealEngine.Framework;
using Microsoft.Xna.Framework;

namespace Editor
{
    public partial class SpriteSheetEditor : Form
    {
        SelectionsManager selectionsManager;

        public SpriteSheetEditor()
        {
            InitializeComponent();
            this.xnaViewer1.Initialize();
            this.xnaViewer1.Paint += new PaintEventHandler(xnaViewer1_Paint);

            selectionsManager = new SelectionsManager(xnaViewer1.GraphicsDevice);
            selectionsManager.AddSelection(new RectangularSelection(new Microsoft.Xna.Framework.Rectangle(20,20, 10,100)));
        }

        void xnaViewer1_Paint(object sender, PaintEventArgs e)
        {
            this.xnaViewer1.GraphicsDevice.Clear(Microsoft.Xna.Framework.Graphics.Color.DarkRed);
            selectionsManager.Draw();
            this.xnaViewer1.Present();
        }
    }
}
