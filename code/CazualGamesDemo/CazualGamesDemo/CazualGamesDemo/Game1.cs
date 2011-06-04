using System;
using CazualGames.FrameWork;
using CazualGamesDemo.Screens;
using CazualGamesDemo.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CazualGamesDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : CazualGame
    {
        protected override void Initialize()
        {
            base.Initialize();

            RegisterServices();
        }

        private void RegisterServices()
        {
            CazualGames.Services.ServiceLocator.Current.RegisterService<ILeaderBoardService>(new LeaderBoardService());
        }

        protected override void RegisterScreens()
        {
            RegisterGameScreen<StartScreen>(new StartScreen());
            RegisterGameScreen<LevelScreen>(new LevelScreen());
            RegisterGameScreen<HighScoresScreen>(new HighScoresScreen());
            RegisterGameScreen<TutorialScreen>(new TutorialScreen());
            RegisterGameScreen<DumbMonkeyScreen>(new DumbMonkeyScreen());
        }

        protected override void SetInitialScreen()
        {
            SetInitialScreen<StartScreen>();
        }
    }
}
