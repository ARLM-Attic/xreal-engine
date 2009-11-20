using System.Collections.Generic;

namespace XRealEngine.Framework.Sprites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Define a collection of different SpriteDefinition
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface ISpritesSheet : ICollection<SpriteDefinition>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the desired sprite definition
        /// </summary>
        /// <param name="spriteName">the name of the sprite definition to retrieve</param>
        /// <returns>The desired sprite definition</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        SpriteDefinition this[string spriteName]
        {
            get;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the desired sprite definition
        /// </summary>
        /// <param name="index">Index of the sprite to retreive</param>
        /// <returns>The desired sprite definition</returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        SpriteDefinition this[int index]
        {
            get;
        }
    }
}
