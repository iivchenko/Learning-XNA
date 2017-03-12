using GameBoard;
using Microsoft.Xna.Framework;

namespace FloodControl.Tubes
{
    public sealed class FakeCell : ICell<ITube>
    {
        public FakeCell(int column, int row, ITube tube)
        {
            Column = column;
            Row = row;
            Instance = tube;
        }

        public int Column { get; }

        public int Row { get; }

        public ITube Instance { get; set; }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
