using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPProjekt
{
    public class City : Ui
    {
        protected string byNavn;


        public City(Vector2 _pos, string _byNavn) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, byNavn, new Vector2(position.X +10, position.Y +5), Color.Black);
        }

    }
}
