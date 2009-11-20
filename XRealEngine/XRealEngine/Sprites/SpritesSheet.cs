using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework.Sprites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class manage a collection of sprites definitions
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SpritesSheet: ISpritesSheet, ICollection<SpriteDefinition>
    {
        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>List that holds the sprites definitions contained in the SpritesSheet</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializer]
        private List<SpriteDefinition> spritesList;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Texture that holds the different sprites graphics</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializer]
        Texture2D texture;

        #endregion

        #region Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Texture that holds the different sprites graphics</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializerIgnore]
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value;}
        }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The standard constructor</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SpritesSheet()
        {
            spritesList = new List<SpriteDefinition>();
        }

        #endregion

        #region Indexers

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the desired sprite definition
        /// </summary>
        /// <param name="spriteName">the name of the sprite definition to retrieve</param>
        /// <returns>The desired sprite definition</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SpriteDefinition this[string spriteName]
        {
            get
            {
                for (int i = 0; i < spritesList.Count; i++)
                {
                    if (spritesList[i].Name == spriteName) return spritesList[i];
                }
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the desired sprite definition
        /// </summary>
        /// <param name="index">Index of the sprite to retreive</param>
        /// <returns>The desired sprite definition</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SpriteDefinition this[int index]
        {
            get
            {
                return spritesList[index];
            }
        }

        #endregion

        #region ICollection<SpriteDefinition> Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Add a new sprite definition to the spritesheet</summary>
        /// <param name="sprite">The new sprite definition to add</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Add(SpriteDefinition sprite)
        {
            if (String.IsNullOrEmpty(sprite.Name)) sprite.Name = String.Format("Sprite_{0:D2}", spritesList.Count);
            spritesList.Add(sprite);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Remove all sprites definitions from the spritesheet</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Clear()
        {
            spritesList.Clear();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Check if the sprites sheet contains de desired sprite</summary>
        /// <param name="sprite">The new sprite definition to check</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Contains(SpriteDefinition sprite)
        {
            return spritesList.Contains(sprite);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Copy the sprites definition to an array
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The first index to begin the copy</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CopyTo(SpriteDefinition[] array, int arrayIndex)
        {
            spritesList.CopyTo(array, arrayIndex);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Return the count of sprites in the sprites sheet</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializerIgnore]
        public int Count
        {
            get { return spritesList.Count; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets the read only state of the sprites sheet
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializerIgnore]
        public bool IsReadOnly
        {
            get { return false; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Remove a sprite from the sprites sheet
        /// </summary>
        /// <param name="sprite">The sprite to remove</param>
        /// <returns>true is the operation is succesful</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Remove(SpriteDefinition sprite)
        {
            return spritesList.Remove(sprite);
        }

        #endregion

        #region IEnumerable<SpriteDefinition> Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return an enumerator that iterate though the collection of sprites
        /// </summary>
        /// <returns>An enumerator of the collection</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public IEnumerator<SpriteDefinition> GetEnumerator()
        {
            return spritesList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return an enumerator that iterate though the collection of sprites
        /// </summary>
        /// <returns>An enumerator of the collection</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return spritesList.GetEnumerator();
        }

        #endregion
    }
}
