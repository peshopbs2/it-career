using System;
using System.Numerics;

namespace Izpit1zad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= 2;
            }
            Console.WriteLine(result);
        }
    }
}
