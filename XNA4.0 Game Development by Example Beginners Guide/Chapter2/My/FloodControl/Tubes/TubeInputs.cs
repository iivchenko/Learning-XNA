using System;

namespace FloodControl.Tubes
{
    [Flags]
    public enum TubeInputs
    {
        Top = 0x1,
        Right = 0x2,
        Bottom = 0x4,
        Left = 0x8
    }
}
