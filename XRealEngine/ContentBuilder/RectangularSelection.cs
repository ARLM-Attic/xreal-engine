using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework
{
    public class RectangularSelection
    {
        Rectangle rectangle;
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public RectangularSelection(Rectangle rect)
        {
            rectangle = rect;
        }
    }
}
