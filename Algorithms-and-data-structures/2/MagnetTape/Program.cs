using System;
using System.Collections.Generic;
using System.Linq;

namespace MagnetTape
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Operation> operations = new List<Operation>();
            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "END")
            {
                operations.Add(new Operation()
                {
                    Id = int.Parse(input[0]),
                    Length = int.Parse(input[1]),
                    Probability = double.Parse(input[2])
                });

                input = Console.ReadLine().Split(' ');
            }

            var result = operations.OrderByDescending(item => item.Ratio).ToList();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
