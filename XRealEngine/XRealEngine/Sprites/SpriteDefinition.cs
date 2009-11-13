using Microsoft.Xna.Framework;
using XRealEngine.Framework;

namespace XRealEngine.Framework.Sprites
{
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    /// <summary>
    /// The definition of a sprite
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    public class SpriteDefinition
    {
        internal delegate void NameChangedEventHandler(object sender, NameChangedEventArgs e);

        internal event NameChangedEventHandler OnNameChanged;

        #region Fields

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>The name of the sprite</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private string name;

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>The boundaries of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private Rectangle rectangle;

        #endregion

        #region Properties

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the name of the sprite</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public string Name
        {
            get 
            { 
                return name; 
            }
            internal set 
            {
                if (name != value)
                {
                    string oldName = name;
                    name = value;
                    NameChangedEventArgs e = new NameChangedEventArgs(oldName, name);
                    OnNameChanged(this, e);
                }
            }
        }

        #endregion
    }
}
