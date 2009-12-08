using System;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Graphics
{
    public class MapSegment
    {
        public Vector2 Location;
        private int spriteSheetIndex;
        
        public int SpriteSheetIndex
        {
            get { return spriteSheetIndex; }
            set { spriteSheetIndex = value; }
        }


    }
}
