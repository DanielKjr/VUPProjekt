using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPProjekt
{
    public class Road : Ui
    {
        
        public List<Road> Roads = new List<Road>();

        private bool isVisible;

        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public Vector2 Position { get => position; set => position = value; }


        public Road(Vector2 _pos) : base(_pos, "RectangleTexture")
        {
            //something with a rectangle
        }



        private void DisplayRoad()
        {

        }


    }
}
