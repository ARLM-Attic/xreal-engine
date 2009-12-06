using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Framework.Sprites;

namespace XRealEngine.Editor.Components
{
    public delegate void SpriteEventHandler(Object sender, SpriteEventArgs e);

    public class SpriteEventArgs : EventArgs
    {
        public SpriteDefinition Sprite;

        public SpriteEventArgs(SpriteDefinition sprite)
        {
            Sprite = sprite;
        }
    }
}
