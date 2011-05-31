using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CazualGames.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens.LevelScreenSprites
{
    public class PigeonPoopOnCarSprite : AttachedSprite
    {
        public PigeonPoopOnCarSprite(Rectangle viewPort) : base(viewPort, 0)
        {
        }

        public override void Load(ContentManager content)
        {
            this.SpriteTexture = content.Load<Texture2D>("pigeonpoop");
        }

        public override bool IsActive
        {
            get { return _isActive; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
