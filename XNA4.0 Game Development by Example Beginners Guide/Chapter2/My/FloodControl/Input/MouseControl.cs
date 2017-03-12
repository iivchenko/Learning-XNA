using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FloodControl.Input
{
    public class MouseControl : IInputControl
    {
        private ButtonState _left = ButtonState.Released;
        private ButtonState _right = ButtonState.Released;

        public Vector2 HandleClockwise()
        {
            var state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Released && _left == ButtonState.Pressed)
            {
                _left = ButtonState.Released;
                return state.Position.ToVector2();
            }

            if (state.LeftButton == ButtonState.Pressed)
            {
                _left = ButtonState.Pressed;
            }

            return Vector2.Zero;
        }

        public Vector2 HandleCounterClockwise()
        {
            var state = Mouse.GetState();

            if (state.RightButton == ButtonState.Released && _right == ButtonState.Pressed)
            {
                _right = ButtonState.Released;
                return state.Position.ToVector2();
            }

            if (state.RightButton == ButtonState.Pressed)
            {
                _right = ButtonState.Pressed;
            }

            return Vector2.Zero;
        }
    }
}
