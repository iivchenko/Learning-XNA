using System.Collections;
using System.Collections.Generic;

namespace GameBoard
{
    public sealed class Column<T> : IColumn<T>
        where T : ICellElement, IPrototype<T>
    {
        private readonly IBoard<T> _board;
        
        internal Column(int column, IBoard<T> board)
        {
            Index = column;
            _board = board;
        }

        public int Index { get; }

        public ICell<T> this[int row] => _board[Index, row];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ICell<T>> GetEnumerator()
        {
            for (var row = 0;  row < _board.Rows; row++)
            {
                yield return _board[Index, row];
            }
        }
    }
}
