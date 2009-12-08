using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework.Services
{
    public class Camera2D : ICamera2D
    {
        #region Fields

        private float zoom;
        private float rotation;
        private Matrix transformationMatrix;
        private Vector2 position;
        private GraphicsDevice graphics;

        #endregion

        public float Zoom
        {
            get { return zoom; }
            set 
            { 
                zoom = value;
                CreateTransformationMatrix();
            }
        }
        
        public float Rotation
        {
            get { return rotation; }
            set 
            { 
                rotation = value;
                CreateTransformationMatrix();
            }
        }
        
        public Vector2 Position
        {
            get { return position; }
            set
            {
                if (position != value)
                {
                    position = value;
                    CreateTransformationMatrix();
                }
            }
        }

        public Matrix TransformationMatrix
        {
            get { return transformationMatrix; }
        }

        public Camera2D(Game game)
        {
            game.Services.AddService(typeof(ICamera2D), this);
            graphics = game.GraphicsDevice;
        }

        private void CreateTransformationMatrix()
        {
            transformationMatrix = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                                        Matrix.CreateRotationZ(rotation) *
                                        Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                                        Matrix.CreateTranslation(new Vector3(graphics.Viewport.Width * 0.5f, graphics.Viewport.Height * 0.5f, 0));
        }
    }
}
