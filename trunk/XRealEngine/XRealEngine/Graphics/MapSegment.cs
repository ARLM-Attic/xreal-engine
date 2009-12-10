using System;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegment
    {
        public Vector2 Location;
        private int spriteSheetIndex;
        private int spriteDefinitionIndex;
        private int layerIndex;

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


    }
}
