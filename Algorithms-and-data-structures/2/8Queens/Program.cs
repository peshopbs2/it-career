using System;

namespace _8Queens
{
    class Program
    {
        const int N = 8; //change N and see what happens :))
        
        static void Main(string[] args)
        {
            int[,] board = new int[N, N];
            if (Solve(board, 0))
            {
                Print(board);
            } else
            {
                Console.WriteLine("No solution");
            }
        }

        private static void Print(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    char symbol = ((board[i, j] == 0) ? '.' : 'Q');
                    Console.Write("{0, 5}", symbol);
                }
                Console.WriteLine();
            }
        }

        private static bool Solve(int[,] board, int col)
        {
            if (col >= N)
            {
                return true;
            }

            for (int i = 0; i < N; i++)
            {
                if (Place(board, i, col))
                {
                    board[i, col] = 1;
                    if (Solve(board, col + 1)) return true;
                    board[i, col] = 0;
                }
            }
            return false;
        }

        private static bool Place(int[,] board, int row, int col)
        {
            //по колона
            for (int i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                {
                    return false;
                }
            }

            //по диагонал нагоре
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j]==1)
                {
                    return false;
                }
            }
            //по диагонал надолу
            for(int i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j]==1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
