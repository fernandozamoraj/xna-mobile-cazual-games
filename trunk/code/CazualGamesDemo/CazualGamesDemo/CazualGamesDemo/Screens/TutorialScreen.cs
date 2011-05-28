using CazualGames.FrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens
{
    public class TutorialScreen : GameScreen
    {
        private Texture2D _tutorialTexture;

        public override void LoadContent(ContentManager content)
        {
            _tutorialTexture = content.Load<Texture2D>("tutorial_image");
        }

        public override void Initialize()
        {
            base.Initialize();

            LoadContent(this.Game.Content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            HandleBackToPreviousScreenButton<StartScreen>(false);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(this._tutorialTexture, new Vector2(0f, 0f), Color.White);
        }
    }
}