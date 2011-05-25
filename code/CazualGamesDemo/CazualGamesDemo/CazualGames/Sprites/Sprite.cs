using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.Sprites
{
    public abstract class Sprite
    {
        public abstract void Load(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public int ZOrder { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Size { get; set; }
        public abstract bool IsActive { get;}
    }
}
