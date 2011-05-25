using CazualGames.Controls;

namespace CazualGames.UnitTests.Controls
{
    public class AlwaysPressedButtonInputController : IButtonInputController
    {
        public void Update(Button button)
        {
            button.IsPressed = true;
        }
    }
}