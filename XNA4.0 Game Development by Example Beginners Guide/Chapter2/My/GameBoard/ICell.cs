using Microsoft.Xna.Framework;

namespace GameBoard
{
    public interface ICell<T>
        where T : ICellElement, IPrototype<T>
    {
        int Column { get; }

        int Row { get; }

        T Instance { get; set; }

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}