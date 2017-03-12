using Microsoft.Xna.Framework;

namespace GameBoard
{
    public interface ICellElement
    {
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}
