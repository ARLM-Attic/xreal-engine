using System;
using XRealEngine.Framework.Graphics;

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
