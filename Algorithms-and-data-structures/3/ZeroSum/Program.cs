using System;
using System.Collections.Generic;
using System.Linq;

namespace ZeroSum
{
    class Program
    {
        static int length = 0;
        static Variation currentVariation;
        static List<Variation> allVariations; //contains all possible variations to check
        static void Main(string[] args)
        {
            currentVariation = new Variation();
            allVariations = new List<Variation>();

            length = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Variations(0);

            foreach (Variation item in allVariations)
            {
                int sum = item.Sum(numbers);
                if (sum == 0)
                {
                    Console.WriteLine($"{item} -> {item.Sum(numbers)}");
                }
            }
        }

        private static void Variations(int position)
        {
            if (position == length)
            {
                bool[] varation = new bool[currentVariation.Count];
                currentVariation.Elements.CopyTo(varation, 0);
                allVariations.Add(new Variation(varation.ToList()));
                return;
            }
            else
            {
                // -
                currentVariation.Elements.Add(false);
                Variations(position + 1);
                currentVariation.Elements.RemoveAt(position);

                // +
                currentVariation.Elements.Add(true);
                Variations(position + 1);
                currentVariation.Elements.RemoveAt(position);

            }
        }
    }
}
