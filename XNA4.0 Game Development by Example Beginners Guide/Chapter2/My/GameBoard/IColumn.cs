using System.Collections.Generic;

namespace GameBoard
{
    public interface IColumn<T> : IEnumerable<ICell<T>>
        where T : ICellElement, IPrototype<T>
    {
        int Index { get; }

        ICell<T> this[int row] { get; }
    }
}
