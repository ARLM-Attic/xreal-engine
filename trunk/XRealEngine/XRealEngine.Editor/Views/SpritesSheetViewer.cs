using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRealEngine.ContentPipeline;
using XRealEngine.Framework.Sprites;

namespace XRealEngine.Editor.Views
{
    class SpritesSheetViewer:XRealEngine.Windows.WPF.Game
    {
        XRealEngine.Windows.WPF.GraphicsDeviceManager graphics;

        public SpritesSheetViewer()
        {
            if (!(System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)))
            {
                graphics = new XRealEngine.Windows.WPF.GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
          

            base.Draw(gameTime);
        }

    
    }

    
}
