using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SquareChaseMob
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TheGame : Game
    {
        private SpriteBatch _spriteBatch;
        private readonly Random _rand = new Random();

        private TouchCollection _touch;

        Texture2D squareTexture;
        private SpriteFont _font;
        Rectangle currentSquare;
        int playerScore = 0;
        private float timeRemaining = 0.0f;
        float _timePerSquare = 2f;
        readonly Color[] colors = new Color[3] { Color.Red, Color.Green, Color.Blue };
        private int _squareSize = 200;

        public TheGame()
        {
            new GraphicsDeviceManager(this);
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
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            squareTexture = Content.Load<Texture2D>("SQUARE");
            _font = Content.Load<SpriteFont>("TheFont");
            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }

            if (timeRemaining == 0.0f)
            {
                currentSquare = new Rectangle(_rand.Next(0, this.Window.ClientBounds.Width - _squareSize), _rand.Next(0, this.Window.ClientBounds.Height - _squareSize), _squareSize, _squareSize);
                timeRemaining = _timePerSquare;
            }

            MouseState mouse = Mouse.GetState();
            _touch = TouchPanel.GetState();
            if ((mouse.LeftButton == ButtonState.Pressed) && (currentSquare.Contains(mouse.X, mouse.Y)))
            {
                playerScore++; timeRemaining = 0.0f;

                if (playerScore % 2 == 0)
                {
                    _squareSize -= 10;
                    _timePerSquare -= 0.1f;
                }
            }
           
            if (_touch.IsConnected && _touch.Any() && (currentSquare.Contains(_touch[0].Position.X, _touch[0].Position.Y)))
            {
                playerScore++; timeRemaining = 0.0f;

                if (playerScore % 15 == 0)
                {
                    _squareSize -= 10;
                    _timePerSquare -= 0.1f;
                }
            }

            timeRemaining = MathHelper.Max(0, timeRemaining - (float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, $"Scores: {playerScore}", Vector2.Zero, Color.Black);
            _spriteBatch.Draw(squareTexture, currentSquare, colors[playerScore % 3]);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
