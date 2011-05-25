using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.FrameWork
{
    public abstract class GameScreen : IGameScreen
    {
        public GameScreen()
        {
        }

        public virtual void Initialize()
        {
            LoadContent(this.Game.Content);
        }

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void Unload()
        {
        }

        public IGameScreenManager GameScreenManager { get; set; }

        public Game Game { get; set; }
        public void NavigateToScreen<T>() where T : IGameScreen
        {
            this.GameScreenManager.ChangeScreenTo<T>();
        }
    }
}
