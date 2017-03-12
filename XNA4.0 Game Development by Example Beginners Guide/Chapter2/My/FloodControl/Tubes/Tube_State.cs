using System;
using Microsoft.Xna.Framework;

namespace FloodControl.Tubes
{
    public partial class Tube
    {
        private abstract class TubeState : ITube
        {
            protected TubeState(Tube owner)
            {
                Owner = owner;
            }

            public virtual TubeInputs Inputs => Owner.InternalInputs;

            public virtual bool Watered
            {
                get { return Owner.InternalWatered; }

                set { Owner.InternalWatered = value; }

            }

            protected Tube Owner { get; }

            public abstract void Update(GameTime gameTime);

            public abstract void Draw(GameTime gameTime);

            public virtual void Rotate(RotationDirection direction)
            {
                // Do nothing!
            }

            public virtual void Fade()
            {
                // Do nothing!
            }

            public ITube Clone()
            {
                throw new NotSupportedException();
            }
        }
    }
}
