using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CazualGames.Controls
{
    public class Button
    {
        private bool _isActive = true;
        private bool _isPressed;
        private Vector2 _topRight;
        private int _width;
        private int _height;
        private bool _wasPressed = true;
        private bool _singleClick;
        private IButtonInputController _buttonInputController;

        public  IButtonInputController ButtonInputController
        {
            get { return _buttonInputController; }
            set { _buttonInputController = value; }
        }


        public Button(Vector2 topRight, int width, int height, bool singleClick)
        {
            _topRight = topRight;
            _width = width;
            _height = height;
            _singleClick = singleClick;
        }

        public void Update()
        {
            if (!_isActive)
                return;

            if(_buttonInputController == null)
                _buttonInputController = new ButtonInputController();

            _buttonInputController.Update(this);
        }

        
        public bool IsPressed
        {
            get { return _isPressed; }
            set { _isPressed = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
        }

        public bool WasPressed
        {
            get { return _wasPressed; }
            set { _wasPressed = value; }
        }

        public bool SingleClick
        {
            get { return _singleClick; }
        }

        public Vector2 TopRight
        {
            get { return _topRight; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public string Tag { get; set; }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture2D)
        {
            if (_isActive)
                spriteBatch.Draw(texture2D, new Rectangle((int)_topRight.X, (int)_topRight.Y, _width, _height), new Rectangle(0, 0, texture2D.Width, texture2D.Height), Color.White);
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void DeActivate()
        {
            _isActive = false;
        }

        public override bool Equals(object obj)
        {
            if(obj is Button)
            {
                return ((Button)obj).TopRight.X == this.TopRight.X &&
                    ((Button)obj).TopRight.Y == this.TopRight.Y;
            }

            return false;
        }
    }
}
