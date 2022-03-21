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
        protected string edgeOne;
        protected string edgeTwo;
        protected string edgeThree;

        public static bool hasRun = false;
        public Node<string> cityNode;

        public static List<Vector2> drawPath = new List<Vector2>();
        public static List<City> drawCity = new List<City>();

        public static Graph<string> graph = new Graph<string>();

        public static List<Rectangle> roads = new List<Rectangle>();

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
            edgeOne= _edgeOne;
            edgeTwo= _edgeTwo;
            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);

        }


        public City(Vector2 _pos, string _byNavn, string _edgeOne, string _edgeTwo, string _edgeThree) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne=_edgeOne;
            edgeTwo = _edgeTwo;
            edgeThree= _edgeThree;
            cityNode = new Node<string>(byNavn);
            graph.AddNode(byNavn);

        }

        #endregion

        public void FindRoad()
        {
            if (!hasRun)
            {
                Node<string> n = DFS<string>(graph.NodeSet.Find(x => x.Data == "Skagen"), graph.NodeSet.Find(x => x.Data == "Esbjerg"));
               // Node<string> n = BFS<string>(graph.NodeSet.Find(x => x.Data == "Skagen"), graph.NodeSet.Find(x => x.Data == "Esbjerg"));

                List<Node<string>> path = TrackPath<string>(n, graph.NodeSet.Find(x => x.Data == "Skagen"));

                for (int i = 0; i < path.Count; i++)
                {

                    drawCity.Add(GameWorld.cities.Find(x => x.cityNode.Data == path[i].Data));

                  
                }

                for (int i = 1; i < drawCity.Count; i++)
                {

                    for (int b = 0; b < drawCity.Count; b++)
                    {
                        if (i <= drawCity.Count - 1 && b <= drawCity.Count -1)
                            DrawRoad(drawCity[b], drawCity[i]);

                    }



                }

                hasRun = true;
            }
           
        }

        public void DrawRoad(City start, City target)
        {
            //roads.Add(new Rectangle((int)start.position.X + 50, (int)start.position.Y+20, 10, (int)Vector2.Distance(start.position, target.position)));
            //roads.Add(new Rectangle((int)start.position.X + 50, (int)target.position.Y + 20, 10, ((int)start.position.Y - (int)target.position.Y)));

            roads.Add(new Rectangle((int)start.position.X, (int)start.position.Y, 10, 50));
        }

        public void CreateEdges()
        {
            if (edgeOne != null && edgeTwo != null && edgeThree != null)
            {
              
                graph.AddEdge(byNavn, edgeOne);
                graph.AddEdge(byNavn, edgeTwo);
                graph.AddEdge(byNavn, edgeThree);

            }
            if (edgeOne != null && edgeTwo != null)
            {
   
                graph.AddEdge(byNavn, edgeOne);
                graph.AddEdge(byNavn, edgeTwo);
            }
            else if(edgeOne != null)
            {
                graph.AddEdge(byNavn, edgeOne);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, byNavn, new Vector2(position.X + 10, position.Y + 5), Color.Black);

            if (roads != null)
            {
                foreach (var road in roads)
                    spriteBatch.Draw(rectangleSprite, road, Color.Red);
            }
           
        }

        public override void Update(GameTime gameTime)
        {

          


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
