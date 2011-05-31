using System;
using CazualGames.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens.LevelScreenSprites
{
    public class PigeonPoopSprite : Sprite
    {
        private  float _deltaY = .8f;
        private float _deltaX = 1f;
        private double _maxDistance;

        public PigeonPoopSprite(Rectangle viewPort) : base(viewPort)
        {
        }

        public void Drop(Vector2 startLocation, double maxDistance)
        {
            _deltaY = 1.5f;
            _deltaX = -1.5f;
            Location = new Vector2(startLocation.X-10, startLocation.Y);
            _maxDistance = maxDistance;
        }

        public override void Inactivate()
        {
            Location = new Vector2(Location.X, Location.Y + (float)_maxDistance);
        }

        public override void Load(ContentManager content)
        {
            this.SpriteTexture = content.Load<Texture2D>("pigeonpoop");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _deltaY = (_deltaY*1.09f);
            Location = new Vector2(Location.X + _deltaX, Location.Y +_deltaY);
        }

        public override bool IsActive
        {
            get { return Location.Y < _maxDistance; }
        }
    }
}
