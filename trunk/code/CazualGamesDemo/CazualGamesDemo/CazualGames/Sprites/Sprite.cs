using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.Sprites
{
    public abstract class Sprite
    {
        protected Sprite(Rectangle viewPort)
        {
            _viewPort = viewPort;
        }
        
        private Rectangle _viewPort;

        protected List<AttachedSprite> _attachments = new List<AttachedSprite>();

        protected float ViewPortWidth
        {
            get
            {
                return _viewPort.Width;
            }
        }

        protected float ViewPortHeight
        {
            get
            {
                return _viewPort.Height;
            }
        }

        protected Vector2 ViewPortTopRight
        {
            get
            {
                return new Vector2(_viewPort.X, _viewPort.Y);
            }
        }

        protected Texture2D SpriteTexture;

        public virtual void Inactivate()
        {
        }

        public abstract void Load(ContentManager content);
        public virtual void Update(GameTime gameTime)
        {
            if(Size.X == 0 && Size.Y == 0)
            {
                Size = new Vector2(SpriteTexture.Width, SpriteTexture.Height);
            }

            foreach (var attachedSprite in _attachments)
                attachedSprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(SpriteTexture != null && IsActive)
            {
                spriteBatch.Draw(SpriteTexture, Location, Color.White);
                foreach(var attachedSprite in _attachments)
                    attachedSprite.Draw(spriteBatch);
            }
        }

        public virtual void AttachSprite(AttachedSprite sprite, Vector2 offsetFromParent)
        {
            sprite.AttachToParent(this, offsetFromParent);
            _attachments.Add(sprite);
        }

        public virtual void ClearAttachedSprites()
        {
            foreach (var attachedSprite in _attachments)
                attachedSprite.Inactivate();

            _attachments = null;
            _attachments = new List<AttachedSprite>();
        }

        public int ZOrder { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 Size { get; set; }
        public abstract bool IsActive { get;}
        public virtual Vector2 Center
        {
            get
            {
                if(SpriteTexture != null)
                    return new Vector2(Location.X + (SpriteTexture.Width/2f), Location.Y + (SpriteTexture.Height/2f));

                return Location;
            }
        }

        public bool CollidesWith(Sprite otherSprite)
        {
            Rectangle thisRectangle = new Rectangle((int)Location.X, (int)Location.Y, (int)Size.X, (int)Size.Y);
            Rectangle otherRectangle = new Rectangle((int)otherSprite.Location.X, (int)otherSprite.Location.Y, (int)otherSprite.Size.X, (int)otherSprite.Size.Y);

            return thisRectangle.Intersects(otherRectangle);
        }
    }
}
