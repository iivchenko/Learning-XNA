using System.Collections.Generic;
using FloodControl.Input;
using FloodControl.Tubes;
using GameBoard;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FloodControl.Screens
{
    public sealed class GamePlayScreen : IGameScreen
    {
        private int _boardColumns;
        private int _boardRows;

        private int _tubeHeight = 120;
        private int _tubeWidth = 120;

        private readonly IInputControl _input;

        // Content
        private Texture2D _tubesTexture;
        private SpriteFont _font;

        private readonly TheGame _owner;

        private Pipeline _pipeline;

        public GamePlayScreen(TheGame owner, IInputControl input)
        {
            _owner = owner;
            _input = input;
        }

        public void Initialize()
        {
            _boardColumns = _owner.Window.ClientBounds.Width / _tubeWidth;
            _boardRows = _owner.Window.ClientBounds.Height / _tubeHeight;

            _tubesTexture = _owner.Content.Load<Texture2D>(@"Textures\Tile_Sheet");
            _font = _owner.Content.Load<SpriteFont>(@"Fonts\Pericles36");

            var tubes = new ITube[_boardColumns, _boardRows];

            for (var column = 0; column < _boardColumns; column++)
                for (var row = 0; row < _boardRows; row++)
                {
                    // TODO: Simplify the very long line of code.
                    tubes[column, row] = new Tube(_tubesTexture, _owner.SpriteBatch, column * _tubeWidth, row * _tubeHeight, _tubeWidth, _tubeHeight);
                }

            _pipeline = new Pipeline(tubes, 0, 0, _tubeWidth, _tubeHeight);
        }

        public void Update(GameTime gameTime)
        {
            var clockwise = _input.HandleClockwise();
            var counterClockwise = _input.HandleCounterClockwise();

            if (clockwise != Vector2.Zero)
            {
                _pipeline.RotateTube((int)clockwise.X, (int)clockwise.Y, RotationDirection.Clockwise);
            }
            else if (counterClockwise != Vector2.Zero)
            {
                _pipeline.RotateTube((int)counterClockwise.X, (int)counterClockwise.Y, RotationDirection.CounterClockwise);
            }

            PropagateWater();

            _pipeline.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _owner.GraphicsDevice.Clear(Color.Aquamarine);

            _pipeline.Draw(gameTime);
        }

        private void PropagateWater()
        {
            _pipeline.ForEachCell(x => x.Instance.Watered = false);
            _pipeline.ForEachRow(row =>
            {
                var list = new List<ICell<ITube>>();
                var iterator = new WaterFlowIterator(new FakeCell(-1, row.Index, new FakeTube(TubeInputs.Right)), _pipeline);

                while (iterator.MoveNext())
                {
                    iterator.Current.Instance.Watered = true;
                    list.Add(iterator.Current);
                }

                if
                (
                    list.Count > 0
                    && list[list.Count - 1].Column == _pipeline.Columns - 1
                    && list[list.Count - 1].Instance.Inputs.HasFlag(TubeInputs.Right)
                )
                {
                    foreach (var cell in list)
                    {
                        cell.Instance.Fade();
                    }
                }
            });
        }
    }
}
