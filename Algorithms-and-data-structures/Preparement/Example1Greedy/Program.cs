using System;

namespace Example1Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int sum = days * 20;
            int hundreds = sum / 100;
            int twenties = (sum % 100) / 20;
            int totalVouchers = hundreds + twenties;
            Console.WriteLine(totalVouchers);
            Console.WriteLine($"{hundreds} * 100 + {twenties} * 20");
        }
    }
}
