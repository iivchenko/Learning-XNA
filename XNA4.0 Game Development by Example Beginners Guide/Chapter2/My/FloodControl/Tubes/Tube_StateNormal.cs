using Microsoft.Xna.Framework;

namespace FloodControl.Tubes
{
    public partial class Tube
    {
        private sealed class TubeStateNormal : TubeState
        {
            private readonly Rectangle _destination;

            public TubeStateNormal(Tube owner)
                : base(owner)
            {
                _destination = new Rectangle(Owner.X, Owner.Y, Owner.Width, Owner.Height);
            }

            public override void Update(GameTime gameTime)
            {
                // Nothing here!
            }

            public override void Draw(GameTime gameTime)
            {
                Owner
                    .SpriteBatch
                    .Draw
                    (
                        Owner.Tubes,
                        _destination,
                        Owner.GetSourceRectangle(),
                        Color.White
                    );
            }

            public override void Rotate(RotationDirection direction)
            {
                Owner.State = new TubeStateRotate(Owner, direction);
            }
        }
    }
}
