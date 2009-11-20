using Microsoft.Xna.Framework.Content;

namespace XRealEngine.ContentPipeline
{
    class SpritesSheetContent
    {
        [ContentSerializerRuntimeType("XRealEngine.Sprites.SpritesSheet, XRealEngine")]
        public class SpritesSheetContent
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>List that holds the sprites definitions contained in the SpritesSheet</summary>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            [ContentSerializer]
            public List<SpriteDefinition> spritesList;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>Texture that holds the different sprites graphics</summary>
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            [ContentSerializerIgnore]
            public Texture2DContent texture;
        }
    }
}
