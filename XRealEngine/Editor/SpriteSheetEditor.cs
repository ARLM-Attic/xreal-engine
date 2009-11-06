using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor
{
    public partial class SpriteSheetEditor : Form
    {
        public SpriteSheetEditor()
        {
            InitializeComponent();
            this.xnaViewer1.Initialize();
            this.xnaViewer1.Paint += new PaintEventHandler(xnaViewer1_Paint);
        }

        void xnaViewer1_Paint(object sender, PaintEventArgs e)
        {
            this.xnaViewer1.GraphicsDevice.Clear(Microsoft.Xna.Framework.Graphics.Color.DarkRed);
            this.xnaViewer1.Present();
        }
    }
}
