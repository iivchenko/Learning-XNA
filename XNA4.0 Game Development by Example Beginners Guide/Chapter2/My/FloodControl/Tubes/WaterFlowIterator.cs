using System.Collections;
using System.Collections.Generic;
using GameBoard;

namespace FloodControl.Tubes
{
    public sealed class WaterFlowIterator : IEnumerator<ICell<ITube>>
    {
        private readonly ICell<ITube> _start;
        private readonly IBoard<ITube> _board;

        private TubeInputs _exclude;

        public WaterFlowIterator(ICell<ITube> cell, IBoard<ITube> board)
        {
            _start = cell;
            _board = board;

            _exclude = 0;

            Current = _start;
        }

        public bool MoveNext()
        {
            var result = false;
            var to = Current.Instance.Inputs ^ _exclude;
            var column = Current.Column;
            var row = Current.Row;

            switch (to)
            {
                case TubeInputs.Top:
                    row--;
                    break;

                case TubeInputs.Right:
                    column++;
                    break;

                case TubeInputs.Bottom:
                    row++;
                    break;

                case TubeInputs.Left:
                    column--;
                    break;
            }

            if (row >= 0 && row < _board.Rows 
                && column >= 0 && column < _board.Columns
                && _board[column, row].Instance.Inputs.HasFlag(TubeInputsHelper.GetOposite(to)))
            {
                result = true;
                _exclude = TubeInputsHelper.GetOposite(to);
                Current = _board[column, row];
            }
            else
            {
                Current = null;
            }

            return result;
        }

        public void Reset()
        {
            Current = _start;
        }

        public ICell<ITube> Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
