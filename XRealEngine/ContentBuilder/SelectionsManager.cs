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
        private enum COMMAND_MODE
        {
            NONE,
            CREATE,
            MOVE
        }

        private const int BORDER_LIMIT = 3;

        #region Fields

        PrimitiveBatch drawingBatch;
        List<RectangularSelection> selections;
        RectangularSelection activeSelection;
        COMMAND_MODE command;
        int offsetX;
        int offsetY;
        #endregion

        #region Properties

        public RectangularSelection ActiveSelection
        {
            get { return activeSelection; }
            set 
            { 
                if (activeSelection != value)
                {
                    activeSelection = value;
                    if (activeSelection != null) activeSelection.IsActive = true;

                    foreach (RectangularSelection selection in selections)
                    {
                        if (activeSelection != selection) selection.IsActive = false;
                    }                    
                }
            }
        }

        #endregion

        #region Constructor

        public SelectionsManager(GraphicsDevice graphicsDeviceService)
        {
            drawingBatch = new PrimitiveBatch(graphicsDeviceService);
            selections = new List<RectangularSelection>();
            command = COMMAND_MODE.NONE;
        }

        #endregion

        #region Methods

        public void AddSelection(RectangularSelection selection)
        {
            selections.Add(selection);
            selection.OnActiveChanged += new RectangularSelection.ActiveSelectionEventHandler(selection_OnActiveChanged);
        }

        void selection_OnActiveChanged(object sender, ActiveSelectionChangedEventArgs e)
        {
            if (e.NewValue)
            {
                this.ActiveSelection = (RectangularSelection)sender;
            }
        }

        public RectangularSelection GetSelectionFromPoint(int X, int Y)
        {
            foreach (RectangularSelection selection in selections)
            {
                if ((X >= selection.Rectangle.X) &&
                    (X <= selection.Rectangle.Right) &&
                    (Y >= selection.Rectangle.Top) &&
                    (Y <= selection.Rectangle.Bottom))
                        return selection;
            }

            return null;
        }

        public RectangularSelection SetActiveSelectionFromPoint(int X, int Y)
        {
            RectangularSelection selection = GetSelectionFromPoint(X, Y);
            this.ActiveSelection = selection;
            return selection;
        }

        public void Draw()
        {
            Color color;

            drawingBatch.Begin(PrimitiveType.LineList);
            
            foreach (RectangularSelection selection in selections)
            {
                if (selection.IsActive)
                {
                    color = Color.LightGreen;
                }
                else
                {
                    color = Color.DarkGreen;
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

        public void BeginNewSelection(int X, int Y)
        {
            RectangularSelection selection = GetSelectionFromPoint(X, Y);

            if (selection == null)
            {
                command = COMMAND_MODE.CREATE;
                selection = new RectangularSelection(new Rectangle(X, Y, 0, 0));
                this.AddSelection(selection);
            }
            else
            {
                if ((X > selection.X + BORDER_LIMIT) && (X < selection.Right - BORDER_LIMIT) && (Y > selection.Y + BORDER_LIMIT) && (Y < selection.Bottom - BORDER_LIMIT))
                {
                    command = COMMAND_MODE.MOVE;
                    offsetX = X - selection.X;
                    offsetY = Y - selection.Y;
                }
                else
                {
                    selection = null;
                }
            }

            this.ActiveSelection = selection;
        }

        public void UpdateNewSelection(int X, int Y)
        {
            switch (command)
            {
                case COMMAND_MODE.CREATE:
                    ActiveSelection.Width = X - ActiveSelection.X;
                    ActiveSelection.Height = Y - ActiveSelection.Y;
                    break; 

                case COMMAND_MODE.MOVE:
                    ActiveSelection.X = X - offsetX;
                    ActiveSelection.Y = Y - offsetY;
                    break;
            }
        }

        public void EndNewSelection(int X, int Y)
        {
            switch (command)
            {
                case COMMAND_MODE.CREATE:
                    if ((ActiveSelection.Width == 0) || (ActiveSelection.Height == 0))
                    {
  
                    }
                    break;
                default:
                    
                    break;
            }

            command = COMMAND_MODE.NONE;
        }

        #endregion
    }
}
