using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPProjekt
{
    public class City : Ui
    {
        private string byNavn;

        public City(Vector2 _pos, string _byNavn) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;

        }
    }
}
