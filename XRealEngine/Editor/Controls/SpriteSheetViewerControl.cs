using XRealEngine.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Content;

namespace Editor.Controls
{
    public class SpriteSheetViewerControl : GraphicsDeviceControl
    {
        private SelectionsManager selectionsManager;

        protected override void Initialize()
        {
           
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
