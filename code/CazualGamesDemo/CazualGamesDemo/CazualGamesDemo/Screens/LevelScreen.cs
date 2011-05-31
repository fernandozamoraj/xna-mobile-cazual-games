using System.Collections.Generic;
using CazualGames.Controls;
using CazualGamesDemo.Screens.LevelScreenSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens
{
    public class LevelScreen : DemoScreenBase
    {
        private PigeonSprite _pigeon;
        private List<PigeonPoopSprite> _pigeonPoopSprites;
        private CarSprite _carSprite;
        private Button _poopButton;
        private Texture2D _poopButtonTexture;
        private List<PigeonPoopOnCarSprite> _pigeonPoopOnCarSprites;
        
        public override void Initialize()
        {
            base.Initialize();

            LoadContent(Game.Content);

            _pigeonPoopOnCarSprites = new List<PigeonPoopOnCarSprite>
                                          {
                                              new PigeonPoopOnCarSprite(CazualGame.ViewPort),
                                              new PigeonPoopOnCarSprite(CazualGame.ViewPort),
                                              new PigeonPoopOnCarSprite(CazualGame.ViewPort)
                                          };
            
            foreach(var poopOnCarSprite in _pigeonPoopOnCarSprites)
                poopOnCarSprite.Load(Game.Content);

            _poopButton = new Button(
                new Vector2(CazualGame.ViewPortWidth - (_poopButtonTexture.Width+10), 
                50), 
                _poopButtonTexture.Width, 
                _poopButtonTexture.Height, true);

        }

        public override void Update(GameTime gameTime)
        {
            HandleBackToPreviousScreenButton<StartScreen>(true);

            _poopButton.Update();

            DropPigeonPoop();

            UpdatePigeonPoopSprites(gameTime);
            _carSprite.Update(gameTime);

            DetectPoopToCarCollision();

            base.Update(gameTime);
        }

        private void DetectPoopToCarCollision()
        {
            foreach(var pigeonPoop in _pigeonPoopSprites)
            {
                if(pigeonPoop.CollidesWith(_carSprite))
                {
                    foreach(var poopOnCarSprite in _pigeonPoopOnCarSprites)
                    {
                        if(!poopOnCarSprite.IsActive)
                        {
                            _carSprite.AttachSprite(poopOnCarSprite, new Vector2(pigeonPoop.Location.X - _carSprite.Location.X, _carSprite.Size.X/4));
                            pigeonPoop.Inactivate();
                            break;
                        }
                    }
                }
            }
        }

        private void UpdatePigeonPoopSprites(GameTime gameTime)
        {
            foreach(var sprite in _pigeonPoopSprites)
                sprite.Update(gameTime);
        }

        private void DropPigeonPoop()
        {
            if(_poopButton.IsPressed)
            {
                foreach(var sprite in _pigeonPoopSprites)
                {
                    if(!sprite.IsActive)
                    {
                        sprite.Drop(_pigeon.Center, CazualGame.ViewPortHeight + 100);
                        break;
                    }
                }
            }
        }

        public override void LoadContent(ContentManager content)
        {
            InitializePigeonPoopSprites(content);

            _carSprite =  new CarSprite(CazualGame.ViewPort);
            _carSprite.Load(content);

            _poopButtonTexture = content.Load<Texture2D>("button");
            _pigeon = new PigeonSprite(CazualGame.ViewPort, new Vector2(CazualGame.ViewPortWidth/2, 30));
            _pigeon.Load(content);
        }

        private void InitializePigeonPoopSprites(ContentManager content)
        {
            _pigeonPoopSprites = new List<PigeonPoopSprite>
                                     {
                                         new PigeonPoopSprite(CazualGame.ViewPort),
                                         new PigeonPoopSprite(CazualGame.ViewPort),
                                         new PigeonPoopSprite(CazualGame.ViewPort)
                                     };

            foreach(var sprite in _pigeonPoopSprites)
                sprite.Load(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _carSprite.Draw(spriteBatch);
            _pigeon.Draw(spriteBatch);
            _poopButton.Draw(spriteBatch, _poopButtonTexture);
            
            DrawPigeonPoopSprites(spriteBatch);

            base.Draw(spriteBatch);
        }

        private void DrawPigeonPoopSprites(SpriteBatch spriteBatch)
        {
            foreach(var sprite in _pigeonPoopSprites)
                sprite.Draw(spriteBatch);
        }
    }
}