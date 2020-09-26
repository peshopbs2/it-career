using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Graphs;

namespace Task1Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            Graph graph = new Graph(true); //oriented
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(':');
                int vertex = int.Parse(data[0]);
                if (data[1].Trim() != "")
                {
                    int[] neighbours = data[1].Split(' ').Select(int.Parse).ToArray();

                    foreach (var neighbour in neighbours)
                    {
                        graph.AddEdge(vertex, neighbour);
                    }
                }
            }
            graph.Print();

            for (int i = 0; i < p; i++)
            {
                string[] pair = Console.ReadLine().Split('-');
                int start = int.Parse(pair[0]);
                int end = int.Parse(pair[1]);

                Console.WriteLine(graph.GetLevel(start, end));
            }
        }
    }
}
