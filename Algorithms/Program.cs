using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Trees_and_Graphs;

namespace Algorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            var head = new Node(5);
            var first = new Node(20);
            var second = new Node(7);
            var third = new Node(13);
            var fourth  = new Node(11);
            var fifth = new Node(12);

            head.Next = first;
            first.Next = second;
            second.Next = third;
            third.Next = fourth;
            fourth.Next = fifth;

            //var linkedList = new List<Node>
            //{
            //    head, first, second, third, fourth, fifth
            //};


            //var a = LinkedLists.PartitionAroundX(head, 10);

            //while (a != null)
            //{
            //    Console.WriteLine(a.Data);
            //    a = a.Next;
            //}

            var sumFirst = new Node(7);
            var sumSecond = new Node(1);
            var sumThird = new Node(6);

            var sum1 = new Node(5);
            var sum2 = new Node(9);
            var sum3 = new Node(3);

            sumFirst.Next = sumSecond;
            sumSecond.Next = sumThird;

            sum1.Next = sum2;
            sum2.Next = sum3;

            var nesto = LinkedLists.SumLists2(sumFirst, sum1, 0);

            var graph = new Graph<int>();

            var graphNode1 = new GraphNode<int>(1);
            var graphNode2 = new GraphNode<int>(2);
            var graphNode3 = new GraphNode<int>(3);
            var graphNode4 = new GraphNode<int>(4);

            graphNode1.Children.Add(graphNode2);
            graphNode2.Children.Add(graphNode3);
            graphNode1.Children.Add(graphNode4);

            graph.Nodes.AddRange(new List<GraphNode<int>> {graphNode1, graphNode2, graphNode3, graphNode4});

            TreesAndGraphs.RouteBetweenNodesExists(graph, graphNode1, graphNode4);

            Console.ReadKey();
        }
    }
}
