using GameBoard;

namespace FloodControl.Tubes
{
    public sealed class Pipeline : Board<ITube>
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _tubeWidth;
        private readonly int _tubeHeight;

        public Pipeline(ITube[,] matrix, int x, int y, int tubeWidth, int tubeHeight)
            : base(matrix.GetLength(0), matrix.GetLength(1))
        {
            _x = x;
            _y = y;
            _tubeWidth = tubeWidth;
            _tubeHeight = tubeHeight;

            ForEachCell(cell => cell.Instance = matrix[cell.Column, cell.Row]);
        }

        public void RotateTube(int x, int y, RotationDirection direction)
        {
            if (IsInBoard(x, y))
            {
                var column = (x - _x) / _tubeWidth;
                var row = (y - _y) / _tubeHeight;

                this[column, row].Instance.Rotate(direction);
            }
        }

        private bool IsInBoard(int x, int y)
        {
            return IsInX(x) && IsInY(y);
        }

        private bool IsInX(int x)
        {
            return x > _x && x < _tubeWidth * Columns + _x;
        }

        private bool IsInY(int y)
        {
            return y > _y && y < _tubeHeight * Rows + _y;
        }
    }
}
