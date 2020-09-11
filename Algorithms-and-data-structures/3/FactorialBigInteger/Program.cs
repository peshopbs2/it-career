using System;
using System.Numerics;

namespace FactorialBigInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        private static BigInteger Factorial(BigInteger n)
        {
            if(n == 1)
            {
                return 1;
            } else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
