using Microsoft.Xna.Framework;

namespace FloodControl.Tubes
{
    public sealed class FakeTube : ITube
    {
        public FakeTube(TubeInputs inputs)
        {
            Inputs = inputs;
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public ITube Clone()
        {
            throw new System.NotImplementedException();
        }
        
        public bool Watered { get; set; }

        public TubeInputs Inputs { get; }

        public void Rotate(RotationDirection direction)
        {
            throw new System.NotImplementedException();
        }

        public void Fade()
        {
            throw new System.NotImplementedException();
        }
    }
}
