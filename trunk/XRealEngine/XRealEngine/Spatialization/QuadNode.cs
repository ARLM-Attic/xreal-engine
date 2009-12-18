using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace XRealEngine.Framework.Spatialization
{
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    /// <summary>
    /// A QuadNode of a QuadTree object
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    public class QuadNode<T> where T : ISpatialElement
    {

        #region Constants

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Index of the top left QuadNode child</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private const int TopLeft = 0;
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Index of the top right QuadNode child</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private const int TopRight = 1;
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Index of the bottom left QuadNode child</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private const int BottomLeft = 2;
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Index of the bottom right QuadNode child</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private const int BottomRight = 3;

        #endregion

        #region Fields

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>List of elements directly contained in the QuadNodes</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private List<T> elements;
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Array containing the four QuadNode children of the QuadNode</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private QuadNode<T>[] childrenNodes;
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>BoundingBox of the QuadNode</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private Rectangle boundingBox;
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Parent QuadNode of the QuadNode</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private QuadNode<T> parentNode;

        #endregion

        #region Properties
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Is the QuadNode a leaf</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        protected bool IsLeaf
        {
            get { return (childrenNodes == null); }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Is the QuadNode the root</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        protected bool IsRoot
        {
            get { return (parentNode == null); }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Gets or sets the bounding box of the QuadNode</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
            protected set
            {
                if (boundingBox != value)
                {
                    boundingBox = value;
                    if (!this.IsLeaf)
                    {
                        InitializeChildrenNodesBoundingBoxes();
                    }

                    ReAffectElements();
                }
            }
        }

        #endregion

        #region Constructors

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Contruct a QuadNode
        /// </summary>
        /// <param name="parentNode">The parentNode containing this node</param>
        /// <param name="boundingBox">The BoudingBox of this node</param>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        protected QuadNode(QuadNode<T> parentNode, Rectangle boundingBox)
        {
            this.elements = new List<T>();
            this.BoundingBox = boundingBox;
            this.childrenNodes = null;
            this.parentNode = parentNode;
        }
        
        #endregion

        #region Methods

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Retrieves all the elements contained in the rectangle or which intersects with the rectangle
        /// </summary>
        /// <param name="rect">The rectangle to test</param>
        /// <param name="resultsList">The results list to which elements are added</param>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        protected void GetElements(ref Rectangle rect, List<T> resultsList)
        {
            bool result;

            for (int i = 0; i < this.elements.Count; i++)
            {
                this.elements[i].BoundingBox.Intersects(ref rect, out result);
                if (result) resultsList.Add(this.elements[i]);
            }

            if (!this.IsLeaf)
            {
                this.childrenNodes[TopLeft].BoundingBox.Intersects(ref rect, out result);
                if (result) this.childrenNodes[TopLeft].GetElements(ref rect, resultsList);
                this.childrenNodes[TopRight].BoundingBox.Intersects(ref rect, out result);
                if (result) this.childrenNodes[TopRight].GetElements(ref rect, resultsList);
                this.childrenNodes[BottomLeft].BoundingBox.Intersects(ref rect, out result);
                if (result) this.childrenNodes[BottomLeft].GetElements(ref rect, resultsList);
                this.childrenNodes[BottomRight].BoundingBox.Intersects(ref rect, out result);
                if (result) this.childrenNodes[BottomRight].GetElements(ref rect, resultsList);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Add a new element in the QuadNode
        /// </summary>
        /// <param name="element">The element to be added to the QuadNode</param>
        /// <remarks>Depending on the QuandNode BoundingBox and the element BoundingBox, the element can be added directly in the QuadNode or in its children</remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public virtual void Add(T element)
        {
            int result = TestElement(element);

            if (result >= 0)
            {
                if (this.IsLeaf) this.Subdivide();
                this.childrenNodes[result].Add(element);
            }
            else
            {
                if (this.boundingBox.Contains(element.BoundingBox))
                {
                    element.Moved += element_Moved;
                    this.elements.Add(element);
                }
                else
                {
                    throw new ArgumentException("The element is bigger than this QuadNode", "element");
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Compute and affect the BoundingBoxes of QuadNode's children
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private void InitializeChildrenNodesBoundingBoxes()
        {
            if (!this.IsLeaf)
            {
                Rectangle[] subRects = QuadNode<T>.GetSubRectangles(this.boundingBox);
                childrenNodes[QuadNode<T>.TopLeft].BoundingBox = subRects[QuadNode<T>.TopLeft];
                childrenNodes[QuadNode<T>.TopRight].BoundingBox = subRects[QuadNode<T>.TopRight];
                childrenNodes[QuadNode<T>.BottomLeft].BoundingBox = subRects[QuadNode<T>.BottomLeft];
                childrenNodes[QuadNode<T>.BottomRight].BoundingBox = subRects[QuadNode<T>.BottomRight];
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Analyze the elements directly attached to the QuadNode and moves the elements to the children or parents QuadNode
        /// </summary>
        /// <remarks>Typically this method is invoked where the BoundingBox of the quadNode is changed</remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private void ReAffectElements()
        {
            if (elements.Count > 0)
            {
                
                T[] tempElementsList = this.elements.ToArray();
                this.elements.Clear();

                for (int i = 0; i < tempElementsList.Length; i++)
                {
                    if (this.boundingBox.Contains(tempElementsList[i].BoundingBox))
                    {
                        this.Add(tempElementsList[i]);
                    }
                    else
                    {
                        this.parentNode.Add(tempElementsList[i]);
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Create the 4 QuadNode's children if they doesn't exists
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        protected void Subdivide()
        {
            if (this.IsLeaf)
            {
                childrenNodes = new QuadNode<T>[4];
                childrenNodes[TopLeft] = new QuadNode<T>(this, Rectangle.Empty);
                childrenNodes[TopRight] = new QuadNode<T>(this, Rectangle.Empty);
                childrenNodes[BottomLeft] = new QuadNode<T>(this, Rectangle.Empty);
                childrenNodes[BottomRight] = new QuadNode<T>(this, Rectangle.Empty);
                InitializeChildrenNodesBoundingBoxes();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Return to which QuadNode an element should be affected
        /// </summary>
        /// <returns>
        ///     - 1 : The QuadNode itself
        ///     1 : The Top Left QuadNode's child 
        ///     2 : The Top Right QuadNode's child
        ///     3 : The Bottom Left QuadNode's child
        ///     4 : The Bottom Right QuadNode's child
        /// </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        protected int TestElement(T element)
        {
            Rectangle[] subRects = QuadNode<T>.GetSubRectangles(this.boundingBox);

            for (int i = QuadNode<T>.TopLeft; i <= BottomRight; i++)
            {
                if (subRects[i].Contains(element.BoundingBox)) return i;
            }

            return -1;
        }
        
        #endregion

        #region Implemented Events

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// This method is called when a element attached to the QuadNode is moved.
        /// When moved, the element sould be moved to a children or a parent QuadNode
        /// </summary>
        /// <param name="e">An empty event arg</param>
        /// <param name="sender">The element which raised the event</param>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
   
        private void element_Moved(object sender, EventArgs e)
        {
            T element = (T)sender;
            if (!this.boundingBox.Contains(element.BoundingBox))
            {
                this.elements.Remove(element);
                element.Moved -= element_Moved;
                this.parentNode.Add(element);
            }
            else
            {
                int subrect = TestElement(element);
                if (subrect >= 0)
                {
                    this.elements.Remove(element);
                    element.Moved -= new EventHandler(element_Moved);
                    this.childrenNodes[subrect].Add(element);
                }
            }
        }

        #endregion

        #region Static Methods

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Compute the 4 children rectangle of a rectangle.
        /// The rectangle is splitted in 4 which is center as pivot
        /// </summary>
        /// <param name="rect">The rectangle to be splitted</param>
        /// <remarks>The rectangle splitted if 4 rectangles</remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
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

        #endregion
    }
}
