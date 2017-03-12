using Microsoft.Xna.Framework;

namespace FloodControl.Input
{
    public interface IInputControl
    {
        Vector2 HandleClockwise();
        Vector2 HandleCounterClockwise();
    }
}
