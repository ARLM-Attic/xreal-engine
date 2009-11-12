using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework
{
    public class SelectionsManager
    {
        #region Fields

        PrimitiveBatch drawingBatch;
        List<RectangularSelection> selections;
        
        #endregion

        #region Constructor

        public SelectionsManager(GraphicsDevice graphicsDeviceService)
        {
            drawingBatch = new PrimitiveBatch(graphicsDeviceService);
            selections = new List<RectangularSelection>();
        }

        #endregion

        #region Methods

        public void AddSelection(RectangularSelection selection)
        {
            selections.Add(selection);
        }

        public void Draw()
        {
            Color color;

            drawingBatch.Begin(PrimitiveType.LineList);
            
            foreach (RectangularSelection selection in selections)
            {
                if (selection.IsActive)
                {
                    color = Color.DarkGreen;
                }
                else
                {
                    color = Color.Green;
                }

                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Left, selection.Rectangle.Top), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Right, selection.Rectangle.Top), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Right, selection.Rectangle.Top), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Right, selection.Rectangle.Bottom), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Right, selection.Rectangle.Bottom), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Left, selection.Rectangle.Bottom), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Left, selection.Rectangle.Bottom), color);
                drawingBatch.AddVertex(new Vector2(selection.Rectangle.Left, selection.Rectangle.Top), color);

            }

            drawingBatch.End();
        }
        
        #endregion
    }
}
