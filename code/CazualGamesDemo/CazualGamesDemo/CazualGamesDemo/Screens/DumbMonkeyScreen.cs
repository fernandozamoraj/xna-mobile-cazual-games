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
            base.Initialize();

            LoadContent(this.Game.Content);


            _marioSprite = new MarioSprite(
                new Rectangle(
                    this.Game.GraphicsDevice.Viewport.X, 
                    this.Game.GraphicsDevice.Viewport.Y, 
                    this.Game.GraphicsDevice.Viewport.Width, 
                    this.Game.GraphicsDevice.Viewport.Height),
                new Vector2(this.Game.GraphicsDevice.Viewport.Width/2f, this.Game.GraphicsDevice.Viewport.Height/4));

            float yPosition = (float)(this.Game.GraphicsDevice.Viewport.Height - _jumpButtonTexture.Height);

            _jumpButton = new Button(new Vector2(100f, yPosition), _jumpButtonTexture.Width, _jumpButtonTexture.Height, true);
            _moveLeftButton = new Button(new Vector2(100f + _jumpButtonTexture.Width + 10, yPosition), _jumpButtonTexture.Width, _jumpButtonTexture.Height, false);
            _moveLeftButton = new Button(new Vector2(100f + (_jumpButtonTexture.Width*2) + 20, yPosition), _jumpButtonTexture.Width, _jumpButtonTexture.Height, false);

        }

        public override void LoadContent(ContentManager content)
        {
            _jumpButtonTexture = content.Load<Texture2D>("button");
            _moveLeftButtonTexture = content.Load<Texture2D>("button");
            _moveRightButtonTexture = content.Load<Texture2D>("button");
        }
    }
}
