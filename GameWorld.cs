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
        public Graph<string> graph;
        public List<City> cities = new List<City>();

        public List<Edge<string>> edging = new List<Edge<string>>();

        public Dictionary<Edge<string>, Road> roads = new Dictionary<Edge<string>, Road>();




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

            CreateNodes();





            cities.Add(new City(new Vector2(600, 40), "Skagen"));
            cities.Add(new City(new Vector2(590, 140), "Frederikshavn"));
            cities.Add(new City(new Vector2(470, 275), "Aalborg"));
            cities.Add(new City(new Vector2(235, 300), "Thisted"));
            cities.Add(new City(new Vector2(225, 525), "Holsterbro"));
            cities.Add(new City(new Vector2(375, 500), "Viborg"));
            cities.Add(new City(new Vector2(500, 500), "Randers"));
            cities.Add(new City(new Vector2(660, 520), "Grenaa"));
            cities.Add(new City(new Vector2(300, 600), "Herning"));
            cities.Add(new City(new Vector2(500, 600), "Aarhus"));
            cities.Add(new City(new Vector2(210, 750), "Oelgod"));
            cities.Add(new City(new Vector2(400, 775), "Vejle"));
            cities.Add(new City(new Vector2(175, 840), "Esbjerg"));
            cities.Add(new City(new Vector2(390, 830), "Kolding"));
            cities.Add(new City(new Vector2(575, 875), "Odense"));
            cities.Add(new City(new Vector2(1000, 775), "Koebenhavn"));
            cities.Add(new City(new Vector2(775, 875), "Slagelse"));
            cities.Add(new City(new Vector2(850, 775), "Holbaek"));
            cities.Add(new City(new Vector2(675, 770), "Kalundborg"));
            cities.Add(new City(new Vector2(900, 900), "Haslev"));

            Node<string> n = DFS<string>(graph.NodeSet.Find(x => x.Data == "Skagen"), graph.NodeSet.Find(x => x.Data == "Koebenhavn"));

            

            List<Node<string>> path = TrackPath<string>(n, graph.NodeSet.Find(x => x.Data == "Skagen"));

           

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


            _spriteBatch.Draw(danishMap, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

            foreach (City c in cities)
            {
                c.Draw(_spriteBatch);


            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void CreateNodes()
        {
            graph = new Graph<string>();
            graph.AddNode("Skagen");
            graph.AddNode("Frederikshavn");
            graph.AddNode("Aalborg");
            graph.AddNode("Thisted");
            graph.AddNode("Holsterbro");
            graph.AddNode("Viborg");
            graph.AddNode("Randers");
            graph.AddNode("Grenaa");
            graph.AddNode("Herning");
            graph.AddNode("Aarhus");
            graph.AddNode("Oelgod");
            graph.AddNode("Thisted");
            graph.AddNode("Vejle");
            graph.AddNode("Esbjerg");
            graph.AddNode("Kolding");
            graph.AddNode("Odense");
            graph.AddNode("Koebenhavn");
            graph.AddNode("Slagelse");
            graph.AddNode("Holbaek");
            graph.AddNode("Kalundborg");
            graph.AddNode("Haslev");




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


        private static List<Node<T>> TrackPath<T>(Node<T> node, Node<T> start)
        {
            List<Node<T>> path = new List<Node<T>>();

            while (!node.Equals(start))
            {
                path.Add(node);
                node = node.Parent;
            }
            path.Add(start);

            path.Reverse();


            return path;
        }


        private static Node<T> DFS<T>(Node<T> start, Node<T> goal)
        {
            Stack<Edge<T>> edges = new Stack<Edge<T>>();
            edges.Push(new Edge<T>(start, start));

            while (edges.Count > 0)
            {
                Edge<T> edge = edges.Pop();

                if (!edge.To.Discovered)
                {
                    edge.To.Discovered = true;
                    edge.To.Parent = edge.From;

                }
                if (edge.To == goal)
                {
                    return edge.To;
                }

                foreach (Edge<T> e in edge.To.Edges)
                {
                    if (!e.To.Discovered)
                    {
                        edges.Push(e);
                    }
                }

            }

            return null;
        }



        private static Node<T> BFS<T>(Node<T> start, Node<T> goal)
        {
            Queue<Edge<T>> edges = new Queue<Edge<T>>();
            edges.Enqueue(new Edge<T>(start, start));

            while (edges.Count > 0)
            {
                Edge<T> edge = edges.Dequeue();

                if (!edge.To.Discovered)
                {
                    edge.To.Discovered = true;
                    edge.To.Parent = edge.From;
                }
                if (edge.To == goal)
                {
                    return edge.To;
                }

                foreach (Edge<T> e in edge.To.Edges)
                {
                    if (!e.To.Discovered)
                    {
                        edges.Enqueue(e);
                    }
                }
            }

            return null;
        }
    }
}
