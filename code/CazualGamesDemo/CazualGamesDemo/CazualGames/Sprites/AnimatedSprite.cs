using System.Collections.Generic;
using CazualGames.FrameWork;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.Sprites
{
    public abstract class AnimatedSprite : Sprite
    {
        //Should be loaded in LoadContent
        protected List<Texture2D> TextureList = new List<Texture2D>();
        private int _timeBetweenTextures;
        private Timer _timer;
        private int _currentImage = -0;

        public AnimatedSprite(Rectangle viewPort, int timeBetweenTexturesInMilliseconds, IDateTimeNow dateTimeNow) :base(viewPort)
        {
            _timeBetweenTextures = timeBetweenTexturesInMilliseconds;

            _timer = new Timer(dateTimeNow);
            _timer.Start(_timeBetweenTextures);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SetSpriteTexture();

            if (TextureList.Count > 0)
            {
                if (_timer.HasTheTimePassed())
                {
                    _currentImage = (_currentImage + 1)%TextureList.Count;
                    _timer.ReStart();
                }

                if(IsActive)
                    spriteBatch.Draw(TextureList[_currentImage], Location, Color.White);
            }
        }

        public void Reset()
        {
            _currentImage = 0;
            _timer.ReStart();
        }

        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            SetSpriteTexture();
        }

        private void SetSpriteTexture()
        {
            if (TextureList.Count > 0 && SpriteTexture == null)
                SpriteTexture = TextureList[0];
        }

        public override void Update(GameTime gameTime)
        {
            SetSpriteTexture();
        }
    }
}
