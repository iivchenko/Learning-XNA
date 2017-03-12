using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodControl.Tubes
{
    public static class TubeInputsHelper
    {

        static TubeInputsHelper()
        {
            Tubes = new[]
            {
                TubeInputs.Left | TubeInputs.Right,
                TubeInputs.Top | TubeInputs.Bottom,
                TubeInputs.Left | TubeInputs.Top,
                TubeInputs.Top | TubeInputs.Right,
                TubeInputs.Bottom | TubeInputs.Right,
                TubeInputs.Left | TubeInputs.Bottom
            };
        }

        public static TubeInputs[] Tubes { get; }

        public static TubeInputs GetOposite(TubeInputs input)
        {
            TubeInputs oposite = 0;

            switch (input)
            {
                case TubeInputs.Top:
                    oposite = TubeInputs.Bottom;
                    break;
                case TubeInputs.Right:
                    oposite = TubeInputs.Left;
                    break;
                case TubeInputs.Bottom:
                    oposite = TubeInputs.Top;
                    break;
                case TubeInputs.Left:
                    oposite = TubeInputs.Right;
                    break;
            }

            return oposite;
        }
    }
}
