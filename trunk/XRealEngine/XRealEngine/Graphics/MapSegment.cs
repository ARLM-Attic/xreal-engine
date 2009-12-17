using System;
using Microsoft.Xna.Framework;
using XRealEngine.Framework.Spatialization;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegment:ISpatialElement
    {
        private Point location;
        private int spriteSheetIndex;
        private int spriteDefinitionIndex;
        private int layerIndex;
        private Rectangle boundingBox;

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
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
            get { return location; }
            set 
            { 
                location = value;
                boundingBox.Location = value;
            }
        }


    }
}
