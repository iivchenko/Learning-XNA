using Microsoft.Xna.Framework;

namespace FloodControl.Tubes
{
    public partial class Tube
    {
        private sealed class TubeStateFade : TubeState
        {
            private float _alpha;
            private readonly float _rate;
            private readonly Rectangle _destination;

            public TubeStateFade(Tube owner)
                : base(owner)
            {
                _alpha = 1.0f;
                _rate = 0.02f;

                _destination = new Rectangle
               (
                   Owner.X,
                   Owner.Y,
                   Owner.Width,
                   Owner.Height
               );
            }

            public override TubeInputs Inputs => (TubeInputs) 0;

            public override bool Watered
            {
                get { return true; }

                set { }
            }

            public override void Update(GameTime gameTime)
            {
                _alpha = MathHelper.Max(0, _alpha - _rate);

                if (_alpha == 0)
                {
                    Owner.State = new TubeStateInitialize(Owner);
                }
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
                        Color.White * _alpha
                    );
            }
        }
    }
}
