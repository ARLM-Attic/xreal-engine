using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using XRealEngine.Framework.Graphics;

namespace XRealEngine.ContentPipeline
{
    [ContentSerializerRuntimeType("XRealEngine.Framework.Graphics.SpritesSheet, XRealEngine")]
    public class SpritesSheetContent
    {
        [ContentSerializer(ElementName = "SpritesList", CollectionItemName = "Sprite")]
        public List<SpriteDefinition> SpritesList;
        [ContentSerializer(Optional = true)]
        public TextureContent Texture;
        [ContentSerializer(Optional = true)]
        public string TexturePath;

        public SpritesSheetContent()
        {
            SpritesList = new List<SpriteDefinition>();
        }

        public SpritesSheetContent(SpritesSheet sheet)
        {
            SpritesList = new List<SpriteDefinition>();
            foreach(SpriteDefinition sprite in sheet)
            {
                this.SpritesList.Add(sprite);
            }
            this.TexturePath = sheet.TexturePath;
        }
    }
}
