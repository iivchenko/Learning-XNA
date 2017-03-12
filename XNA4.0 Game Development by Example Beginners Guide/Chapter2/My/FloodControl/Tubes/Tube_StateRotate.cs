using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl.Tubes
{
    public partial class Tube
    {
        private sealed class TubeStateRotate : TubeState
        {
            private const int ZeroDepth = 0;
            private readonly float _rotationRate;
            private readonly RotationDirection _direction;
            private readonly Rectangle _destination;
            private readonly Vector2 _origin;

            private float _rotation;

            public TubeStateRotate(Tube owner, RotationDirection direction)
                : base(owner)
            {
                _direction = direction;

                _rotation = 0;

                _rotationRate =
                    direction == RotationDirection.Clockwise
                        ? MathHelper.ToRadians(15)
                        : MathHelper.ToRadians(-15);

                _destination = new Rectangle
                (
                    Owner.X + Owner.Width / 2,
                    Owner.Y + Owner.Height / 2,
                    Owner.Width,
                    Owner.Height
                );

                _origin = new Vector2(Owner.GetSourceRectangle().Width / (float)2, Owner.GetSourceRectangle().Height / (float)2);
            }

            public override TubeInputs Inputs => (TubeInputs)0;

            public override void Update(GameTime gameTime)
            {
                _rotation += _rotationRate;

                if (_rotation > MathHelper.PiOver2 || _rotation < -1 * MathHelper.PiOver2)
                {
                    Owner.InternalInputs = Rotate();
                    Owner.State = new TubeStateNormal(Owner);
                }
            }

            public override void Draw(GameTime gameTime)
            {
                Owner
                    .SpriteBatch
                    .Draw(
                        Owner.Tubes,
                        _destination,
                        Owner.GetSourceRectangle(),
                        Color.White,
                        _rotation,
                        _origin,
                        SpriteEffects.None,
                        ZeroDepth);
            }

            private TubeInputs Rotate()
            {
                TubeInputs newInputs = 0;

                if (_direction == RotationDirection.Clockwise)
                {
                    if ((Owner.InternalInputs & TubeInputs.Top) == TubeInputs.Top)
                    {
                        newInputs |= TubeInputs.Right;
                    }

                    if ((Owner.InternalInputs & TubeInputs.Right) == TubeInputs.Right)
                    {
                        newInputs |= TubeInputs.Bottom;
                    }

                    if ((Owner.InternalInputs & TubeInputs.Bottom) == TubeInputs.Bottom)
                    {
                        newInputs |= TubeInputs.Left;
                    }

                    if ((Owner.InternalInputs & TubeInputs.Left) == TubeInputs.Left)
                    {
                        newInputs |= TubeInputs.Top;
                    }
                }
                else
                {
                    if ((Owner.InternalInputs & TubeInputs.Top) == TubeInputs.Top)
                    {
                        newInputs |= TubeInputs.Left;
                    }

                    if ((Owner.InternalInputs & TubeInputs.Left) == TubeInputs.Left)
                    {
                        newInputs |= TubeInputs.Bottom;
                    }

                    if ((Owner.InternalInputs & TubeInputs.Bottom) == TubeInputs.Bottom)
                    {
                        newInputs |= TubeInputs.Right;
                    }

                    if ((Owner.InternalInputs & TubeInputs.Right) == TubeInputs.Right)
                    {
                        newInputs |= TubeInputs.Top;
                    }
                }

                return newInputs;
            }
        }
    }
}
