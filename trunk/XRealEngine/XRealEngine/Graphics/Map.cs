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
        private SpritesSheetCollection spritesSheets;

        public Map()
        {
            spritesSheets = new SpritesSheetCollection();
        }

        public void AddSpritesSheet(string spritesSheetName, ISpritesSheet spritesSheet)
        {
            spritesSheets.Add(spritesSheetName, spritesSheet);
        }
    }
}
