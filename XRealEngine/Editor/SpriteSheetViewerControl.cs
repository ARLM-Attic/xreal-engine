using XRealEngine.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace Editor
{
    public class SpriteSheetViewerControl : GraphicsDeviceControl
    {
        private SelectionsManager selectionsManager;

        protected override void Initialize()
        {
            selectionsManager = new SelectionsManager(this.GraphicsDevice);
            selectionsManager.AddSelection(new RectangularSelection(new Microsoft.Xna.Framework.Rectangle(20, 20, 10, 100)));
            selectionsManager.AddSelection(new RectangularSelection(new Microsoft.Xna.Framework.Rectangle(60, 20, 10, 100)));

            this.MouseClick += new MouseEventHandler(SpriteSheetViewerControl_MouseClick);
            this.MouseDown += new MouseEventHandler(SpriteSheetViewerControl_MouseDown);
            this.MouseUp += new MouseEventHandler(SpriteSheetViewerControl_MouseUp);
            this.MouseMove += new MouseEventHandler(SpriteSheetViewerControl_MouseMove);
            Application.Idle += delegate { Invalidate(); };
        }

        void SpriteSheetViewerControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) selectionsManager.UpdateNewSelection(e.X, e.Y);
        }

        void SpriteSheetViewerControl_MouseUp(object sender, MouseEventArgs e)
        {
            selectionsManager.EndNewSelection(e.X, e.Y);
        }

        void SpriteSheetViewerControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) selectionsManager.BeginNewSelection(e.X, e.Y);
        }

        private void SpriteSheetViewerControl_MouseClick(object sender, MouseEventArgs e)
        {
            RectangularSelection selection = selectionsManager.SetActiveSelectionFromPoint(e.X, e.Y);
        }

        protected override void Draw()
        {
            // Clear to the default control background color.
            Color backColor = new Color(BackColor.R, BackColor.G, BackColor.B);
            GraphicsDevice.Clear(backColor);

            // Draw the selections
            selectionsManager.Draw();
        }

        
        

    }
}
