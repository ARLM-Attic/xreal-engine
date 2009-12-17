using System;
using System.Collections.Generic;
using System.Text;

namespace XRealEngine.Framework.Graphics
{
    public class SpritesSheetCollection
    {
        private List<ISpritesSheet> indexedCollection;
        private Dictionary<string, ISpritesSheet> namedCollection;

        public SpritesSheetCollection()
        {
            namedCollection = new Dictionary<string, ISpritesSheet>();
            indexedCollection = new List<ISpritesSheet>();
        }

        public void Add(string spritesSheetName, ISpritesSheet spritesSheet)
        {
            namedCollection.Add(spritesSheetName, spritesSheet);
            indexedCollection.Add(spritesSheet);
        }

        public ISpritesSheet this[int index]
        {
            get { return indexedCollection[index]; }
        }

        public ISpritesSheet this[string spritesSheetName]
        {
            get { return namedCollection[spritesSheetName]; }
        }

    }
}
