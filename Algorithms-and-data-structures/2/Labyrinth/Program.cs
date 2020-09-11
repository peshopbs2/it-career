using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Labyrinth
{
    class Program
    {
        static int rows, cols;
        static bool[,] canVisit;
        static Position exit;
        static string currentSolution = "";
        static List<string> solutions = new List<string>();

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = dimensions[0];
            cols = dimensions[1];

            canVisit = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string inputLine = Console.ReadLine();
                int colIndex = 0;
                foreach (var symbol in inputLine)
                {
                    if (symbol == '-')
                    {
                        canVisit[i, colIndex] = true;
                    }
                    else if(symbol == '*')
                    {
                        canVisit[i, colIndex] = false;
                    }
                    else if (symbol == 'e')
                    {
                        exit = new Position(i, colIndex);
                    }

                    colIndex++;
                }
            }

            Position startPosition = new Position(0, 0);
            Solve(startPosition);
            solutions.ForEach(item => Console.WriteLine(item));
        }

        private static void Solve(Position currentPosition)
        {
            if (currentPosition == exit)
            {
                solutions.Add(currentSolution);
                return;
            }
            else if (!PositionIsOk(currentPosition))
            {
                return;
            } else
            {
                canVisit[currentPosition.Row, currentPosition.Column] = false;
                Position nextPosition = new Position(currentPosition.Row, currentPosition.Column);

                //move down
                nextPosition.Row++;
                currentSolution += "D";
                Solve(nextPosition);
                currentSolution = currentSolution.Remove(currentSolution.Length - 1);
                nextPosition.Row--;

                //move up
                nextPosition.Row--;
                currentSolution += "U";
                Solve(nextPosition);
                currentSolution = currentSolution.Remove(currentSolution.Length - 1);
                nextPosition.Row++;

                //move left
                nextPosition.Column--;
                currentSolution += "L";
                Solve(nextPosition);
                currentSolution = currentSolution.Remove(currentSolution.Length - 1);
                nextPosition.Column++;

                //move right
                nextPosition.Column++;
                currentSolution += "R";
                Solve(nextPosition);
                currentSolution = currentSolution.Remove(currentSolution.Length - 1);
                nextPosition.Column--;

                canVisit[currentPosition.Row, currentPosition.Column] = true;

            }
        }

        private static bool PositionIsOk(Position position)
        {
            if (position.Row < 0 || position.Row >= rows)
            {
                return false;
            }

            if (position.Column < 0 || position.Column >= cols)
            {
                return false;
            }

            return canVisit[position.Row, position.Column];
        }
    }
}
