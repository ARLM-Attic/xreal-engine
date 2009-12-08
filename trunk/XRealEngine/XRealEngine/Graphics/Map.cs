using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Graphics
{
    public class Map
    {
        private SpritesSheet spritesSheet;
        private MapSegmentsCollection segments;
        private List<MapLayer> layers;

        public Map()
        {
            segments = new MapSegmentsCollection();
            layers = new List<MapLayer>();
        }

        private void DrawLayer(SpriteBatch spriteBatch, int layerIndex, Vector2 scroll)
        {
            float scale = this.layers[layerIndex].Scale;
            Color color = this.layers[layerIndex].Color;
            Rectangle srcRect;
            Rectangle destRect;

            for (int i = 0; i < this.segments.GetSegmentsCount(layerIndex); i++)
            {
                srcRect = this.spritesSheet[this.segments[layerIndex, i].SpriteSheetIndex].Rectangle;
                destRect.X = (int)(segments[layerIndex, i].Location.X - scroll.X * scale);
                destRect.Y = (int)(segments[layerIndex, i].Location.Y - scroll.Y * scale);
                destRect.Width = (int)(srcRect.Width * scale);
                destRect.Height = (int)(srcRect.Height * scale);

                spriteBatch.Draw(spritesSheet.Texture, destRect, srcRect, color);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 scroll)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            
            for (int i = 0; i < this.layers.Count; i++)
            {
                DrawLayer(spriteBatch, i, scroll);
            }
            
            spriteBatch.End();
        }
    }
}
