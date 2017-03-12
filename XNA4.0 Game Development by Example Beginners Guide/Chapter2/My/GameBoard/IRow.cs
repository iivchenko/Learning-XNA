using System.Collections.Generic;

namespace GameBoard
{
    public interface IRow<T> : IEnumerable<ICell<T>>
        where T : ICellElement, IPrototype<T>
    {
        int Index { get; }

        ICell<T> this[int column] { get; }
    }
}
