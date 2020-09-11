using System;
using System.Collections.Generic;
using System.Linq;

namespace DistributionSum
{
    class Program
    {
        static List<int> currentSolution;
        static List<string> allSolutions;
        static void Main(string[] args)
        {
            currentSolution = new List<int>();
            allSolutions = new List<string>();
            int n = int.Parse(Console.ReadLine());
            Solve(n, 0);
            allSolutions.ForEach(item => Console.WriteLine(item));
        }

        //position shows how many numbers are in this distribution
        private static void Solve(int n, int position)
        {
            if(n <= 0 && position > 1) // && position > 1 prevents the number from showing as distribution for itself
            {
                int[] solution = new int[currentSolution.Count];
                currentSolution.CopyTo(solution);
                solution = solution.OrderByDescending(x => x).ToArray();

                string solutionRepresentation = string.Join(" + ", solution);
                if (IsUnique(solutionRepresentation)) //TODO: check for unique
                {
                    allSolutions.Add(solutionRepresentation);
                }
                return;
            } else
            {
                for (int k = n; k >= 1; k--)
                {
                    currentSolution.Add(k);
                    Solve(n - k, position + 1);
                    currentSolution.RemoveAt(position);
                }
            }
        }

        private static bool IsUnique(string solutionRepresentation)
        {
            return !allSolutions.Contains(solutionRepresentation); //return negated value - if solutuons is not contained -> true 
        }
    }
}
