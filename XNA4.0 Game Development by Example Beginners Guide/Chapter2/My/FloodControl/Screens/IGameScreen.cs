using Microsoft.Xna.Framework;

namespace FloodControl.Screens
{
    public interface IGameScreen
    {
        void Initialize();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}
