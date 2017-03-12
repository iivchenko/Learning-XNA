using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl.Tubes
{
    public sealed partial class Tube : ITube
    {
        public Tube(Texture2D tubes, SpriteBatch spriteBatch, int x, int y, int width, int height)
        {
            if (tubes == null)
            {
                throw new ArgumentNullException(nameof(tubes));
            }

            if (spriteBatch == null)
            {
                throw new ArgumentNullException(nameof(spriteBatch));
            }

            Tubes = tubes;
            SpriteBatch = spriteBatch;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            State = new TubeStateInitialize(this);
        }

        private Texture2D Tubes { get; }

        private SpriteBatch SpriteBatch { get; set; }

        private int X { get; }

        private int Y { get; }

        private int Width { get; }

        private int Height { get; }

        public TubeInputs Inputs => State.Inputs;

        private TubeInputs InternalInputs { get; set; }

        public bool Watered
        {
            get { return State.Watered; }

            set { State.Watered = value; }
        }

        private bool  InternalWatered { get; set; }

        private TubeState State { get; set; }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            var x = 1; 
            var y = (6 * 40) + 6 + 1;

            SpriteBatch.Draw(Tubes, new Rectangle(X, Y, Width, Height), new Rectangle(x, y, 40, 40), Color.White);

            State.Draw(gameTime);
        }

        public void Rotate(RotationDirection direction)
        {
            State.Rotate(direction);
        }

        public void Fade()
        {
            State = new TubeStateFade(this);
        }

        public ITube Clone()
        {
            return new Tube(Tubes, SpriteBatch, X, Y, Width, Height);
        }

        private Rectangle GetSourceRectangle()
        {
            var tubes = new[]
            {
                TubeInputs.Left | TubeInputs.Right,
                TubeInputs.Top | TubeInputs.Bottom,
                TubeInputs.Left | TubeInputs.Top,
                TubeInputs.Top | TubeInputs.Right,
                TubeInputs.Bottom | TubeInputs.Right,
                TubeInputs.Left | TubeInputs.Bottom
            };
            var index = Array.IndexOf(tubes, InternalInputs);
            var x = Watered ? 2 + 40 : 1; // Texture width
            var y = (index * 40) + index + 1;

            return new Rectangle(x, y, 40, 40);
        }
    }
}
