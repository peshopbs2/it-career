using System;
using System.Collections.Generic;
using System.Linq;

namespace UniverseSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine().Split(
                new char[] {',', ' '},
                StringSplitOptions.RemoveEmptyEntries
                )
                .Select(int.Parse)
                .ToList();

            List<List<int>> subsets = new List<List<int>>();
            int totalSubsets = int.Parse(Console.ReadLine());
            for (int i = 0; i < totalSubsets; i++)
            {
                List<int> currentList = Console.ReadLine()
                    .Split(new char[] { ',', ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();

                subsets.Add(currentList);
            }

            List<string> result = new List<string>();
            subsets = subsets.OrderByDescending(item => item.Count).ToList();
            foreach (var set in subsets) //за всяко множество
            {
                bool isResultSet = false;
                foreach (var item in set) //за всеки елемент от множеството
                {
                    if (universe.Contains(item))
                    {
                        universe.Remove(item);
                        isResultSet = true;
                    }
                }
                if (isResultSet)
                {
                    result.Add(string.Join(", ", set));
                }
            }
            Console.WriteLine($"Number of subsets: {result.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
