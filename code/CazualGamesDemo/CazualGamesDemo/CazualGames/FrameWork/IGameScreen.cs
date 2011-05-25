using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.FrameWork
{
    public interface IGameScreen
    {
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void Unload();
        IGameScreenManager GameScreenManager { get; set; }
        Game Game { get; set; }
        void NavigateToScreen<T>() where T : IGameScreen;
    }
}