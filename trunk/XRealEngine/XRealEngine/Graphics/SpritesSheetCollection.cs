using System;
using System.Collections.Generic;
using System.Text;

namespace XRealEngine.Framework.Graphics
{
    internal class SpritesSheetCollection
    {
        private List<ISpritesSheet> indexedCollection;
        private Dictionary<string, ISpritesSheet> namedCollection;

        internal SpritesSheetCollection()
        {
            namedCollection = new Dictionary<string, ISpritesSheet>();
            indexedCollection = new List<ISpritesSheet>();
        }

        internal void Add(string spritesSheetName, ISpritesSheet spritesSheet)
        {
            namedCollection.Add(spritesSheetName, spritesSheet);
            indexedCollection.Add(spritesSheet);
        }

        ISpritesSheet this[int index]
        {
            get { return indexedCollection[index]; }
        }

        ISpritesSheet this[string spritesSheetName]
        {
            get { return namedCollection[spritesSheetName]; }
        }

    }
}
