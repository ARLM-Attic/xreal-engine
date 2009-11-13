﻿using System;
using System.Collections.Generic;

namespace XRealEngine.Framework.Sprites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class manage a collection of sprites
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class SpritesSheet:ISpritesSheet
    {
        #region Fields

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>List that holds the sprites definitions contained in the SpritesSheet</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private List<SpriteDefinition> spritesList;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Dictionary that holds the sprites definitions contained in the SpritesSheet</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private Dictionary<String, SpriteDefinition> spritesDictionnary;

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The standard constructor</summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public SpritesSheet()
        {
            spritesList = new List<SpriteDefinition>();
            spritesDictionnary = new Dictionary<string, SpriteDefinition>();
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

            sprite.OnNameChanged += new SpriteDefinition.NameChangedEventHandler(sprite_OnNameChanged);

            spritesList.Add(sprite);
            spritesDictionnary.Add(sprite.Name, sprite);
        }

        private void sprite_OnNameChanged(object sender, NameChangedEventArgs e)
        {
            spritesDictionnary.Remove(e.OldName);
            spritesDictionnary.Add(e.NewName, (SpriteDefinition)sender);
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
                return spritesDictionnary[spriteName];
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
