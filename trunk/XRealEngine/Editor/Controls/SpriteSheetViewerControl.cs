using XRealEngine.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using XRealEngine.Framework.Sprites;
using Microsoft.Xna.Framework.Content;
using XRealEngine.Windows.Winforms;

namespace Editor.Controls
{
    public class SpriteSheetViewerControl : GraphicsDeviceControl
    {
        
        protected override void Initialize()
        {
           
        }

       
        protected override void Draw()
        {
            // Clear to the default control background color.
            Color backColor = new Color(BackColor.R, BackColor.G, BackColor.B);
            GraphicsDevice.Clear(backColor);
        }
    }
}
