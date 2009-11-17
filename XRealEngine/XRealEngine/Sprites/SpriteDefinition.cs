﻿using Microsoft.Xna.Framework;
using XRealEngine.Framework;
using Microsoft.Xna.Framework.Content;

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
        [ContentSerializer]
        private string name;

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>The boundaries of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializer]
        private Rectangle rectangle;
        
        #endregion

        #region Properties

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the name of the sprite</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
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

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the boundaries of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public  Rectangle Rectangle 
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the width of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public int Width
        {
            get { return rectangle.Width; }
            set { rectangle.Width = value; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the height of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public int Height
        {
            get { return rectangle.Height; }
            set { rectangle.Height = value; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the position (X coordinates) of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public int X
        {
            get { return rectangle.X; }
            set { rectangle.X = value; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the position (Y coordinates) of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public int Y
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the right coordinate of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public int Right
        {
            get { return rectangle.Right; }
            set { rectangle.Width = value - rectangle.X; }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets / Sets the bottom coordinate of the sprite in the sprites sheet</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        [ContentSerializerIgnore]
        public int Bottom
        {
            get { return rectangle.Bottom; }
            set { rectangle.Height = value - rectangle.Y; }
        }

        #endregion

        #region Contructor

        public SpriteDefinition(string name, Rectangle rect)
        {
            this.name = name;
            this.rectangle = rect;
        }

        #endregion
    }
}
