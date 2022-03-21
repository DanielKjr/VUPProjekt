using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace VUPProjekt
{
    

    public abstract class Ui
    {
        public List<string> Cities = new List<string>();
   
        protected Vector2 position;
        protected string spritePath;
        protected Texture2D sprite;
        protected Texture2D rectangleSprite;
        public SpriteFont font;

        public Ui(Vector2 _pos, string _spritePath)
        {
            position = _pos;
            spritePath = _spritePath;
        }


      
        
        public Vector2 Position { get => position; set => position = value; }

        public event EventHandler ButtonClick;

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);

        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spritePath);
            font = content.Load<SpriteFont>("FontPls");
            rectangleSprite = content.Load<Texture2D>("RectangleTexture");
        }

        protected virtual void OnButtonClick()
        {
            ButtonClick?.Invoke(this, new EventArgs());
        }


    
      
    }
}
