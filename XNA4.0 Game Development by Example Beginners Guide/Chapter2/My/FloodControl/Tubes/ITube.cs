using GameBoard;

namespace FloodControl.Tubes
{
    public interface ITube : ICellElement, IPrototype<ITube>
    {
        bool Watered { get; set; }

        TubeInputs Inputs { get; }

        void Rotate(RotationDirection direction);

        void Fade();
    }
}
