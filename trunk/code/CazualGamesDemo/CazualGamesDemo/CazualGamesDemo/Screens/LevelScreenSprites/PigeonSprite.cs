using System;
using CazualGames.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGamesDemo.Screens.LevelScreenSprites
{
    public class PigeonSprite : AnimatedSprite
    {
        public PigeonSprite(Rectangle viewPort, Vector2 initialLocation) : base(viewPort, 150, new DateTimeNow())
        {
            Location = new Vector2(initialLocation.X, initialLocation.Y);
        }

        public override void Load(ContentManager content)
        {
            TextureList.Add( content.Load<Texture2D>("pigeon01"));
            TextureList.Add( content.Load<Texture2D>("pigeon02"));
            TextureList.Add( content.Load<Texture2D>("pigeon03"));
            
        }

        public override bool IsActive
        {
            get { return true; }
        }
    }
}