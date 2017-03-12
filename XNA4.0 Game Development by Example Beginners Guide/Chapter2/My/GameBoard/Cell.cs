using Microsoft.Xna.Framework;

namespace GameBoard
{
    public sealed class Cell<T> : ICell<T>
         where T : ICellElement, IPrototype<T>
    {
        public Cell(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; }

        public int Row { get; }

        public T Instance { get; set; }

        internal Board<T> Board { get; set; }

        public void Update(GameTime gameTime)
        {
            Instance?.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            Instance?.Draw(gameTime);
        }
    }
}