using System;
using System.Collections.Generic;

namespace BFS
{

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);

            graph.AddEdge(2, 7);

            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);

            graph.AddEdge(4, 5);
            graph.AddEdge(4, 6);

            graph.AddEdge(6, 8);

            graph.AddEdge(7, 5);

            graph.Print();

            List<Graph.Node> traversal = graph.BFS(graph.Nodes[2]);
            Console.Write("BFS: ");
            traversal.ForEach(item => Console.Write(item.Value+ ", "));
            Console.WriteLine();
            Console.Write("DFS: ");
            List<Graph.Node> dfstraversal = graph.DFS(graph.Nodes[4]);
            dfstraversal.ForEach(item => Console.Write(item.Value + ", "));

        }
    }
}
