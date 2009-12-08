using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework.Graphics
{
    public class MapLayer
    {
        private Color color;
        private float scale;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
       
        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public MapLayer(int scale, Color color)
        {
            this.Color = color;
            this.Scale = scale;
        }
    }
}
