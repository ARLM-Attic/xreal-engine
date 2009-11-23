using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace XRealEngine.ContentPipeline
{
    [ContentSerializerRuntimeType("XRealEngine.Framework.Sprites.SpritesSheet, XRealEngine")]
    public class SpriteSheetContent
    {
        public List<SpriteDefinition> SpritesList;
        public Object Texture;
    }
}
