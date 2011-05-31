using System;
using System.Collections.Generic;
using CazualGames.Core;
using Microsoft.Xna.Framework;

namespace CazualGames.FrameWork
{
    public class GameScreenManager : IGameScreenManager
    {
        public Dictionary<Type, IGameScreen> _gameScreens = new Dictionary<Type, IGameScreen>();
        public IGameScreen CurrentScreen { get { return _currentGameScreen; } }
        private IGameScreen _currentGameScreen;
        private Game _game;

        public GameScreenManager(Game game)
        {
            _game = game;
        }

        public void ChangeScreenTo<T>()
        {
            try
            {
                UnloadCurrentScreen();
                _currentGameScreen = _gameScreens[typeof(T)];
                _currentGameScreen.Initialize();
            }
            catch (KeyNotFoundException exception)
            {
                throw new CazualGamesException(Messages.ManagerDoesNotHaveTheScreenName + ": " + typeof(T).Name, exception);
            }
            catch(Exception exception)
            {
                throw new CazualGamesException(Messages.ManagerFailedToInitializedGameScreen + ": " + typeof(T).Name, exception);
            }
        }

        public void UnloadCurrentScreen()
        {
            if(_currentGameScreen != null)
            {
                _currentGameScreen.Unload();
            }
        }

        public void RegisterGameScreen<T>(IGameScreen gameScreen) where T : IGameScreen
        {
            try
            {
                if(gameScreen == null)
                    throw new ArgumentNullException("GameScreen must not be null");

                //Do this to overwrite existing registration
                if (_gameScreens.ContainsKey(typeof(T)))
                    _gameScreens.Remove(typeof (T));

                gameScreen.GameScreenManager = this;
                gameScreen.Game = _game;
                _gameScreens.Add(typeof(T), gameScreen);
            }
            catch (Exception exception)
            {
                throw new CazualGamesException(Messages.ManagerFailedToAddGameScreen, exception);
            }
        }

        public void UnloadAllContent()
        {
            throw new NotImplementedException();
        }
    }
}