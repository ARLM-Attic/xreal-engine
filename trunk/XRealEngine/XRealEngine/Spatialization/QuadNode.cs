using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Spatialization
{
    class QuadNode
    {
        private const int TopLeft = 0;
        private const int TopRight = 1;
        private const int BottomLeft = 2;
        private const int BottomRight = 3;

        private List<ISpatialElement> elements;
        private QuadNode[] childrenNodes;
        private Rectangle boundingBox;

        private bool IsLeaf
        {
            get { return (childrenNodes == null); }
        }

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }
        
        QuadNode(Rectangle boundingBox)
        {
            this.elements = new List<ISpatialElement>();
            this.BoundingBox = boundingBox;
            this.childrenNodes = null;
        }

        void Add(ISpatialElement element)
        {
            Rectangle[] subRects = QuadNode.GetSubRectangles(this.boundingBox);
            int result = -1;

            for (int i = QuadNode.TopLeft; i <= BottomRight; i++)
            {
                if (subRects[i].Contains(element.BoundingBox))
                {
                    result = i;
                }
            }

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

        private void Subdivide()
        {
            if (this.IsLeaf)
            {
                CreateChildrenNodes();
            }
        }

        private void CreateChildrenNodes()
        {
            childrenNodes = new QuadNode[4];
            childrenNodes[QuadNode.TopLeft] = new QuadNode(new Rectangle(this.boundingBox.Left, this.boundingBox.Top, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
            childrenNodes[QuadNode.TopRight] = new QuadNode(new Rectangle(this.boundingBox.Center.X, this.boundingBox.Top, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
            childrenNodes[QuadNode.BottomRight] = new QuadNode(new Rectangle(this.boundingBox.Center.X, this.boundingBox.Center.Y, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
            childrenNodes[QuadNode.BottomLeft] = new QuadNode(new Rectangle(this.boundingBox.Left, this.boundingBox.Center.Y, this.boundingBox.Width / 2, this.boundingBox.Height / 2));
        }

        private static Rectangle[] GetSubRectangles(Rectangle rect)
        {
            Rectangle[] result = new Rectangle[4];
            int halfWidth =  rect.Width / 2;
            int halfHeight = rect.Height / 2;

            result[QuadNode.TopLeft] = new Rectangle(rect.Left, rect.Top, halfWidth, halfHeight);
            result[QuadNode.TopRight] = new Rectangle(rect.Center.X, rect.Top, halfWidth, halfHeight);
            result[QuadNode.BottomLeft] = new Rectangle(rect.Left, rect.Center.Y, halfWidth, halfHeight);
            result[QuadNode.BottomRight] = new Rectangle(rect.Center.X, rect.Center.Y, halfWidth, halfHeight);

            return result;
        }
    }
}
