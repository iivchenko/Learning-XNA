using System;
using Microsoft.Xna.Framework;

namespace GameBoard
{
    public class Board<T> : IBoard<T>
        where T : ICellElement, IPrototype<T>
    {
        private readonly Cell<T>[,] _matrix;

        protected Board(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;

            _matrix = new Cell<T>[columns, rows];

            for (var column = 0;  column < columns; column++)
            for (var row = 0; row < rows; row++)
            {
                _matrix[column, row] = new Cell<T>(column, row);
            }
        }

        public ICell<T> this[int column, int row]
        {
            get
            {
                ValidateRange(column, row);
                
                return _matrix[column, row];
            }
        }
        
        public int Columns { get; }

        public int Rows { get; }

        public void Update(GameTime gameTime)
        {
            ForEachCell(cell => cell.Update(gameTime));
        }

        public void Draw(GameTime gameTime)
        {
            ForEachCell(cell => cell.Draw(gameTime));
        }

        private void ValidateRange(int column, int row)
        {
            if (column < 0 || column > Columns - 1)
            {
                throw new ArgumentOutOfRangeException($"Column ({column}) is out of range! Available range is [0, {Columns - 1}]");
            }

            if (row < 0 || row > Rows - 1)
            {
                throw new ArgumentOutOfRangeException($"Row ({row}) is out of range! Available range is [0, {Rows - 1}]");
            }
        }

        public void ForEachCell(Action<ICell<T>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            for (var column = 0; column < Columns; column++)
                for (var row = 0; row < Rows; row++)
                {
                    action(_matrix[column, row]);
                }
        }
    }
}