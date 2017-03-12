using FloodControl.Input;
using FloodControl.Input.FloodControl.Input;
using FloodControl.Screens;
using FloodControl.Tests;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace FloodControl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TheGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private bool _resolution = true;

        public TheGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        public SpriteBatch SpriteBatch { get; private set; }

        public IGameScreen Screen { get; set; }
      
        protected override void Initialize()
        {
            Screen = new GamePlayScreen(this, TouchPanel.GetState().IsConnected ? (IInputControl)new TouchControl() : (IInputControl)new MouseControl());
            
            IsMouseVisible = true;

            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Screen.Initialize();

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }

            Screen.Update(gameTime);

            base.Update(gameTime);
        }
       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);

            SpriteBatch.Begin();
            Screen.Draw(gameTime);
            base.Draw(gameTime);
            SpriteBatch.End();
        }
    }
}
