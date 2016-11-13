using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SATTutorial.Content;
using SATTutorial.Entities;
using SATTutorial.Physics_Game;

namespace SATTutorial
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PhysicsGame physicsGame;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            physicsGame = new PhysicsGame();
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

            //use this.Content to load your game content here
            ContentStore.LoadContent(Content);

            physicsGame.CreatePlayer();
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
            physicsGame.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.A))
            {
                physicsGame.Player.body.Rotation += -3f * (gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                physicsGame.Player.body.Rotation += 3f * (gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }

            if (keyboard.IsKeyDown(Keys.W))
            {
                Matrix rotation = physicsGame.Player.body.RotationMatrix;
                physicsGame.Player.body.Velocity += Vector2.Transform(new Vector2(0, -100), rotation) * (gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                Matrix rotation = physicsGame.Player.body.RotationMatrix;
                physicsGame.Player.body.Velocity += Vector2.Transform(new Vector2(0, 100), rotation) * (gameTime.ElapsedGameTime.Milliseconds / 1000f);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Drawable drawable in physicsGame.Drawables)
            {
                spriteBatch.Draw(drawable.texture, drawable.body.Location, null, null, 
                    new Vector2(drawable.texture.Width / 2, drawable.texture.Height / 2), drawable.body.Rotation,
                    Vector2.One, Color.White, SpriteEffects.None, 0);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
