using CazualGames.Core;
using CazualGames.FrameWork;
using CazualGames.UnitTests.FrameWork;
using Microsoft.Xna.Framework.Content;
using XnaMobileUnit.FrameWork;

namespace CazualGames.UnitTests.Framework
{
    public class GameScreenManagerTestContext : TestFixture
    {
        protected GameScreenManager GameScreenManager;

        public override void Context()
        {
            this.GameScreenManager = new GameScreenManager(Game1.TheGame);
        }
    }

    public class WhenRetrievingAGameScreenThatDoesNotExist : GameScreenManagerTestContext
    {
        [TestMethod]
        [ExpectedException(typeof(CazualGamesException))]
        public void Should_throw_a_cazual_games_exception()
        {
            this.GameScreenManager.ChangeScreenTo<GameScreenMock>();
            IGameScreen gameScreen = this.GameScreenManager.CurrentScreen;
        }
    }

    
    public class WhenRetrievingAGameScreenThatExists : GameScreenManagerTestContext
    {
        private IGameScreen GameScreen;

        public override void Context()
        {
            base.Context();

            GameScreenManager.RegisterGameScreen<GameScreenMock>(new GameScreenMock());
            GameScreenManager.ChangeScreenTo<GameScreenMock>();
            GameScreen = GameScreenManager.CurrentScreen;
        }

        [TestMethod]
        public void Should_have_returned_a_screen()
        {
            Assert.IsTrue(this.GameScreen != null, "Screen should not be nulll");
        }
    }

    public class WhenSwitchingScreens : GameScreenManagerTestContext
    {
        private IGameScreen GameScreen;
        private IGameScreen AnotherGameScreen;

        public override void Context()
        {
            base.Context();

            GameScreenManager.RegisterGameScreen<GameScreenMock>(new GameScreenMock());
            GameScreenManager.RegisterGameScreen<AnotherGameScreenMock>(new AnotherGameScreenMock());
            
            GameScreenManager.ChangeScreenTo<GameScreenMock>();
            GameScreen = GameScreenManager.CurrentScreen;

            GameScreenManager.ChangeScreenTo<AnotherGameScreenMock>();
            AnotherGameScreen = GameScreenManager.CurrentScreen;
        }

        [TestMethod]
        public void should_switch_screens()
        {
            Assert.IsTrue(AnotherGameScreen != null, "should be on another game screen");
        }

        [TestMethod]
        public void should_be_the_right_type_of_screen()
        {
            Assert.AreEqual(typeof(AnotherGameScreenMock), AnotherGameScreen.GetType(), "Should be of type AnotherScreenMock");
        }

        [TestMethod]
        public void should_have_called_unload_on_game_screen()
        {
            int actualUnloadCallCount = ((IMethodCallRecorder) GameScreen).GetMethodCallCount("Unload");

            Assert.AreEqual(1, actualUnloadCallCount, "Should have called unload once");
        }

        [TestMethod]
        public void should_have_called_initialized_on_gamescreen()
        {
            int actualInitializeCallCount = ((IMethodCallRecorder)GameScreen).GetMethodCallCount("Initialize");

            Assert.AreEqual(1, actualInitializeCallCount, "Should have called initialize once");
        }

        [TestMethod]
        public void should_have_called_initialized_on_another_gamescreen()
        {
            int actualInitializeCallCount = ((IMethodCallRecorder)AnotherGameScreen).GetMethodCallCount("Initialize");

            Assert.AreEqual(1, actualInitializeCallCount, "Should have called initialize once");
        }
    }

    public class WhenScreenNavigateToScreenIsCalled : GameScreenManagerTestContext
    {
        public override void Context()
        {
            base.Context();

            GameScreenManager.RegisterGameScreen<DummyGameScreen>(new DummyGameScreen());
            GameScreenManager.RegisterGameScreen<AnotherDummyGameScreen>(new AnotherDummyGameScreen());

            GameScreenManager.ChangeScreenTo<DummyGameScreen>();
            GameScreenManager.CurrentScreen.NavigateToScreen<AnotherDummyGameScreen>();
        }

        [TestMethod]
        public void Should_switch_to_other_screen()
        {
            Assert.AreEqual(typeof(AnotherDummyGameScreen), GameScreenManager.CurrentScreen.GetType(), "should have switch to Another Dummy Game Screen");
        }
    }

    public class DummyGameScreen : GameScreen
    {
        public override void LoadContent(ContentManager content)
        {
            
        }
    }

    public class AnotherDummyGameScreen : GameScreen
    {
        public override void LoadContent(ContentManager content)
        {

        }
    }

}