using System;
using System.Collections.Generic;

namespace VUPProjekt
{
    public class Graph<T>
    {

        public List<Node<T>> NodeSet { get; private set; } = new List<Node<T>>();


        public void AddNode(T value)
        {
            NodeSet.Add(new Node<T>(value));
        }

        public void AddDirectionEdge(T from, T to)
        {
            Node<T> fromNode = NodeSet.Find(x => x.Data.Equals(from));
            Node<T> toNode = NodeSet.Find(x => x.Data.Equals(to));

            if (!fromNode.Equals(default(T)) && !toNode.Equals(default(T)))
            {
                fromNode.AddEdge(toNode);
            }
            else
            {
               // Console.WriteLine("Node not found");
            }

        }

        public void AddEdge(T from, T to)
        {
            Node<T> fromNode = NodeSet.Find(x => x.Data.Equals(from));

            Node<T> toNode = NodeSet.Find(x => x.Data.Equals(to));

            if (!fromNode.Equals(default(T)) && !toNode.Equals(default(T)))
            {
                fromNode.AddEdge(toNode);
                toNode.AddEdge(fromNode);
            }
            else
            {
                
               // Console.WriteLine("Node not found!");
            }


        }

    }
}
