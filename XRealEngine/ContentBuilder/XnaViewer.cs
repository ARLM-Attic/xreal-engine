using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework
{
    public class XnaViewer:Control, IServiceProvider
    {
        GraphicsDeviceService graphicDeviceService;
        ContentManager contentManager;
        bool isInitialized  = false;

        public ContentManager Content
        {
            get { return contentManager; }
        }

        public GraphicsDevice GraphicsDevice
        {
            get 
            { 
                if (isInitialized) 
                    return graphicDeviceService.GraphicsDevice; 
                else
                    throw new Exception("The device is not initialized");
            }
        }

        public void Initialize()
        {
            this.graphicDeviceService = GraphicsDeviceService.AddRef(this.Handle, this.ClientSize.Width, this.ClientSize.Height);
            this.contentManager = new ContentManager(this);
            this.isInitialized = true;
        }

        #region IServiceProvider Members

        public new object GetService(Type serviceType)
        {
            if (serviceType == typeof(IGraphicsDeviceService))
            {
                return this.graphicDeviceService;
            }
            else
            {
                return base.GetService(serviceType);
            }
        }

        #endregion

        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                Initialize();
            }

            base.OnCreateControl();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            bool deviceNeedsReset = false;

            if ((!DesignMode)&&(isInitialized))
            {
                switch (GraphicsDevice.GraphicsDeviceStatus)
                {
                    case GraphicsDeviceStatus.Lost:
                        throw new Exception("Graphics device lost");

                    case GraphicsDeviceStatus.NotReset:
                        deviceNeedsReset = true;
                        break;

                    default:
                        PresentationParameters pp = GraphicsDevice.PresentationParameters;
                        deviceNeedsReset = (ClientSize.Width > pp.BackBufferWidth) || (ClientSize.Height > pp.BackBufferHeight);
                        break;
                }
            }

            if (deviceNeedsReset)
            {
                graphicDeviceService.ResetDevice(ClientSize.Width, ClientSize.Height);
            }

            base.OnSizeChanged(e);
        }

        private Viewport GetViewPort()
        {
            Viewport viewport = new Viewport();

            viewport.X = 0;
            viewport.Y = 0;

            viewport.Width = ClientSize.Width;
            viewport.Height = ClientSize.Height;

            viewport.MinDepth = 0;
            viewport.MaxDepth = 1;

            return viewport;
        }

        public void Present()
        {
            if (!DesignMode)
            {
                GraphicsDevice.Viewport = GetViewPort();
                Rectangle sourceRectangle = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
                GraphicsDevice.Present(null, null, this.Handle);
            }         
        } 
    }
}
