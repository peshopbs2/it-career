using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TreeOperations
{
    class Program
    {
        static Dictionary<int, Tree<int>> treeByValue = 
            new Dictionary<int, Tree<int>>();

        static void Main(string[] args)
        {
            int edgesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < edgesCount - 1; i++)
            {
                int[] vertices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int parent = vertices[0];
                int child = vertices[1];
                AddEdge(parent, child);
            }

            Tree<int> root = GetRoot();
            Console.WriteLine($"Root = {root.Value}");
            Print(root, 0);
            Console.WriteLine("Leaves: ");
            PrintLeaves();
        }

        private static void PrintLeaves()
        {
            List<Tree<int>> leaves = treeByValue.Values
                .Where(item => item.Children.Count == 0)
                .ToList();
            leaves.ForEach(item => Console.Write(item.Value + " "));
        }

        private static void Print(Tree<int> node, int level)
        {
            if (node == null) return;
            Console.WriteLine($"{new string(' ', level * 3) + node.Value}");
            foreach (Tree<int> child in node.Children)
            {
                Print(child, level + 1);
            }
        }

        private static Tree<int> GetRoot()
        {
            return treeByValue.Values.FirstOrDefault(item => item.Parent == null);
        }

        private static void AddEdge(int parent, int child)
        {
            Tree<int> parentTree = GetTreeById(parent);
            Tree<int> childTree = GetTreeById(child);

            parentTree.Children.Add(childTree);
            childTree.Parent = parentTree;
        }

        private static Tree<int> GetTreeById(int vertex)
        {
            if (!treeByValue.ContainsKey(vertex))
            {
                treeByValue.Add(vertex, new Tree<int>(vertex));
            }

            return treeByValue[vertex];
        }


    }
}
