using System;
using CazualGames.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens.DumMonkeySprites
{
    public class MarioSprite : AnimatedSprite
    {
        private double _fallingSpeed;
        private double _walkingSpeed = 10;
        private bool _isFalling;
        private double _climbingSpeed = 10;

        public override void Load(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            this.TextureList.Add(content.Load<Texture2D>("mario_01"));
            this.TextureList.Add(content.Load<Texture2D>("mario_02"));
        }

        public MarioSprite(Rectangle viewPort, Vector2 initialLocation)
            : base(viewPort, 150, new DateTimeNow())
        {

            Location = new Vector2(initialLocation.X, initialLocation.Y);
        }

        public void BeginFalling()
        {
            _fallingSpeed = .9f;
            _isFalling = true;
        }

        public void StopFalling(double stopLocation)
        {
            _fallingSpeed = 0;
            _isFalling = false;
        }

        public void WalkRight()
        {
            _walkingSpeed = 10;
        }

        public void WalkLeft()
        {
            _walkingSpeed = -10;
        }

        public void ClimbUp()
        {
            _climbingSpeed = -10;
        }

        public void ClimbDown()
        {
            _climbingSpeed = 10;
        }

        public void Clamp(double leftLimit, double rightLimit)
        {
            if (_walkingSpeed < 0 && Location.X < leftLimit)
            {
                _walkingSpeed = 0;
                Location = new Vector2((float)leftLimit, (float)Location.Y);
            }

            if (_walkingSpeed > 0 && Location.X - this.SpriteTexture.Width > rightLimit)
            {
                _walkingSpeed = 0;
                Location = new Vector2((float)rightLimit - this.SpriteTexture.Width, Location.Y);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _fallingSpeed = _fallingSpeed * 1.09f;

            Location = new Vector2((float)(Location.X + (float)_walkingSpeed), (float)(Location.Y + (float)_fallingSpeed));
        }

        public override bool IsActive
        {
            get { return true; }
        }
    }
}
