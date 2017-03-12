using System;

namespace GameBoard
{
    public static class BoardExtensions
    {
        public static void ForEachInstance<T>(this IBoard<T> board, Action<T> action)
            where T : ICellElement, IPrototype<T>
        {
            for (var column = 0; column < board.Columns; column++)
                for (var row = 0; row < board.Rows; row++)
                {
                    action(board[column, row].Instance);
                }
        }

        public static void ForEachCell<T>(this IBoard<T> board, Action<ICell<T>> action)
            where T : ICellElement, IPrototype<T>
        {
            for (var column = 0; column < board.Columns; column++)
                for (var row = 0; row < board.Rows; row++)
                {
                    action(board[column, row]);
                }
        }

        public static void ForEachColumn<T>(this IBoard<T> board, Action<IColumn<T>> action)
            where T : ICellElement, IPrototype<T>
        {
            for (var column = 0; column < board.Columns; column++)
            {
                action(new Column<T>(column, board));
            }
        }

        public static void ForEachRow<T>(this IBoard<T> board, Action<IRow<T>> action)
            where T : ICellElement, IPrototype<T>
        {
            for (var row = 0; row < board.Rows; row++)
            {
                action(new Row<T>(row, board));
            }
        }
    }
}
