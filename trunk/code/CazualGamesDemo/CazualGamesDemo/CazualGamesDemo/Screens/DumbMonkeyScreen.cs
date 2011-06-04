using System;
using CazualGames.Controls;
using CazualGames.FrameWork;
using CazualGames.Services;
using CazualGamesDemo.Services;
using CazualGames.Sprites;
using CazualGamesDemo.Screens.DumMonkeySprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace CazualGamesDemo.Screens
{
    public class DumbMonkeyScreen : GameScreen
    {
        Button _jumpButton;
        Button _moveLeftButton;
        Button _moveRightButton;
        MarioSprite _marioSprite;

        Texture2D _jumpButtonTexture;
        Texture2D _moveLeftButtonTexture;
        Texture2D _moveRightButtonTexture;
        

        public override void Initialize()
        {
            _marioSprite = new MarioSprite(
                    new Rectangle(
                        this.Game.GraphicsDevice.Viewport.X,
                        this.Game.GraphicsDevice.Viewport.Y,
                        this.Game.GraphicsDevice.Viewport.Width,
                        this.Game.GraphicsDevice.Viewport.Height),
                    new Vector2(this.Game.GraphicsDevice.Viewport.Width / 2f, this.Game.GraphicsDevice.Viewport.Height / 4));
            
            base.Initialize();





            float yPosition = (float)(this.Game.GraphicsDevice.Viewport.Height - _jumpButtonTexture.Height);

            _jumpButton = new Button(new Vector2(100f, yPosition), _jumpButtonTexture.Width, _jumpButtonTexture.Height, true);
            _moveLeftButton = new Button(new Vector2(100f + _jumpButtonTexture.Width + 10, yPosition), _jumpButtonTexture.Width, _jumpButtonTexture.Height, false);
            _moveRightButton = new Button(new Vector2(100f + (_jumpButtonTexture.Width*2) + 20, yPosition), _jumpButtonTexture.Width, _jumpButtonTexture.Height, false);

        }

        public override void LoadContent(ContentManager content)
        {
            _jumpButtonTexture = content.Load<Texture2D>("button");
            _moveLeftButtonTexture = content.Load<Texture2D>("button");
            _moveRightButtonTexture = content.Load<Texture2D>("button");
            _marioSprite.Load(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _jumpButton.Update();
            _moveLeftButton.Update();
            _moveRightButton.Update();

            _marioSprite.StopWalking();

            if(_moveLeftButton.IsPressed)
                _marioSprite.WalkLeft();
            if(_moveRightButton.IsPressed)
                _marioSprite.WalkRight();
            if(_jumpButton.IsPressed)
                _marioSprite.Jump();

            _marioSprite.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            _marioSprite.Draw(spriteBatch);
            _moveLeftButton.Draw(spriteBatch, _moveLeftButtonTexture);
            _moveRightButton.Draw(spriteBatch, _moveRightButtonTexture);
            _jumpButton.Draw(spriteBatch, _jumpButtonTexture);
        }
    }
}
