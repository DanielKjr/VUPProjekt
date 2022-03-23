using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPProjekt
{
    internal class Button : Component
    {


        private MouseState _currentMouse;
        private MouseState _previousMouse;

        private Texture2D _sprite;
        private bool isHovering;
        private float spriteScale = 1;

        public event EventHandler CityClick;
        public event EventHandler ResetClick;
        public event EventHandler DFSClick;
        public event EventHandler BFSClick;

        public bool Clicked { get; private set; }
        public Color PenColor { get; set; }
        //  private Color color = Color.White;
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y,(int)(_sprite.Width * 0.5f), (int)(_sprite.Height * 0.5f));
            }
        }

        public Button(Texture2D sprite)
        {
            _sprite = sprite;
            spriteScale = 0.5f;
            PenColor = Color.Black;
        }


        public string Text { get; set; }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (isHovering == true)
            {
                color = Color.Gray;
            }


            spriteBatch.Draw(_sprite, Position, null, color, 0f, Vector2.Zero, spriteScale, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {

                        DFSClick?.Invoke(this, new EventArgs());
                        BFSClick?.Invoke(this, new EventArgs());
                        ResetClick?.Invoke(this, new EventArgs());

                }
            }
        }

    }
}
