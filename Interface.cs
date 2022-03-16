using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace VUPProjekt
{
    

    public class Interface
    {
        public List<string> Cities = new List<string>();
        Graph<string> graph = new Graph<string>();

        public void CreateNodes()
        {
            graph.AddNode("Skagen");
            graph.AddNode("Frederikshavn");
            graph.AddNode("Aalborg");
            graph.AddNode("Holsterbro");
            graph.AddNode("Viborg");
            graph.AddNode("Randers");
            graph.AddNode("Grenå");
            graph.AddNode("Herning");
            graph.AddNode("Århus");
            graph.AddNode("Billund");
            graph.AddNode("Vejle");
            graph.AddNode("Esbjerg");
            graph.AddNode("Kolding");
            graph.AddNode("Odense");

            graph.AddEdge("Skagen", "frederikshavn");
            graph.AddEdge("Skagen", "Aalborg");

            graph.AddEdge("Frederikshavn", "Aalborg");

            graph.AddEdge("Aalborg", "Viborg");
            graph.AddEdge("Aalborg", "Randers");

            graph.AddEdge("Holsterbro", "Viborg");
            graph.AddEdge("Holsterbro", "Herning");
            graph.AddEdge("Holsterbro", "Esbjerg");

            graph.AddEdge("Viborg", "Herning");
            graph.AddEdge("Viborg", "Randers");

            graph.AddEdge("Randers", "Grenå");
            graph.AddEdge("Randers", "Århus");

            graph.AddEdge("Grenå", "Århus");

            graph.AddEdge("Herning", "Århus");
            graph.AddEdge("Herning", "Billund");

            graph.AddEdge("Århus", "Vejle");

            graph.AddEdge("Billund", "Vejle");
            graph.AddEdge("Billund", "Esbjerg");

            graph.AddEdge("Vejle", "Kolding");

            graph.AddEdge("Esbjerg", "Kolding");

            graph.AddEdge("Kolding", "Odense");
        }
        
        

        public event EventHandler ButtonClick;


        private void Draw(SpriteBatch spriteBatch)
        {

        }

        private void LoadContent(ContentManager content)
        {

        }

        protected virtual void OnButtonClick()
        {
            ButtonClick?.Invoke(this, new EventArgs());
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
