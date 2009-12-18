using System;
using Microsoft.Xna.Framework;
using XRealEngine.Framework.Spatialization;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegment:ISpatialElement
    {
        private int spriteSheetIndex;
        private int spriteDefinitionIndex;
        private int layerIndex;
        private Rectangle boundingBox;

        public event EventHandler Moved;

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set
            {
                if (boundingBox != value)
                {
                    boundingBox = value;
                    if (Moved != null) Moved(this, EventArgs.Empty);
                }
            }
        }

        public int LayerIndex
        {
            get { return layerIndex; }
            set { layerIndex = value; }
        }

        public int SpriteDefinitionIndex
        {
            get { return spriteDefinitionIndex; }
            set { spriteDefinitionIndex = value; }
        }

        public int SpriteSheetIndex
        {
            get { return spriteSheetIndex; }
            set { spriteSheetIndex = value; }
        }

        public Point Location
        {
            get { return boundingBox.Location; }
            set
            {
                if (boundingBox.Location != value)
                {
                    boundingBox.Location = value;
                    if (Moved != null) Moved(this, EventArgs.Empty);
                }
            }
        }
    }
}
