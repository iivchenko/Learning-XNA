using System;
using Microsoft.Xna.Framework;

namespace GameBoard
{
    public interface IBoard<T>
        where T : ICellElement, IPrototype<T>

    {
        ICell<T> this[int column, int row] { get; }

        int Columns { get; }

        int Rows { get; } 

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}