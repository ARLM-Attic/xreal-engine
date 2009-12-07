using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Windows;
using XRealEngine.Windows.Winforms;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace XRealEngine.Editor.Components
{
    public class MapViewer : GraphicsDeviceControl
    {
        private SpriteBatch spriteBatch;
        private PrimitiveBatch primitiveBatch;
        private Map map;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            primitiveBatch = new PrimitiveBatch(this.GraphicsDevice);
            map = new Map();
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);
        }

        private void InitializeMap()
        {
            
        }
    }
}
