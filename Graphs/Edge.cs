namespace VUPProjekt
{
    public class Edge<T>
    {
        public Node<T> From { get; private set; }
        public Node<T> To { get; private set; }

        public Edge(Node<T> from, Node<T> to)
        {
            this.To = to;
            this.From = from;
        }
    }
}
