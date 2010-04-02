using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XRealEngine.Framework.Gui;

namespace XRealEngine.Framework
{
    public sealed class XRealGame:Game
    {
        private GuiManager guiManager;

        public XRealGame()
            : base()
        {
            guiManager = GuiManager.GetInstance(this.Services);
        }

        public GuiManager GuiManager
        {
            get { return guiManager; }
        }

        
    }
}
