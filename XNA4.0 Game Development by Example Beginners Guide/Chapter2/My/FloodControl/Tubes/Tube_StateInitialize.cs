using System;
using FloodControl.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl.Tubes
{
    public sealed partial class Tube
    {
        private sealed class TubeStateInitialize : TubeState
        {
            private static readonly Random Random = new Random();

            private readonly float _rate;
            private readonly Vector2 _position;
            private readonly Vector2 _origin;
            private float _scale;

            public TubeStateInitialize(Tube owner) 
                : base(owner)
            {
                _scale = 0f;
                _rate = 0.05f;
                //_origin = new Vector2(Owner.Width / (float)2, Owner.Height / (float)2);
                _origin = new Vector2(20, 20);
                _position = new Vector2(Owner.X + Owner.Width / 2, Owner.Y + Owner.Height / 2);

                Owner.InternalInputs = TubeInputsHelper.Tubes[Random.Next(0, TubeInputsHelper.Tubes.Length)];
            }

            public override void Update(GameTime gameTime)
            {
                if (_scale < 1.0f)
                {
                    _scale += _rate;
                }
                else
                {
                    Owner.State = new TubeStateNormal(Owner);
                }
            }

            public override void Draw(GameTime gameTime)
            {
                Owner
                    .SpriteBatch
                    .Draw
                    (
                        Owner.Tubes,
                        _position,
                        Owner.GetSourceRectangle(),
                        Color.White,
                        0,
                        _origin,
                        new Vector2(_scale, _scale),
                        SpriteEffects.None, 
                        0
                    );
            }
        }
    }
}
