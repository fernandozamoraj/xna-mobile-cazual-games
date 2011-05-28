using System;
using CazualGames.Controls;
using CazualGames.FrameWork;
using CazualGamesDemo.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CazualGamesDemo
{
    public class StartScreen : GameScreen
    {
        private Button _startGameButton;
        private Button _tutorialButton;
        private Button _highScoresButton;

        private Texture2D _startButtonTexture;
        private Texture2D _tutorialsButtonTexture;
        private Texture2D _highScoresButtonTexture;

        public override void Update(GameTime gameTime)
        {
            HandleBackToExitButton();

            UpdateButtons();

            HandleButtonInputs();

            base.Update(gameTime);
        }

        private void HandleButtonInputs()
        {
            if (_startGameButton.IsPressed)
                NavigateToScreen<LevelScreen>();

            if(_highScoresButton.IsPressed)
                NavigateToScreen<HighScoresScreen>();

            if(_tutorialButton.IsPressed)
                NavigateToScreen<TutorialScreen>();
        }

        private void UpdateButtons()
        {
            _startGameButton.Update();
            _tutorialButton.Update();
            _highScoresButton.Update();
        }

        public override void Initialize()
        {
            base.Initialize();

            this.LoadContent(this.Game.Content);

            float deltayY = _highScoresButtonTexture.Height + 10;

            _startGameButton = new Button(new Vector2(0, 100), _startButtonTexture.Width, _startButtonTexture.Height, true);
            _highScoresButton = new Button(new Vector2(0, 100 + deltayY), _highScoresButtonTexture.Width, _highScoresButtonTexture.Height, true );
            _tutorialButton = new Button(new Vector2(0, 100 + (deltayY*2)), _tutorialsButtonTexture.Width, _tutorialsButtonTexture.Height, true );

        }

        public override void LoadContent(ContentManager content)
        {
            _startButtonTexture = content.Load<Texture2D>("start_game");
            _highScoresButtonTexture = content.Load<Texture2D>("high_scores");
            _tutorialsButtonTexture = content.Load<Texture2D>("tutorial");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _startGameButton.Draw(spriteBatch, _startButtonTexture);
            _highScoresButton.Draw(spriteBatch, _highScoresButtonTexture);
            _tutorialButton.Draw(spriteBatch, _tutorialsButtonTexture);

            base.Draw(spriteBatch);
        }
    }
}