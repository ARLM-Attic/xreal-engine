using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using XRealEngine.Framework.Sprites;

namespace XRealEngine.ContentPipeline
{
    [ContentSerializerRuntimeType("XRealEngine.Sprites.SpritesSheet, XRealEngine")]
    public class SpritesSheetContent
    {
        public List<SpriteDefinition> spritesList;
        public ExternalReference<Texture2D> texture;
    }
}
