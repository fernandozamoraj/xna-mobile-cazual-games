using System;
using CazualGames.FrameWork;
using CazualGames.Services;
using CazualGamesDemo.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens
{
    public class HighScoresScreen : GameScreen
    {
        private SpriteFont _scoresFont;
        private ILeaderBoardService _leaderBoardService;

        public override void LoadContent(ContentManager content)
        {
             _scoresFont = content.Load<SpriteFont>("Scores_font");
        }

        public override void Initialize()
        {
            base.Initialize();

            LoadContent(this.Game.Content);

            _leaderBoardService = ServiceLocator.Current.GetService<ILeaderBoardService>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            DrawScores(spriteBatch);
        }

        private void DrawScores(SpriteBatch spriteBatch)
        {
            Vector2 fontSize = _scoresFont.MeasureString("W");

            fontSize.Y += 2;

            Func<int,float, float, float> computeHeight =
                (lineIndex, fontHeight, offset) => (lineIndex*fontHeight) + offset; 

            int lineNumber = 1;
            
            foreach(var leader in _leaderBoardService.GetAll())
            {
                spriteBatch.DrawString(_scoresFont, string.Format("{0}{1}", leader.Name.PadRight(10), leader.Score.ToString().PadLeft(6)),
                                   new Vector2(50, computeHeight(lineNumber, fontSize.Y, 100f)), Color.White);

                lineNumber++;
            }
        }

        public override void Update(GameTime gameTime)
        {
            HandleBackToPreviousScreenButton<StartScreen>(false);
            base.Update(gameTime);
        }
    }
}