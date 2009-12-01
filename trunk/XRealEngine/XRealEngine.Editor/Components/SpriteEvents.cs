using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Framework.Sprites;

namespace XRealEngine.Editor.Components
{
    public class SpriteEventArgs : EventArgs
    {
        public SpriteDefinition Sprite;

        public SpriteEventArgs(SpriteDefinition sprite)
        {
            Sprite = sprite;
        }
    }
}
