using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRealEngine.Framework.Services
{
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    /// <summary>
    /// A basic 2D Camera
    /// </summary>
    //////////////////////////////////////////////////////////////////////////////////////////////////// 
    public class Camera2D : ICamera2D
    {
        #region Fields

        private float zoom;
        private float rotation;
        private Matrix transformationMatrix;
        private Vector2 position;
        private GraphicsDevice graphics;

        #endregion

        #region Properties
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Get or set the zoom of the camera</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public float Zoom
        {
            get { return zoom; }
            set 
            { 
                zoom = value;
                CreateTransformationMatrix();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Get or set the rotation of the camera (in radians)</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public float Rotation
        {
            get { return rotation; }
            set 
            { 
                rotation = value;
                CreateTransformationMatrix();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Get or set the position of the camera</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
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

        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Get the transformation matrix to use with a spritebatch object to obtain the camera effect</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public Matrix TransformationMatrix
        {
            get { return transformationMatrix; }
        }
        #endregion

        #region Constructors
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Create a new camera</summary>
        /// <param name="game">The game which the camera is attached to</param>
        /// <remarks>The camera register itself in the game services collection</remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        public Camera2D(Game game)
        {
            game.Services.AddService(typeof(ICamera2D), this);
            graphics = game.GraphicsDevice;

            zoom = 1.0f;
            rotation = 0.0f;
            position = Vector2.Zero;
            CreateTransformationMatrix();
        }
        #endregion

        #region Methods
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>Create the transformation matrix needed by the sprite batch</summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////// 
        private void CreateTransformationMatrix()
        {
            transformationMatrix = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                                        Matrix.CreateRotationZ(rotation) *
                                        Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                                        Matrix.CreateTranslation(new Vector3(graphics.Viewport.Width * 0.5f, graphics.Viewport.Height * 0.5f, 0));
        }
        #endregion
    }
}
