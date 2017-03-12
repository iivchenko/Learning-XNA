using System.Collections;
using System.Collections.Generic;

namespace GameBoard
{
    public sealed class Row<T> : IRow<T>
        where T : ICellElement, IPrototype<T>
    {
        private readonly IBoard<T> _board;

        internal Row(int row, IBoard<T> board)
        {
            Index = row;
            _board = board;
        }

        public int Index { get; }

        public ICell<T> this[int column] => _board[column, Index];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ICell<T>> GetEnumerator()
        {
            for (var column = 0; column < _board.Columns; column++)
            {
                yield return _board[column, Index];
            }
        }
    }
}
