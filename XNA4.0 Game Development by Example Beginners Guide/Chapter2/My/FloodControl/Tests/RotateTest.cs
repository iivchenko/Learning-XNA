using System;
using FloodControl.Tubes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl.Tests
{
    public class RotateTest
    {
        private const int ZeroDepth = 0;
        private readonly float _rotationRate;
        private readonly RotationDirection _direction;
        private readonly Rectangle _destination;
        private readonly Vector2 _origin;

        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _sprites;


        private float _rotation;

        public RotateTest(SpriteBatch spriteBatch, Texture2D sprites)
        {
            _spriteBatch = spriteBatch;
            _sprites = sprites;
            _rotation = 0;
            _rotationRate = MathHelper.ToRadians(10);

            int x = 100;
            int y = 100;
            int width = 80;
            int height = 80;

            _destination = new Rectangle(x,y,width,height);
            _origin = new Vector2(10,10);
        }

        public void Update(GameTime gameTime)
        {
            _rotation += _rotationRate;
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch
                .Draw(
                    _sprites,
                    new Vector2(100, 100),
                    new Rectangle(1, 1, 40, 40),
                    Color.White,
                    _rotation,
                    _origin,
                    2,
                    SpriteEffects.None,
                    ZeroDepth);
        }
    }
}
