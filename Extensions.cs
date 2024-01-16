using System.Collections.Generic;
using System;
using System.Drawing;

namespace Chess
{
    public static class Extensions
    {
        /// <summary>
        /// Get a copy of the given board with the piece at <paramref name="oldPoint"/> moved to <paramref name="newPoint"/>.
        /// </summary>
        public static Pieces.Piece?[,] AfterMove(this Pieces.Piece?[,] board, Point oldPoint, Point newPoint)
        {
            Pieces.Piece?[,] newBoard = (Pieces.Piece?[,])board.Clone();
            newBoard[newPoint.X, newPoint.Y] = newBoard[oldPoint.X, oldPoint.Y];
            newBoard[oldPoint.X, oldPoint.Y] = null;
            return newBoard;
        }

        private const string files = "abcdefgh";
        private const string ranks = "12345678";
        public static string ToChessCoordinate(this Point point)
        {
            return $"{files[point.X]}{ranks[point.Y]}";
        }

        public static Point FromChessCoordinate(this string coordinate)
        {
            return new Point(files.IndexOf(coordinate[0]), ranks.IndexOf(coordinate[1]));
        }

        //Shuffling Pieces Algorithm
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1) 
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
