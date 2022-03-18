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
        private string edgeOne;
        private string edgeTwo;
        private string edgeThree;
        public static Graph<string> graph = new Graph<string>();

        #region OVERLOADS
        public City(Vector2 _pos, string _byNavn) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;

            graph.AddNode(byNavn);


        }

        public City(Vector2 _pos, string _byNavn, string _edgeOne) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne = _edgeOne;
            graph.AddNode(byNavn);
            //graph.AddEdge(byNavn, edgeOne);


        }

        public City(Vector2 _pos, string _byNavn, string _edgeOne, string _edgeTwo) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne= _edgeOne;
            edgeTwo= _edgeTwo;
            graph.AddNode(byNavn);
            //graph.AddEdge(byNavn, edgeOne);
            //graph.AddEdge(byNavn, edgeTwo);


        }


        public City(Vector2 _pos, string _byNavn, string _edgeOne, string _edgeTwo, string _edgeThree) : base(_pos, "byskilt")
        {
            byNavn = _byNavn;
            edgeOne=_edgeOne;
            edgeTwo = _edgeTwo;
            edgeThree= _edgeThree;

            graph.AddNode(byNavn);
            //graph.AddEdge(byNavn, edgeOne);
            //graph.AddEdge(byNavn, edgeTwo);
            //graph.AddEdge(byNavn, edgeThree);


        }

        #endregion


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
        }

        public override void Update(GameTime gameTime)
        {

            //Node<string> n = DFS<string>(graph.NodeSet.Find(x => x.Data == "Skagen"), graph.NodeSet.Find(x => x.Data == "Koebenhavn"));

            //List<Node<string>> path = TrackPath<string>(n, graph.NodeSet.Find(x => x.Data == "Skagen"));

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
