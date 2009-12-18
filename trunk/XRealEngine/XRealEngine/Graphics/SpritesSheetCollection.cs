﻿using System.Collections.Generic;

namespace XRealEngine.Framework.Graphics
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Manage a collection of sprites sheets
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SpritesSheetCollection
    {
        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The sprites sheet list</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private List<ISpritesSheet> indexedCollection;

        #endregion

        #region Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the number of sprites sheets in the collection
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int Count
        {
            get { return this.indexedCollection.Count; }
        }

        #endregion

        #region Constructors

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a new collection of sprites sheets
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SpritesSheetCollection()
        {
            indexedCollection = new List<ISpritesSheet>();
        }

        #endregion

        #region Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Add a new sprites sheet in the collection
        /// </summary>
        /// <param name="spritesSheet">The new sprites sheets to be added</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Add(ISpritesSheet spritesSheet)
        {
            indexedCollection.Add(spritesSheet);
        }

        #endregion

        #region Indexer

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the desired sprites sheet
        /// </summary>
        /// <param name="index">Index of the sprites sheet to be retreived</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ISpritesSheet this[int index]
        {
            get { return indexedCollection[index]; }
        }

        #endregion
    }
}
