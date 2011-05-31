using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.FrameWork
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public abstract class CazualGame : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        protected GameScreenManager _gameScreenManager;
        protected Rectangle _viewPort = new Rectangle(0,0,0,0);

        public CazualGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _gameScreenManager = new GameScreenManager(this);

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
        }

        public float ViewPortWidth
        {
            get { return _viewPort.Width; }
        }

        public float ViewPortHeight
        {
            get { return _viewPort.Height; }
        }

        protected abstract void RegisterScreens();
        protected abstract void SetInitialScreen();
        protected virtual void SetViewPort()
        {
            _viewPort = new Rectangle(
                _graphics.GraphicsDevice.Viewport.X, 
                _graphics.GraphicsDevice.Viewport.Y, 
                _graphics.GraphicsDevice.Viewport.Width, 
                _graphics.GraphicsDevice.Viewport.Height);
        }

        protected virtual void RegisterGameScreen<T>(IGameScreen gameScreen)  where T: IGameScreen
        {
            _gameScreenManager.RegisterGameScreen<T>(gameScreen);
        }

        protected virtual void SetInitialScreen<T>() where T: IGameScreen
        {
            _gameScreenManager.ChangeScreenTo<T>();
        }

        protected virtual void SetViewPort(Rectangle viewPort)
        {
            _viewPort = viewPort;
        }

        public Rectangle ViewPort
        {
            get { return _viewPort; }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            RegisterScreens();
            SetViewPort();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            SetInitialScreen();

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            _gameScreenManager.UnloadAllContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
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

            _spriteBatch.Begin();
            _gameScreenManager.CurrentScreen.Draw(_spriteBatch);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
