using System;
using System.Collections.Generic;
using System.Linq;
using CazualGames.Controls;
using CazualGames.FrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace CazualGamesDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameScreenManager _gameScreenManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _gameScreenManager = new GameScreenManager(this);
            _gameScreenManager.RegisterGameScreen<StartScreen>(new StartScreen());
            _gameScreenManager.RegisterGameScreen<LevelScreen>(new LevelScreen());

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _gameScreenManager.ChangeScreenTo<StartScreen>();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _gameScreenManager.CurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _gameScreenManager.CurrentScreen.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }

    public class StartScreen : GameScreen
    {
        private Button _startGameButton;
        private Texture2D _buttonTexture;

        public override void Update(GameTime gameTime)
        {
            _startGameButton.Update();
            if(_startGameButton.IsPressed)
                NavigateToScreen<LevelScreen>();

            base.Update(gameTime);
        }
        public override void Initialize()
        {
            base.Initialize();

            this.LoadContent(this.Game.Content);

            _startGameButton = new Button(new Vector2(0, 100), _buttonTexture.Width, _buttonTexture.Height, true);
        }

        public override void LoadContent(ContentManager content)
        {
            _buttonTexture = content.Load<Texture2D>("start_game");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _startGameButton.Draw(spriteBatch, _buttonTexture);

            base.Draw(spriteBatch);
        }
    }

    public class LevelScreen : GameScreen
    {
        private Texture2D _carTexture;
        private int _speed = 5;
        private int _xLocation = 400;

        public override void Update(GameTime gameTime)
        {
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
