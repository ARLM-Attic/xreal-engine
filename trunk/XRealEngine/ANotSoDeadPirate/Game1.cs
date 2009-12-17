using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRealEngine.Framework.Graphics;
using XRealEngine.Framework.Services;

namespace ANotSoDeadPirate
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        /*SpriteBatch spriteBatch;
        SpritesSheet sheet;
        Camera2D camera;*/
        Map map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            /*spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera2D(this);*/
            map = new Map();

            // TODO: use this.Content to load your game content here
            map.AddSpritesSheet("test1", Content.Load<SpritesSheet>("test1"));
            map.AddLayer(new MapLayer(1, Color.White, 0.1f));
            map.AddSegment(0, 0, 1, new Point(10, 10));
            map.AddSegment(0, 0, 5, new Point(500, 300));
            map.AddSegment(0, 0, 2, new Point(1000, 1000));
            map.AddSegment(0, 0, 3, new Point(200, 400));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) this.Exit();
            /*if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -0.5) camera.Position = new Vector2(camera.Position.X + 5, camera.Position.Y);
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.5) camera.Position = new Vector2(camera.Position.X - 5, camera.Position.Y);
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.5) camera.Position = new Vector2(camera.Position.X, camera.Position.Y - 5);
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.5) camera.Position = new Vector2(camera.Position.X, camera.Position.Y + 5);
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < -0.5) camera.Rotation += 0.1f;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0.5) camera.Rotation -= 0.1f;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < -0.5) camera.Zoom += 0.01f;
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0.5) camera.Zoom -= 0.01f;*/
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, camera.TransformationMatrix);
            spriteBatch.Draw(sheet.Texture, new Vector2(0 ,0), sheet[0].Rectangle, Color.White);
            spriteBatch.Draw(sheet.Texture, new Vector2(500, 0), sheet[0].Rectangle, Color.White);
            spriteBatch.Draw(sheet.Texture, new Vector2(300, 550), sheet[0].Rectangle, Color.White);
            spriteBatch.Draw(sheet.Texture, new Vector2(500, 600), sheet[0].Rectangle, Color.White);
            spriteBatch.End();*/

            base.Draw(gameTime);
        }
    }
}
