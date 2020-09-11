using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace KnightMoves
{
    class Program
    {
        const int N = 5;
        static bool[,] board;
        static Stack<Tuple<int, int>> moves = new Stack<Tuple<int, int>>();
        static Tuple<int, int> position = new Tuple<int, int>(0, 0);

        static void Main(string[] args)
        {
            moves.Push(position);
            board = new bool[N, N];
            board[0, 0] = true;
            TryMove(2);
            if (moves.Count == 1)
            {
                Console.WriteLine("No solution found!"); return;
            }

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    var counter = N * N - moves.TakeWhile(item =>
                      item != moves
                      .Where(item2 => item2.Item1 == row && item2.Item2 == col)
                      .FirstOrDefault())
                       .Count();
                    Console.Write("{0, 5}", counter);
                }
                Console.WriteLine();
            }
        }

        private static bool TryMove(int moveNumber)
        {
            bool result = false;
            List<Tuple<int, int>> availableMoves = GetMoves();
            for (int i = 0; i < availableMoves.Count; i++)
            {
                //Item1 - row, Item2 - column
                position = new Tuple<int, int>(availableMoves[i].Item1, availableMoves[i].Item2);
                board[position.Item1, position.Item2] = true;
                moves.Push(position);
                if (moveNumber == N*N)
                {
                    return true;
                }
                result = TryMove(moveNumber + 1);
                if (result == false)
                {
                    board[position.Item1, position.Item2] = false;
                    moves.Pop();
                    position = moves.Peek();
                } else
                {
                    break;
                }
            }

            return result;
        }

        private static List<Tuple<int, int>> GetMoves()
        {
            List<Tuple<int, int>> availableMoves = new List<Tuple<int, int>>();
            //availableMoves, rows, columns
            AddMove(availableMoves, -2, 1); //move 2 rows up, move 1 col right
            AddMove(availableMoves, -2, -1); //move 2 rows up, move 1 col left
            AddMove(availableMoves, 2, 1); //
            AddMove(availableMoves, 2, -1);
            AddMove(availableMoves, 1, 2);
            AddMove(availableMoves, 1, -2);
            AddMove(availableMoves, -1, -2);
            AddMove(availableMoves, -1, 2);

            return availableMoves;
        }

        private static void AddMove(List<Tuple<int, int>> availableMoves, int x, int y)
        {
            if (position.Item1 + x < N &&
                position.Item2 + y < N &&
                position.Item1 + x >= 0 &&
                position.Item2 + y >= 0)
            {
                if (board[position.Item1 + x, position.Item2 + y]==false)
                {
                    availableMoves.Add(new Tuple<int, int>(position.Item1 + x,
                        position.Item2 + y));
                }
            }
        }
    }
}
