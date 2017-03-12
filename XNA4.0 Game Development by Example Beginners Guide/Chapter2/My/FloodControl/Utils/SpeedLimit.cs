using System;
using Microsoft.Xna.Framework;

namespace FloodControl.Utils
{
    public sealed class SpeedLimit
    {
        private readonly TimeSpan _sleep;
        private TimeSpan _current;

        public SpeedLimit(TimeSpan sleep)
        {
            _sleep = _current = sleep;
        }

        public bool Can()
        {
            return _current.TotalSeconds <= 0;
        }

        public void Update(GameTime gameTime)
        {
            _current = _current.Subtract(gameTime.ElapsedGameTime);
        }

        public void Reset()
        {
            _current = _sleep;
        }
    }
}
