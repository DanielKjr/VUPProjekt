using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace VUPProjekt
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D danishMap;
        

        public static List<City> cities = new List<City>();



        //bruges ikke men keep just in case cus we're hoarders
        private List<Edge<string>> edging = new List<Edge<string>>();
        private Dictionary<Edge<string>, Road> roads = new Dictionary<Edge<string>, Road>();
        private Graph<string> graph = new Graph<string>();


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1050;
            _graphics.ApplyChanges();





            cities.Add(new City(new Vector2(590, 140), "Frederikshavn", "Aalborg", "Skagen"));
            cities.Add(new City(new Vector2(600, 40), "Skagen", "Frederikshavn"));
            cities.Add(new City(new Vector2(470, 275), "Aalborg", "Thisted", "Randers", "Frederikshavn"));
            cities.Add(new City(new Vector2(235, 300), "Thisted", "Holsterbro", "Aalborg"));
            cities.Add(new City(new Vector2(225, 525), "Holsterbro", "Viborg", "Thisted"));
            cities.Add(new City(new Vector2(375, 500), "Viborg", "Randers", "Herning", "Holsterbro"));
            cities.Add(new City(new Vector2(500, 500), "Randers", "Grenaa", "Aarhus", "Viborg", "Aalborg")); //QUAD
            cities.Add(new City(new Vector2(660, 520), "Grenaa", "Aarhus", "Randers"));
            cities.Add(new City(new Vector2(300, 600), "Herning", "Oelgod","Viborg"));
            cities.Add(new City(new Vector2(500, 600), "Aarhus", "Vejle","Randers","Grenaa"));
            cities.Add(new City(new Vector2(210, 750), "Oelgod", "Esbjerg","Herning"));
            cities.Add(new City(new Vector2(400, 775), "Vejle", "Kolding","Aarhus"));
            cities.Add(new City(new Vector2(175, 840), "Esbjerg", "Kolding","Oelgod"));
            cities.Add(new City(new Vector2(390, 830), "Kolding", "Esbjerg", "Vejle", "Odense"));
            cities.Add(new City(new Vector2(575, 875), "Odense", "Slagelse","Kolding"));
            cities.Add(new City(new Vector2(1000, 775), "Koebenhavn","Holbaek"));
            cities.Add(new City(new Vector2(775, 875), "Slagelse", "Odense", "Haslev", "Holbaek"));
            cities.Add(new City(new Vector2(850, 775), "Holbaek", "Koebenhavn", "Kalundborg","Slagelse"));
            cities.Add(new City(new Vector2(675, 770), "Kalundborg","Holbaek"));
            cities.Add(new City(new Vector2(900, 900), "Haslev","Slagelse"));


            foreach (City item in cities)
            {
                item.CreateEdges();
            }
            City.BruteForceConstantRoads();

            foreach (City c in cities)
            {
                //static bool gør den kun køres 1 gang, skal have den heg for at kunne tilgå en instans af city og bruge method
                c.FindRoad();
            }
            

           






            base.Initialize();
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            danishMap = Content.Load<Texture2D>("Danmarks Kort");


            foreach (City c in cities)
            {
                c.LoadContent(Content);
            }


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.Draw(danishMap, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0);

            foreach (City c in cities)
            {
                c.Draw(_spriteBatch);


            }
            City.hasRunRoad = false;

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void CreateNodes()
        {

            //graph.AddNode("Skagen");
            //graph.AddNode("Frederikshavn");
            //graph.AddNode("Aalborg");
            //graph.AddNode("Thisted");
            //graph.AddNode("Holsterbro");
            //graph.AddNode("Viborg");
            //graph.AddNode("Randers");
            //graph.AddNode("Grenaa");
            //graph.AddNode("Herning");
            //graph.AddNode("Aarhus");
            //graph.AddNode("Oelgod");
            //graph.AddNode("Thisted");
            //graph.AddNode("Vejle");
            //graph.AddNode("Esbjerg");
            //graph.AddNode("Kolding");
            //graph.AddNode("Odense");
            //graph.AddNode("Koebenhavn");
            //graph.AddNode("Slagelse");
            //graph.AddNode("Holbaek");
            //graph.AddNode("Kalundborg");
            //graph.AddNode("Haslev");




            graph.AddEdge("Skagen", "Frederikshavn");

            graph.AddEdge("Frederikshavn", "Aalborg");

            graph.AddEdge("Aalborg", "Thisted");
            graph.AddEdge("Aalborg", "Randers");

            graph.AddEdge("Thisted", "Holsterbro");

            graph.AddEdge("Holsterbro", "Viborg");

            graph.AddEdge("Viborg", "Randers");
            graph.AddEdge("Viborg", "Herning");

            graph.AddEdge("Randers", "Grenaa");
            graph.AddEdge("Randers", "Aarhus");

            graph.AddEdge("Herning", "Oelgod");

            graph.AddEdge("Oelgod", "Esbjerg");

            graph.AddEdge("Aarhus", "Vejle");

            graph.AddEdge("Kolding", "Esbjerg");
            graph.AddEdge("Kolding", "Vejle");
            graph.AddEdge("Kolding", "Odense");

            graph.AddEdge("Slagelse", "Odense");
            graph.AddEdge("Slagelse", "Haslev");
            graph.AddEdge("Slagelse", "Holbaek");

            graph.AddEdge("Holbaek", "Koebenhavn");
            graph.AddEdge("Holbaek", "Kalundborg");


            foreach (Node<string> item in graph.NodeSet)
            {
                foreach (Edge<string> e in item.Edges)
                {
                    edging.Add(e);
                    roads.Add(e, new Road(new Vector2(500, 500)));
                }
            }



        }



    }
}
