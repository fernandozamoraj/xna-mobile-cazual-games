using Microsoft.Xna.Framework;

namespace CazualGames.FrameWork
{
    public interface IGameScreenManager
    {
        IGameScreen CurrentScreen { get; }
        void ChangeScreenTo<T>();
        void UnloadCurrentScreen();
        void RegisterGameScreen<T>(IGameScreen gameScreen) where T : IGameScreen;
    }
}