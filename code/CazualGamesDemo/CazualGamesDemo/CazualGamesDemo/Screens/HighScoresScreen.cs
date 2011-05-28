using System;
using CazualGames.FrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens
{
    public class HighScoresScreen : GameScreen
    {
        private SpriteFont _scoresFont;

        public override void LoadContent(ContentManager content)
        {
             _scoresFont = content.Load<SpriteFont>("Scores_font");
        }

        public override void Initialize()
        {
            base.Initialize();

            LoadContent(this.Game.Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            DrawHardCodedScores(spriteBatch);
        }

        private void DrawHardCodedScores(SpriteBatch spriteBatch)
        {
            Vector2 fontSize = _scoresFont.MeasureString("W");

            fontSize.Y += 5;

            Func<int,float, float, float> computeHeight =
                (lineIndex, fontHeight, offset) =>
                    {
                        return (lineIndex*fontHeight) + offset;
                    }; 

            //Hard coded scores
            spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", "Joe".PadRight(10), "1024".PadLeft(6)), 
                                   new Vector2(50, computeHeight(1, fontSize.Y, 100f)), Color.White);
            spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", "Jon".PadRight(10), "512".PadLeft(6)),
                                   new Vector2(50, computeHeight(2, fontSize.Y, 100f)), Color.White);
            spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", "Mary".PadRight(10), "256".PadLeft(6)),
                                   new Vector2(50, computeHeight(3, fontSize.Y, 100f)), Color.White);
            spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", "Jay".PadRight(10), "128".PadLeft(6)),
                                   new Vector2(50, computeHeight(4, fontSize.Y, 100f)), Color.White);
            spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", "Travis".PadRight(10), "64".PadLeft(6)),
                                   new Vector2(50, computeHeight(5, fontSize.Y, 100f)), Color.White);
            spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", "Steve".PadRight(10), "32".PadLeft(6)),
                                   new Vector2(50, computeHeight(6, fontSize.Y, 100f)), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            HandleBackToPreviousScreenButton<StartScreen>(false);
            base.Update(gameTime);
        }
    }
}