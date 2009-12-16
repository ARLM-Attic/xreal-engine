using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Spatialization
{
    public class QuadTree<T>:QuadNode<T> where T:ISpatialElement
    {
        public QuadTree():base(Rectangle.Empty)
        {
        }

        public override void Add(T element)
        {
            if (this.BoundingBox.Contains(element.BoundingBox))
            {
                base.Add(element);
            }
            else
            {
                this.BoundingBox = GetUnion(this.BoundingBox, element.BoundingBox);
            }
        }

        private static Rectangle GetUnion(Rectangle rect1, Rectangle rect2)
        {
            Rectangle result = rect1;

            if (result.X < rect2.X) result.X = rect2.X;
            if (result.Y < rect2.Y) result.Y = rect2.Y;
            if (result.Right < rect2.Right) result.Width = rect2.Right - result.X;
            if (result.Bottom < rect2.Bottom) result.Height = rect2.Bottom - result.Y;

            return result;
        }
    }
}
