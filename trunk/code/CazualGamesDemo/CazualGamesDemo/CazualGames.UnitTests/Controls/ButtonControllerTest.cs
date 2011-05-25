using CazualGames.Controls;
using Microsoft.Xna.Framework;
using XnaMobileUnit.FrameWork;

namespace CazualGames.UnitTests.Controls
{
    public class ButtonControllerTestContext : TestFixture
    {
        public override void Context()
        {
 
        }
    }

    public class WhenButtonIsClicked : ButtonControllerTestContext
    {
        private Button DummyButton;

        public override void Context()
        {
            base.Context();

            DummyButton = new Button(new Vector2(0f, 0f), 20, 20, true);
            DummyButton.ButtonInputController = new AlwaysPressedButtonInputController();
            DummyButton.Update();
        }

        [TestMethod]
        public void Should_be_pressed()
        {
            Assert.IsTrue(DummyButton.IsPressed, "Buton should be pressed");
        }
    }
}
