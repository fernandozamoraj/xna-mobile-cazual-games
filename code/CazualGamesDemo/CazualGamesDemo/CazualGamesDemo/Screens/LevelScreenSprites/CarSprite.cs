using System;
using CazualGames.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens.LevelScreenSprites
{
    public class CarSprite : Sprite
    {
        private int _speed = 5;

        public CarSprite(Rectangle viewPort) : base(viewPort)
        {
        }

        public override void Inactivate()
        {
            
        }

        public override void Load(ContentManager content)
        {
            SpriteTexture = content.Load<Texture2D>("red_car");

            Location = new Vector2(400, ViewPortHeight - (SpriteTexture.Height + 20) );

        }

        public override void Update(GameTime gameTime)
        {
            Location = new Vector2(Location.X - _speed, Location.Y);

            if (Location.X + SpriteTexture.Width < -5)
            {
                Location = new Vector2(this.ViewPortWidth, Location.Y);
                this.ClearAttachedSprites();
            }

            base.Update(gameTime);
        }

        public override bool IsActive
        {
            get { return true; }
        }
    }
}