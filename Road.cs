using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPProjekt
{
    public class Road
    {
        
        public List<Road> Roads = new List<Road>();

        private Vector2 position;
        private bool isVisible;

        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public Vector2 Position { get => position; set => position = value; }


        private void DisplayRoad()
        {

        }

        private void Draw(SpriteBatch spriteBatch)
        {

        }

        private void LoadContent(ContentManager content)
        {

        }

    }
}
