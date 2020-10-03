using System;
using System.Linq;

namespace Example2
{
    class Program
    {
        static int Multiply(int m, int n)
        {
            if (n == 0 || m == 0) return 0;
            if (n == 1)
            {
                return m;
            } else
            {
                return Multiply(m, n - 1) + m;
            }
        }
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Multiply(nums[0], nums[1]));
        }
    }
}
