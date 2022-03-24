using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPProjekt
{
    public class City : Ui
    {
        protected string byNavn;
        protected string edgeOne;
        protected string edgeTwo;
        protected string edgeThree;
        protected string edgeFour;



        public static bool hasRun = false;
        public Node<string> cityNode;
        public static bool DFSRun = false;
        public static bool BFSRun = false;
        public static bool ResetRun = false;


        public static List<Vector2> drawPath = new List<Vector2>();
        public static List<City> drawCity = new List<City>();

        public static Graph<string> graph = new Graph<string>();

        public static List<Rectangle> roads = new List<Rectangle>();
        public static List<Rectangle> constantRoads = new List<Rectangle>();
        private static List<float> angles = new List<float>();
        private static List<float> constantAngles = new List<float>();
        private Node<string> n;
        public static List<Node<string>> path = new List<Node<string>>();


        private Color cColor = Color.White;

        public Color CColer { get { return cColor; } set { cColor = value; } }


        #region OVERLOADS
        public City(Vector2 _pos, string _byNavn) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);

        }

        public City(Vector2 _pos, string _byNavn, string _edgeOne) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne = _edgeOne;

            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);
 
        }

        public City(Vector2 _pos, string _byNavn, string _edgeOne, string _edgeTwo) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne = _edgeOne;
            edgeTwo = _edgeTwo;
            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);
        }


        public City(Vector2 _pos, string _byNavn, string _edgeOne, string _edgeTwo, string _edgeThree) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne = _edgeOne;
            edgeTwo = _edgeTwo;
            edgeThree = _edgeThree;
            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);
    
        }
        public City(Vector2 _pos, string _byNavn, string _edgeOne, string _edgeTwo, string _edgeThree, string _edgeFour) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne = _edgeOne;
            edgeTwo = _edgeTwo;
            edgeThree = _edgeThree;
            edgeFour = _edgeFour;
            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);
    
        }

        #endregion

        public void FindRoad(string start, string end)
        {
            if (!hasRun)
            {
                if (DFSRun == true)
                {
                    n = DFS<string>(graph.NodeSet.Find(x => x.Data == end), graph.NodeSet.Find(x => x.Data == start)); //Civiliserede folk kører i højre side af vejen!

                    path = TrackPath<string>(n, graph.NodeSet.Find(x => x.Data == end));

                    for (int i = 0; i < path.Count; i++)
                    {

                        drawCity.Add(GameWorld.cities.Find(x => x.cityNode.Data == path[i].Data));


                    }
                }
                else if (BFSRun == true)
                {
                    n = BFS<string>(graph.NodeSet.Find(x => x.Data == end), graph.NodeSet.Find(x => x.Data == start));

                    path = TrackPath<string>(n, graph.NodeSet.Find(x => x.Data == end));
                    
                    for (int i = 0; i < path.Count; i++)
                    {

                        drawCity.Add(GameWorld.cities.Find(x => x.cityNode.Data == path[i].Data));


                    }
                }

                hasRun = true;
            }

        }
        public void DrawRoad(City start, City target)
        {

            roads.Add(new Rectangle((int)start.position.X + 40, (int)start.position.Y + 10, 10, (int)Vector2.Distance(start.position, target.position)));
            angles.Add((float)Math.Atan2(start.position.X - target.position.X, target.position.Y - start.position.Y));
        }
        public static void BruteForceConstantRoads()
        {
            foreach (var start in GameWorld.cities)
            {
                if (start.edgeOne != null)
                {
                    foreach (var edge in GameWorld.cities)
                    {
                        if (edge.byNavn == start.edgeOne)
                        {
                            CreateConstantRoads(start, edge);
                            break;
                        }
                    }
                }
                if (start.edgeTwo != null)
                {
                    foreach (var edge in GameWorld.cities)
                    {
                        if (edge.byNavn == start.edgeTwo)
                        {
                            CreateConstantRoads(start, edge);
                            break;
                        }
                    }
                }
                if (start.edgeThree != null)
                {
                    foreach (var edge in GameWorld.cities)
                    {
                        if (edge.byNavn == start.edgeThree)
                        {
                            CreateConstantRoads(start, edge);
                            break;
                        }
                    }
                }
                if (start.edgeFour != null)
                {
                    foreach (var edge in GameWorld.cities)
                    {
                        if (edge.byNavn == start.edgeFour)
                        {
                            CreateConstantRoads(start, edge);
                            break;
                        }
                    }
                }
            }
        }
        public static void CreateConstantRoads(City start, City target)
        {
            constantRoads.Add(new Rectangle((int)start.position.X + 40, (int)start.position.Y + 10, 10, (int)Vector2.Distance(start.position, target.position)));
            constantAngles.Add((float)Math.Atan2(start.position.X - target.position.X, target.position.Y - start.position.Y));
        }



        public void CreateEdges()
        {
            if (edgeFour != null)
            {
                graph.AddEdge(byNavn, edgeFour);
            }
            if (edgeThree != null)
            {
                graph.AddEdge(byNavn, edgeThree);
            }
            if (edgeTwo != null)
            {
                graph.AddEdge(byNavn, edgeTwo);
            }
            if (edgeOne != null)
            {
                graph.AddEdge(byNavn, edgeOne);
            }
        }

        public static bool hasRunRoad = false;
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (roads != null && angles != null && hasRunRoad == false)
            {
                int runs = 0;
                foreach (var road in constantRoads) // Print background roads
                {
                    spriteBatch.Draw(rectangleSprite, new Vector2(road.X, road.Y), road, Color.Black, constantAngles[runs], Vector2.Zero, 1f, SpriteEffects.None, 0);
                    runs++;
                }
                runs = 0;
                foreach (var road in roads) // Print chosen path
                {
                    spriteBatch.Draw(rectangleSprite, new Vector2(road.X, road.Y), road, Color.Red, angles[runs], Vector2.Zero, 1f, SpriteEffects.None, 0);
                    runs++;
                }
                hasRunRoad = true;
            }
            spriteBatch.Draw(sprite, position, null, CColer, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, byNavn, new Vector2(position.X + 10, position.Y + 5), Color.Black);
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
