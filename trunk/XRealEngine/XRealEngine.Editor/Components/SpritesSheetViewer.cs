using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRealEngine.Windows;
using XRealEngine.Windows.Winforms;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace XRealEngine.Editor.Components
{
    public class SpriteEventArgs : EventArgs
    {
        public SpriteDefinition Sprite;

        public SpriteEventArgs(SpriteDefinition sprite)
        {
            Sprite = sprite;
        }
    }

    public class SpritesSheetViewer : GraphicsDeviceControl
    {
        public delegate void SpriteEventHandler (Object sender, SpriteEventArgs e);
        public event SpriteEventHandler SelectedSpriteChanged;
        public event SpriteEventHandler OperationComplete;

        enum PointPosition
        {
            TopLeft,
            Top,
            TopRight,
            Right,
            BottomRight,
            Bottom,
            BottomLeft,
            Left,
            Inside,
            Outside
        }

        enum Operation
        {
            None,
            Move
        }

        private const int BORDER_GRAB_SIZE = 5;
        private const int BORDER_GRAB_TOTAL = 5;

        private SpritesSheet sheet;
        private SpriteBatch spriteBatch;
        private PrimitiveBatch primitiveBatch;
        private SpriteDefinition selectedSprite;
        private Point offsetPoint;
        private Operation operation;

        public SpriteDefinition SelectedSprite
        {
            get { return selectedSprite; }
            set 
            {
                if (value != selectedSprite)
                {
                    selectedSprite = value;
                    this.Refresh();
                    this.SelectedSpriteChanged(this, new SpriteEventArgs(value));
                }

            }
        }

        public SpritesSheet SpritesSheet
        {
            get {return this.sheet;}
            set 
            { 
                this.sheet = value;
                this.Refresh();
            }
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            primitiveBatch = new PrimitiveBatch(this.GraphicsDevice);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);
            DrawSpriteSheet();
            DrawSpritesRect();
        }

        private void DrawSpriteSheet()
        {
            if ((sheet != null)&&(sheet.Texture != null))
            {
                spriteBatch.Begin();
                spriteBatch.Draw(sheet.Texture, Vector2.Zero, Color.White);
                spriteBatch.End();
            }
        }

        private void DrawSpritesRect()
        {
            if ((sheet != null))
            {
                primitiveBatch.Begin(PrimitiveType.LineList);

                foreach(SpriteDefinition sprite in sheet)
                {
                    if (SelectedSprite != sprite)
                        primitiveBatch.AddRect(sprite.Rectangle, Color.DarkGreen);
                }

                if (SelectedSprite != null)
                    primitiveBatch.AddRect(SelectedSprite.Rectangle, Color.LightGreen);

                primitiveBatch.End();
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            
            if (sheet != null)
            {
                SpriteDefinition sprite = GetSpriteFromMousePoint(e.X, e.Y);
                if (sprite != null)
                {
                    PointPosition position = GetMousePosition(sprite.Rectangle, e.X, e.Y);
                    this.Cursor = GetMouseCursor(position);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }

                if (e.Button == MouseButtons.Left)
                {
                    ApplyOperation(e.X, e.Y);
                }
            }

            
            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (sheet != null)
            {
                SpriteDefinition sprite = GetSpriteFromMousePoint(e.X, e.Y);

                if (sprite != null)
                {
                    PointPosition position = GetMousePosition(sprite.Rectangle, e.X, e.Y);
                    if (position != PointPosition.Outside)
                    {
                        this.SelectedSprite = sprite;
                        offsetPoint.X = e.X - sprite.Rectangle.X;
                        offsetPoint.Y = e.Y - sprite.Rectangle.Y;
                        operation = GetOperation(position);
                    }
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            operation = Operation.None;
        }

        private PointPosition GetMousePosition(Rectangle rect, int x, int y)
        {
            if (rect.Contains(x, y))
            {
                if ((rect.X < x) && (rect.X + BORDER_GRAB_TOTAL > x))
                {
                    if ((rect.Y < y) && (rect.Y + BORDER_GRAB_TOTAL > y)) return PointPosition.TopLeft;
                    if ((rect.Bottom > y) && (rect.Bottom - BORDER_GRAB_TOTAL < y)) return PointPosition.BottomLeft;
                    return PointPosition.Left;
                }
                else
                {
                    if ((rect.Right > x) && (rect.Right - BORDER_GRAB_TOTAL < x))
                    {
                        if ((rect.Y < y) && (rect.Y + BORDER_GRAB_TOTAL > y)) return PointPosition.TopRight;
                        if ((rect.Bottom > y) && (rect.Bottom - BORDER_GRAB_TOTAL < y)) return PointPosition.BottomRight;
                        return PointPosition.Right;
                    }
                    else
                    {
                        if ((rect.Y < y) && (rect.Y + BORDER_GRAB_TOTAL > y)) return PointPosition.Top;
                        if ((rect.Bottom > y) && (rect.Bottom - BORDER_GRAB_TOTAL < y)) return PointPosition.Bottom;
                    }
                }

                return PointPosition.Inside;
            }
            else
            {
                return PointPosition.Outside;
            }
        }

        private Cursor GetMouseCursor(PointPosition position)
        {
            switch(position)
            {
                case PointPosition.Top:
                case PointPosition.Bottom:
                    return Cursors.SizeNS;
                case PointPosition.Left:
                case PointPosition.Right:
                    return Cursors.SizeWE;
                case PointPosition.BottomLeft:
                case PointPosition.TopRight:
                    return Cursors.SizeNESW;
                case PointPosition.BottomRight:
                case PointPosition.TopLeft:
                    return Cursors.SizeNWSE;
                case PointPosition.Inside:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;

            }
        }

        private Operation GetOperation(PointPosition position)
        {
            switch (position)
            {
                case PointPosition.Inside:
                    return Operation.Move;
                default:
                    return Operation.None;
            }
        }

        private SpriteDefinition GetSpriteFromMousePoint(int x, int y)
        {
            if (this.selectedSprite != null)
            {
                if (this.selectedSprite.Rectangle.Contains(x, y))
                {
                    return this.selectedSprite;
                }
            }

            foreach(SpriteDefinition sprite in this.SpritesSheet)
            {
                if (sprite.Rectangle.Contains(x, y))
                {
                    return sprite;
                }
            }

            return null;
        }

        private void ApplyOperation(int x, int y)
        {
            switch (operation)
            {
                case Operation.Move:
                    this.selectedSprite.X = x - offsetPoint.X;
                    this.selectedSprite.Y = y - offsetPoint.Y;
                    break;
            }
            this.OperationComplete(this, new SpriteEventArgs(this.selectedSprite));
            this.Refresh();
        }
    }
}
