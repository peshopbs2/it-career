using System;

namespace Permutations
{
    class Program
    {
        public static int[] elements;
        public static int[] perm;
        public static bool[] used;

        static void Permute(int position)
        {
            Console.WriteLine($"Position: {position}. Current used: " + string.Join("", used));
            if (position >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", perm));
            } else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        perm[position] = elements[i];
                        Console.WriteLine("Current perm: " + string.Join("", perm));
                        Permute(position + 1);
                        used[i] = false;
                        perm[i] = 0;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            elements = new int[]{ 1, 2, 3, 4};
            perm = new int[elements.Length];
            used = new bool[elements.Length];
            Permute(0);
        }
    }
}
