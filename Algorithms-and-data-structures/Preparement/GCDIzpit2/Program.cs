using System;
using System.Linq;

namespace GCDIzpit2
{
    class Program
    {
        static int GCD(int num1, int num2) //Greatest Common Divisor
        {
            if (num2==0)
            {
                return num1;
            } else
            {
                return GCD(num2, num1 % num2);
            }
        }
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int result = numbers.Aggregate(GCD);
//           int gcd1 = GCD(numbers[0], numbers[1]);
//           int gcd2 = GCD(numbers[2], numbers[3]);
//           int totalGcd = GCD(gcd1, gcd2);
//           Console.WriteLine(totalGcd);
            Console.WriteLine(result);
        }
    }
}
