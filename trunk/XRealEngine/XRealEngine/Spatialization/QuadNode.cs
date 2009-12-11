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

        bool IsLeaf
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
            this.elements.Add(element);

            if (!this.boundingBox.Contains(element.BoundingBox)) // <- Pas Bon
            {
                Subdivide();
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
    }
}
