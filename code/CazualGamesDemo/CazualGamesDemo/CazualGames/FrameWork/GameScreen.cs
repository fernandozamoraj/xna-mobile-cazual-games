using System.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CazualGames.FrameWork
{
    public abstract class GameScreen : IGameScreen
    {
        public virtual void Initialize()
        {
            LoadContent(Game.Content);
        }

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime){}

        public virtual void Draw(SpriteBatch spriteBatch){}

        public virtual void Unload(){}

        public IGameScreenManager GameScreenManager { get; set; }

        public Game Game { get; set; }

        public void NavigateToScreen<T>() where T : IGameScreen
        {
            GameScreenManager.ChangeScreenTo<T>();
        }

        private void GoToPreviousScreen<TPreviousScreen>() where TPreviousScreen : IGameScreen
        {
            NavigateToScreen<TPreviousScreen>();
        }

        protected void HandleBackToPreviousScreenButton<TPreviouScreen>(bool promptForReturn) where TPreviouScreen : IGameScreen
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                MessageBoxResult messageBoxResult = MessageBoxResult.OK;
                
                if(promptForReturn)
                {
                    messageBoxResult = MessageBox.Show("Press OK to exit this screen.", "Warning", MessageBoxButton.OKCancel);
                }

                if(messageBoxResult == MessageBoxResult.OK)
                    GoToPreviousScreen<TPreviouScreen>();
            }
        }

        protected void HandleBackToExitButton()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                MessageBoxResult messageBoxResult =
                    MessageBox.Show("Press OK to exit.", "Warning", MessageBoxButton.OKCancel);
                
                if (messageBoxResult == MessageBoxResult.OK)
                    Game.Exit();
            }
        }
    }
}
