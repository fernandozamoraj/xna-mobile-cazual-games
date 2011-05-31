using CazualGames.FrameWork;
using Microsoft.Xna.Framework;

namespace CazualGames.Sprites
{
    public abstract class AttachedSprite : Sprite
    {
        private Sprite _parent;
        private Timer _lifeTimeTimer;
        private int _lifeTimeInMilliSeconds;
        protected Rectangle ViewPort;
        protected Vector2 OffsetFromParent;
        protected bool _isActive;

        public Sprite Parent
        {
            get { return _parent; } 
            set
            {
                _parent = value;
                Location = new Vector2(_parent.Location.X + OffsetFromParent.X, _parent.Location.Y + OffsetFromParent.Y);
            }
        }

        protected AttachedSprite(Rectangle viewPort, int lifeTimeInMilliSeconds) : base(viewPort)
        {
            ViewPort = viewPort;
            _lifeTimeInMilliSeconds = lifeTimeInMilliSeconds;
        }

        public void Activate()
        {
            if(_lifeTimeInMilliSeconds > 0)
            {
                _lifeTimeTimer = new Timer(new DateTimeNow());
                _lifeTimeTimer.Start(_lifeTimeInMilliSeconds);
            }

            _isActive = true;
        }

        public override void Update(GameTime gameTime)
        {
            if(_lifeTimeInMilliSeconds > 0)
            {
                if(_lifeTimeTimer != null && _lifeTimeTimer.HasTheTimePassed())
                {
                    Inactivate();
                }
            }

            Location = new Vector2(_parent.Location.X + OffsetFromParent.X, _parent.Location.Y + OffsetFromParent.Y);
        }

        public void AttachToParent(Sprite parent, Vector2 offsetFromParent)
        {
            OffsetFromParent = offsetFromParent;
            _parent = parent;
            this.Activate();
        }

        public override void Inactivate()
        {
            base.Inactivate();
            _isActive = false;
        }

        public override bool IsActive
        {
            get { return _isActive; }
        }
    }
}