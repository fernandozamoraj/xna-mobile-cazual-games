using CazualGames.FrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CazualGamesDemo.Screens
{
    public class LevelScreen : GameScreen
    {
        private Texture2D _carTexture;
        private int _speed = 5;
        private int _xLocation = 400;

        public override void Update(GameTime gameTime)
        {
            HandleBackToPreviousScreenButton<StartScreen>(true);

            _xLocation -= _speed;

            if (_xLocation + _carTexture.Width < -5)
                _xLocation = this.Game.GraphicsDevice.Viewport.Width;


            base.Update(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            _carTexture = content.Load<Texture2D>("red_car");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_carTexture, new Vector2(_xLocation, 300), Color.White);
        
            base.Draw(spriteBatch);
        }
    }
}