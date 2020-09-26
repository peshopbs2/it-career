using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Graph2
{
    class Program
    {
        private static List<char[]> fullTable;
        private static int rows, cols;
        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            fullTable = new List<char[]>();
            SortedDictionary<char, int> solution =
                new SortedDictionary<char, int>();

            for (int i = 0; i < rows; i++)
            {
                string currentRow = Console.ReadLine();
                fullTable.Add(currentRow.ToCharArray());
            }

            cols = fullTable[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (fullTable[i][j] != '0')
                    {
                        char letter = fullTable[i][j];
                        Traverse(i, j);
                        Print();
                        if(!solution.ContainsKey(letter))
                        {
                            solution.Add(letter, 1);
                        } else
                        {
                            solution[letter]++;
                        }
                    }
                }
            }
            Console.WriteLine(solution.Sum(item => item.Value));
            foreach (var item in solution)
            {
                Console.WriteLine(item.Key + ": "+item.Value);
            }
        }

        private static void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(fullTable[i][j]+ " ");
                }
                Console.WriteLine();
            }
        }

        private static void Traverse(int i, int j)
        {
            if (i < 0 || j < 0 || i >= rows || i >= cols || fullTable[i][j] == '0')
            {
                return;
            }

            char letter = fullTable[i][j];
            fullTable[i][j] = '0';
            if (i -1 >= 0 && fullTable[i - 1][j] == letter)
            {
                Traverse(i - 1, j);
            }

            if (i+1 < rows && fullTable[i + 1][j] == letter)
            {
                Traverse(i + 1, j);
            }

            if (j-1 >= 0 && fullTable[i][j - 1] == letter)
            {
                Traverse(i, j - 1);
            }

            if (j+1 < cols && fullTable[i][j + 1] == letter)
            {
                Traverse(i, j + 1);
            }

        }
    }
}
