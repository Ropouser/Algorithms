using System.Collections.Generic;

namespace Algorithms.Trees_and_Graphs
{
    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes = new List<GraphNode<T>>();

        public Graph()
        {}

        public Graph(List<GraphNode<T>> nodes)
        {
            Nodes = nodes;
        }
    }

    public class GraphNode<T>
    {
        public T Data;
        public List<GraphNode<T>> Children;

        public GraphNode(T data)
        {
            Children = new List<GraphNode<T>>();
            Data = data;
        }
    }
}
