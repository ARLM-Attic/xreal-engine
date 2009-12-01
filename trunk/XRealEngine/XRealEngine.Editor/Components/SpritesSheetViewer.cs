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
    public class SpritesSheetViewer : GraphicsDeviceControl
    {
        public delegate void SpriteEventHandler (Object sender, SpriteEventArgs e);
        public event SpriteEventHandler SelectedSpriteChanged;

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
            Move,
            ResizeLeft,
            ResizeTop,
            ResizeBottom,
            ResizeRight,
            ResizeTopLeft,
            ResizeTopRight,
            ResizeBottomLeft,
            ResizeBottomRight
        }

        private const int BORDER_GRAB_SIZE = 4;
        private const int BORDER_GRAB_TOTAL = 8;

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
                if (operation == Operation.None)
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
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        DoOperation(e.X, e.Y);
                    }
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
                        BeginOperation(e.X, e.Y);
                    }
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            EndOperation();
        }

        private PointPosition GetMousePosition(Rectangle rect, int x, int y)
        {
            rect.Inflate(BORDER_GRAB_SIZE, BORDER_GRAB_SIZE);
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
                case PointPosition.Left:
                    return Operation.ResizeLeft;
                case PointPosition.Top:
                    return Operation.ResizeTop;
                case PointPosition.Right:
                    return Operation.ResizeRight;
                case PointPosition.Bottom:
                    return Operation.ResizeBottom;
                case PointPosition.TopLeft:
                    return Operation.ResizeTopLeft;
                case PointPosition.TopRight:
                    return Operation.ResizeTopRight;
                case PointPosition.BottomRight:
                    return Operation.ResizeBottomRight;
                case PointPosition.BottomLeft:
                    return Operation.ResizeBottomLeft;
                default:
                    return Operation.None;
            }
        }

        private void BeginOperation(int x, int y)
        {
            PointPosition position = GetMousePosition(this.selectedSprite.Rectangle, x, y);
            operation = GetOperation(position);

            switch (operation)
            {
                case Operation.Move:
                case Operation.ResizeLeft:
                case Operation.ResizeTop:
                case Operation.ResizeTopLeft:
                    offsetPoint = new Point(x - selectedSprite.X, y - selectedSprite.Y);
                    break;
                case Operation.ResizeRight:
                case Operation.ResizeBottom:
                case Operation.ResizeBottomRight:
                    offsetPoint = new Point(x - selectedSprite.Right, selectedSprite.Bottom - y);
                    break;
                case Operation.ResizeTopRight:
                    offsetPoint = new Point(x - selectedSprite.Right, y - selectedSprite.Y);
                    break;
                case Operation.ResizeBottomLeft:
                    offsetPoint = new Point(x - selectedSprite.X, selectedSprite.Bottom - y);
                    break;
            }
        }

        private void DoOperation(int x, int y)
        {
            int diffX = this.selectedSprite.X - (x - offsetPoint.X);
            int diffY = this.selectedSprite.Y - (y - offsetPoint.Y);

            switch (operation)
            {
                case Operation.Move:
                    this.selectedSprite.X = x - offsetPoint.X;
                    this.selectedSprite.Y = y - offsetPoint.Y;
                    break;
                case Operation.ResizeLeft:
                    this.SelectedSprite.X = x - offsetPoint.X;
                    this.SelectedSprite.Width += diffX;
                    break;
                case Operation.ResizeTop:
                    this.SelectedSprite.Y = y - offsetPoint.Y;
                    this.SelectedSprite.Height += diffY;
                    break;
                case Operation.ResizeRight:
                    this.SelectedSprite.Right = x - offsetPoint.X;
                    break;
                case Operation.ResizeBottom:
                    this.SelectedSprite.Bottom = y - offsetPoint.Y;
                    break;
                case Operation.ResizeTopLeft:
                    this.SelectedSprite.Y = y - offsetPoint.Y;
                    this.SelectedSprite.Height += diffY;
                    this.SelectedSprite.X = x - offsetPoint.X;
                    this.SelectedSprite.Width += diffX;
                    break;
                case Operation.ResizeTopRight:
                    this.SelectedSprite.Y = y - offsetPoint.Y;
                    this.SelectedSprite.Height += diffY;
                    this.SelectedSprite.Right = x - offsetPoint.X;
                    break;
                case Operation.ResizeBottomLeft:
                    this.SelectedSprite.Bottom = y - offsetPoint.Y;
                    this.SelectedSprite.X = x - offsetPoint.X;
                    this.SelectedSprite.Width += diffX;
                    break;
                case Operation.ResizeBottomRight:
                    this.SelectedSprite.Bottom = y - offsetPoint.Y;
                    this.SelectedSprite.Right = x - offsetPoint.X;
                    break;
            }

            this.Refresh();
        }

        private void EndOperation()
        {
            if (operation != Operation.None)
            {
                this.SelectedSpriteChanged(this, new SpriteEventArgs(this.selectedSprite));
                operation = Operation.None;
            }
        }

        private SpriteDefinition GetSpriteFromMousePoint(int x, int y)
        {
            if (this.selectedSprite != null)
            {
                if (PointIsInRect(x, y, this.selectedSprite.Rectangle)) return this.selectedSprite;
            }

            foreach(SpriteDefinition sprite in this.SpritesSheet)
            {
                if (PointIsInRect(x, y, sprite.Rectangle)) return sprite;
            }

            return null;
        }

        private bool PointIsInRect(int x, int y, Rectangle rect)
        {
            rect.Inflate(BORDER_GRAB_SIZE, BORDER_GRAB_SIZE);
            return (rect.Contains(x, y));
        }
    }
}
