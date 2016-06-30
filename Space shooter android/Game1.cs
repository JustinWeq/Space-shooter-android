using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Space_shooter_android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D redCube;
        Vector2 playersPosition;
        Texture2D playerShipTexture;
        Model playerShip;
        bool touched = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            playersPosition = Vector2.Zero;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load the red cube
            redCube = Content.Load<Texture2D>("RedCube");

            //load the players model
            playerShip = Content.Load<Model>("PlayerShip");

            //load the players ship texture
            playerShipTexture = Content.Load<Texture2D>("PlayerShipTexture");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            //move the player
           // playersPosition.X += (TouchPanel.GetState().Count > 0)?1:0;
           foreach(TouchLocation touch in TouchPanel.GetState())
            {
                playersPosition = touch.Position;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        void ProcessTouches(TouchCollection touchState)
        {
            foreach( TouchLocation touch in touchState)
            {
                if(touch.State != TouchLocationState.Released)
                {
                    continue;
                }

                touched = true;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //draw the red cube in the upper left corner
            //spriteBatch.Begin();

            //spriteBatch.Draw(redCube, playersPosition, Color.White);
            //spriteBatch.End();

            foreach (ModelMesh mesh in playerShip.Meshes)
            {
                foreach(BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.PreferPerPixelLighting = true;

                    effect.World = Matrix.CreateRotationX(MathHelper.Pi/2);

                    Vector3 cameraPos = new Vector3(0, 19, 0);

                    Vector3 cameraLookAt = Vector3.Zero;

                    Vector3 cameraUpVector = Vector3.UnitZ;

                    effect.View = Matrix.CreateLookAt(cameraPos, cameraLookAt, cameraUpVector);

                    float aspectRatio = graphics.PreferredBackBufferWidth / (float)graphics.PreferredBackBufferHeight;

                    float fieldOfView = MathHelper.PiOver4;

                    float nearClipPane = 1;

                    float farClipPane = 200;

                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearClipPane, farClipPane);

                    //effect.Texture = redCube;
                    //effect.TextureEnabled = true;
                }

                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}
