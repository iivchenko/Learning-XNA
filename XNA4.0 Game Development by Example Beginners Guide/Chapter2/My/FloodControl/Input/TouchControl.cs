using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace FloodControl.Input
{
    namespace FloodControl.Input
    {
        public class TouchControl : IInputControl
        {
            private bool _touched ;
            private TouchLocation _last;

            public Vector2 HandleClockwise()
            {
                var _touch = TouchPanel.GetState();
                var result = Vector2.Zero;

                if (_touch.Any() && !_touched)
                {
                    _touched = true;
                    _last = _touch.First();
                }
                else if (!_touch.Any() && _touched)
                {
                    _touched = false;
                    result = new Vector2(_last.Position.X, _last.Position.Y);
                }

                return result;
            }

            public Vector2 HandleCounterClockwise()
            {
                return Vector2.Zero;
            }
        }
    }

}
