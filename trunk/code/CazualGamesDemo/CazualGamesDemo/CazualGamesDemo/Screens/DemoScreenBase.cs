using CazualGames.Core;
using CazualGames.FrameWork;
using Microsoft.Xna.Framework.Content;

namespace CazualGamesDemo.Screens
{
    public abstract class DemoScreenBase : GameScreen
    {
        protected CazualGame CazualGame;

        public override void LoadContent(ContentManager content)
        {
            
        }

        public override void Initialize()
        {
            CazualGame = (CazualGame)Game;
            base.Initialize();
        }
    }
}