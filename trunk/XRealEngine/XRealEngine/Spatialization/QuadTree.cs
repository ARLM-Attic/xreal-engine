using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Spatialization
{
    public class QuadTree<T>:QuadNode<T> where T:ISpatialElement
    {
        public QuadTree():base(null, Rectangle.Empty)
        {
        }

        public override void Add(T element)
        {
            if (!this.BoundingBox.Contains(element.BoundingBox))
            {
                this.BoundingBox = Rectangle.Union(this.BoundingBox, element.BoundingBox);
            }
            
            base.Add(element);
        }
    }
}
