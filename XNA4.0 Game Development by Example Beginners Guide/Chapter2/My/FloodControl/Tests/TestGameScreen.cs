using FloodControl.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl.Tests
{
    public sealed class TestGameScreen : IGameScreen
    {
        private readonly RotateTest _rotate;

        public TestGameScreen(SpriteBatch spriteBatch, Texture2D sprites)
        {
            _rotate = new RotateTest(spriteBatch, sprites);
        }

        public void Initialize()
        {
        }

        public void Update(GameTime gameTime)
        {
            _rotate.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _rotate.Draw(gameTime);
        }
    }
}
