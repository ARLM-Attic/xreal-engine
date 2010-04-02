using XRealEngine.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework.Gui
{
    public sealed class GuiManager
    {
        #region Singleton Handling

        private static GuiManager instance;

        public static GuiManager GetInstance(IServiceProvider services)
        {
            if (instance == null)
            {
                instance = new GuiManager();
                instance.Services = services;
            }

            return instance;
        }

        #endregion

        private List<Window> WindowsCollection;
        private IServiceProvider Services { get; set; }
        private ContentManager Content { get; set; }
        public SpritesSheet Sheet { get; set; }
        

        private GuiManager()
        {
            WindowsCollection = new List<Window>();
        }

        private Window AddWindow(Window window)
        {
            WindowsCollection.Add(window);
            return window;
        }

        public Window this[int index]
        {
            get { return WindowsCollection[index]; }
        }

        public void Draw()
        {
            if (Sheet == null) Sheet = BuildDefaultSheet();
        }

        private SpritesSheet BuildDefaultSheet()
        {
            SpritesSheet sheet = new SpritesSheet();
            Content = new ContentManager(this.Services);

            sheet.Texture = Content.Load<Texture2D>("WindowSpritesSheet");
            sheet.Add(new SpriteDefinition("windows_top_left", new Rectangle(0,0, 29,22)));
            sheet.Add(new SpriteDefinition("windows_top", new Rectangle(30, 0, 28, 22)));
            sheet.Add(new SpriteDefinition("windows_top_right", new Rectangle(59, 0, 29, 22)));
            sheet.Add(new SpriteDefinition("windows_left", new Rectangle(0, 23, 29, 19)));
            sheet.Add(new SpriteDefinition("windows_center", new Rectangle(30, 23, 28, 19)));
            sheet.Add(new SpriteDefinition("windows_right", new Rectangle(59, 23, 29, 19)));
            sheet.Add(new SpriteDefinition("windows_bottom_left", new Rectangle(0, 43, 29, 6)));
            sheet.Add(new SpriteDefinition("windows_bottom", new Rectangle(30, 43, 28, 6)));
            sheet.Add(new SpriteDefinition("windows_bottom_right", new Rectangle(59, 43, 29, 6)));
            return sheet;
        }

    }
}
