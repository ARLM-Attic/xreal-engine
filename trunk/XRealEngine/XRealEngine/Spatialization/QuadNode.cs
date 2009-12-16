using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Spatialization
{
    public class QuadNode<T> where T : ISpatialElement
    {
        private const int TopLeft = 0;
        private const int TopRight = 1;
        private const int BottomLeft = 2;
        private const int BottomRight = 3;

        private List<T> elements;
        private QuadNode<T>[] childrenNodes;
        private Rectangle boundingBox;

        protected bool IsLeaf
        {
            get { return (childrenNodes == null); }
        }

        protected Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }
        
        protected QuadNode(Rectangle boundingBox)
        {
            this.elements = new List<T>();
            this.BoundingBox = boundingBox;
            this.childrenNodes = null;
        }

        public virtual void Add(T element)
        {
            int result = TestElement(element);

            if (result > 0)
            {
                if (this.IsLeaf) this.Subdivide();
                this.childrenNodes[result].Add(element);
            }
            else
            {
                this.elements.Add(element);
            }
        }

        protected int TestElement(T element)
        {
            Rectangle[] subRects = QuadNode<T>.GetSubRectangles(this.boundingBox);

            for (int i = QuadNode<T>.TopLeft; i <= BottomRight; i++)
            {
                if (subRects[i].Contains(element.BoundingBox)) return i;
            }

            return -1;
        }

        protected void Subdivide()
        {
            if (this.IsLeaf)
            {
                CreateChildrenNodes();
            }
        }

        protected void CreateChildrenNodes()
        {
            childrenNodes = new QuadNode<T>[4];
            childrenNodes[QuadNode<T>.TopLeft] = new QuadNode<T>(new Rectangle(this.boundingBox.Left, this.boundingBox.Top, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
            childrenNodes[QuadNode<T>.TopRight] = new QuadNode<T>(new Rectangle(this.boundingBox.Center.X, this.boundingBox.Top, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
            childrenNodes[QuadNode<T>.BottomRight] = new QuadNode<T>(new Rectangle(this.boundingBox.Center.X, this.boundingBox.Center.Y, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
            childrenNodes[QuadNode<T>.BottomLeft] = new QuadNode<T>(new Rectangle(this.boundingBox.Left, this.boundingBox.Center.Y, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
        }

        private static Rectangle[] GetSubRectangles(Rectangle rect)
        {
            Rectangle[] result = new Rectangle[4];
            int halfWidth =  rect.Width / 2;
            int halfHeight = rect.Height / 2;

            result[QuadNode<T>.TopLeft] = new Rectangle(rect.Left, rect.Top, halfWidth, halfHeight);
            result[QuadNode<T>.TopRight] = new Rectangle(rect.Center.X, rect.Top, halfWidth, halfHeight);
            result[QuadNode<T>.BottomLeft] = new Rectangle(rect.Left, rect.Center.Y, halfWidth, halfHeight);
            result[QuadNode<T>.BottomRight] = new Rectangle(rect.Center.X, rect.Center.Y, halfWidth, halfHeight);

            return result;
        }
    }
}
