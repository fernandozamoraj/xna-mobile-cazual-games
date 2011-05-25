using System;
using System.Collections.Generic;
using CazualGames.FrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.UnitTests.FrameWork
{
    public class GameScreenMock : IGameScreen, IMethodCallRecorder
    {
        IMethodCallRecorder _methodCallRecorder = new MethodCallRecorder();

        public void Initialize()
        {
            _methodCallRecorder.RegisterMethodCall("Initialize");
        }

        public void Update(GameTime gameTime)
        {
            _methodCallRecorder.RegisterMethodCall("Update");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _methodCallRecorder.RegisterMethodCall("Draw");
        }

        public void Unload()
        {
            _methodCallRecorder.RegisterMethodCall("Unload");
        }

        public IGameScreenManager GameScreenManager { get; set; }

        public Game Game { get; set; }
        public void NavigateToScreen<T>() where T : IGameScreen
        {
            GameScreenManager.ChangeScreenTo<T>();
        }

        public Dictionary<string, int> CallLog
        {
            get { return _methodCallRecorder.CallLog; }
        }

        public int GetMethodCallCount(string methodName)
        {
            return _methodCallRecorder.GetMethodCallCount(methodName);
        }

        public void RegisterMethodCall(string methodName)
        {
            _methodCallRecorder.RegisterMethodCall(methodName);
        }
    }
}