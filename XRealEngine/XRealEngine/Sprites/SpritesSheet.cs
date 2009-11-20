﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework.Sprites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class manage a collection of sprites
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SpritesSheet: ISpritesSheet
    {
        public const string AssetTypeName = "SPRITES_SHEET";
        public const string ImporterName  = "SPRITES_SHEET";
        public const string ProcessorName = "SPRITES_SHEET";
        public const string Extension     = "xsp";

        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>List that holds the sprites definitions contained in the SpritesSheet</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializer]
        private List<SpriteDefinition> spritesList;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Texture that holds the different sprites graphics</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializerIgnore]
        Texture2D texture;

        [ContentSerializer]
        string textureAssetName;

       
        #endregion

        #region Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Texture that holds the different sprites graphics</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ContentSerializerIgnore]
        public Texture2D Texture
        {
            get { return texture; }
            set 
            { texture = value; 
              textureAssetName = value.Name;
            }
        }

        [ContentSerializerIgnore]
        public string TextureAssetName
        {
            get { return textureAssetName; }
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

        #region Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Add a new sprite definition to the spritesheet</summary>
        /// <param name="sprite">The new sprite definition to add</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddSpriteDefinition(SpriteDefinition sprite)
        {
            if (String.IsNullOrEmpty(sprite.Name)) sprite.Name = String.Format("Sprite_{0:D2}", spritesList.Count);
            spritesList.Add(sprite);
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

        public SpriteDefinition this[int index]
        {
            get
            {
                return spritesList[index];
            }
        }

        #endregion
    }
}
