using System;
using System.Linq;

namespace AlleyIterative
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int alleyLength = data[0];
            int tilesCount = data[1];

            int[] tiles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] solution = new int[alleyLength + 1];

            solution[0] = 1; //there is one way to form an alley with length 0 - with 0 tiles

            for(int i = 1; i <= alleyLength; i++)
            {
                for(int j = 0; j < tilesCount; j++)
                {
                    if(i - tiles[j] >= 0)
                    {
                        solution[i] += solution[i - tiles[j]];
                    }
                }
            }

            for (int i = 0; i < solution.Length; i++)
            {
                Console.WriteLine($"{i} -> {solution[i]}");
            }
            Console.WriteLine("Hello World!");
        }
    }
}
