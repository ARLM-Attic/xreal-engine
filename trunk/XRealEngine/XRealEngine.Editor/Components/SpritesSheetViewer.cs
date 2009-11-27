using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Windows.Winforms;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XRealEngine.Editor.Components
{
    public class SpritesSheetViewer : GraphicsDeviceControl
    {
        private SpritesSheet sheet;
        private SpriteBatch spriteBatch;

        public void SetSpritesSheet(SpritesSheet sheet)
        {
            this.sheet = sheet;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);
            DrawSpriteSheet();
        }

        private void DrawSpriteSheet()
        {
            if (sheet != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(sheet.Texture, Vector2.Zero, Color.White);
                spriteBatch.End();
            }
        }
    }
}
