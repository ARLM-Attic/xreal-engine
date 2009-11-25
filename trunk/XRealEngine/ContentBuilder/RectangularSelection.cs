using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework
{
    public class RectangularSelection
    {
        internal delegate void ActiveSelectionEventHandler(object sender, ActiveSelectionChangedEventArgs e);
        internal event ActiveSelectionEventHandler OnActiveChanged;

        Rectangle rectangle;
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set 
            {
                if (isActive != value)
                {
                    isActive = value;
                    ActiveSelectionChangedEventArgs e = new ActiveSelectionChangedEventArgs(!value, value);
                    OnActiveChanged(this, e);
                }
            }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public int Width
        {
            get {return rectangle.Width;}
            set { rectangle.Width = value; }
        }

        public int Height
        {
            get { return rectangle.Height; }
            set { rectangle.Height = value; }
        }

        public int X
        {
            get {return rectangle.X;}
            set { rectangle.X = value; }
        }

        public int Y
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }

        public int Right
        {
            get { return rectangle.Right; }
            set { rectangle.Width = value - rectangle.X; }
        }

        public int Bottom
        {
            get { return rectangle.Bottom; }
            set { rectangle.Height = value - rectangle.Y; }
        }

        public RectangularSelection(Rectangle rect)
        {
            rectangle = rect;
        }
    }
}
