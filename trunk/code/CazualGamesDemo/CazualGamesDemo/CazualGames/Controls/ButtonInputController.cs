using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace CazualGames.Controls
{
    public class ButtonInputController : IButtonInputController
    {
        public void Update(Button button)
        {
            if (!button.IsActive)
                return;

            TouchCollection touchCollection = TouchPanel.GetState();

            bool isPressed = false;
            button.IsPressed = false;

            foreach (TouchLocation touchLocation in touchCollection)
            {
                if (IsWithinBounds(touchLocation.Position, button))
                {
                    if (!button.WasPressed || !button.SingleClick)
                    {
                        button.IsPressed = true;
                    }

                    isPressed = true;
                }
            }

            button.WasPressed = isPressed;
        }

        public bool IsWithinBounds(Vector2 location, Button button)
        {
            if (button.TopRight.X < location.X &&
                button.TopRight.X + button.Width > location.X &&
                button.TopRight.Y < location.Y &&
                button.TopRight.Y + button.Height > location.Y)
            {
                return true;
            }

            return false;
        }
    }
}
