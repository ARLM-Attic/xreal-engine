using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace XRealEngine.Framework.Spatialization
{
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    /// <summary>
    /// A quadtree container supporting moving objects and resizing spacial area
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    public class QuadTree<T>:QuadNode<T> where T:ISpatialElement
    {
        #region Fields
        
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Holds the result of querying the quadtree</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private List<T> resultsList;
        
        #endregion

        #region Constructors

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Create a new empty quadtree
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public QuadTree():base(null, Rectangle.Empty)
        {
            resultsList = new List<T>();
        }

        #endregion

        #region Methods

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Add a new element in the quadtree
        /// </summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public override void Add(T element)
        {
            if (!this.BoundingBox.Contains(element.BoundingBox))
            {
                this.BoundingBox = Rectangle.Union(this.BoundingBox, element.BoundingBox);
            }
            
            base.Add(element);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// Retrieves all the elements contained in the rectangle or which intersects with the rectangle
        /// </summary>
        /// <param name="rect">The rectangle to test</param>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public List<T> GetElements(Rectangle rect)
        {
            resultsList.Clear();
            this.GetElements(ref rect, resultsList);
            return resultsList;
        }

        #endregion
    }
}
