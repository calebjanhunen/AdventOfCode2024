using System.Collections.Generic;

namespace AdventOfCode2024.Day04Code
{
    public class Day04Part01
    {
        protected enum Direction
        {
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW
        }

        protected static readonly Dictionary<Direction, (int iDelta, int jDelta)> DirectionValues = new Dictionary<Direction, (int i, int j)>
        {
            {Direction.N, (-1, 0)},
            {Direction.NE, (-1, 1)},
            {Direction.E, (0, 1)},
            {Direction.SE, (1, 1)},
            {Direction.S, (1, 0)},
            {Direction.SW, (1, -1)},
            {Direction.W, (0, -1)},
            {Direction.NW, (-1, -1)}
        };

        public static int Solve(string stringToFind)
        {
            string[] lines = Utils.ReadFile("day4.txt");
            char[,] matrix = ConvertTo2DArray(lines);

            var firstLetter = GetFirstLetter(stringToFind);
            var secondLetter = GetNextLetter(stringToFind, firstLetter);

            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == firstLetter)
                    {
                        int newI, newJ;
                        // Check North
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.N);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.N, stringToFind);
                        }

                        // Check NE
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.NE);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.NE, stringToFind);
                        }

                        // Check E
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.E);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.E, stringToFind);
                        }

                        // Check SE
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.SE);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.SE, stringToFind);
                        }

                        // Check S
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.S);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.S, stringToFind);
                        }

                        // Check SW
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.SW);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.SW, stringToFind);
                        }

                        // Check W
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.W);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.W, stringToFind);
                        }

                        // Check NW
                        (newI, newJ) = GetUpdatedIAndJ(i, j, Direction.NW);
                        if (IsCurrentElementInBounds(matrix, newI, newJ) && matrix[newI, newJ] == secondLetter)
                        {
                            result += FindRestOfString(matrix, newI, newJ, Direction.NW, stringToFind);
                        }
                    }
                }
            }
            return result;
        }

        private static int FindRestOfString(char[,] matrix, int i, int j, Direction direction, string stringToFind)
        {
            char currentLetter = matrix[i, j];
            if (IsLastLetter(stringToFind, currentLetter))
            {
                return 1;
            }

            var nextLetter = GetNextLetter(stringToFind, currentLetter);
            (int newI, int newJ) = GetUpdatedIAndJ(i, j, direction);

            if (!IsCurrentElementInBounds(matrix, newI, newJ))
            {
                return 0;
            }

            if (matrix[newI, newJ] != nextLetter)
            {
                return 0;
            }

            return FindRestOfString(matrix, newI, newJ, direction, stringToFind);
        }

        private static char GetNextLetter(string stringToFind, char currentLetter)
        {
            var index = stringToFind.IndexOf(currentLetter);
            if (index == stringToFind.Length - 1)
            {
                return ' ';
            }
            else
            {
                return stringToFind[index + 1];
            }
        }

        private static char GetFirstLetter(string stringToFind)
        {
            return stringToFind[0];
        }

        private static bool IsLastLetter(string stringToFind, char currentLetter)
        {
            return stringToFind.IndexOf(currentLetter) == stringToFind.Length - 1;
        }

        private static (int i, int j) GetUpdatedIAndJ(int i, int j, Direction direction)
        {
            var delta = DirectionValues[direction];

            return (i + delta.iDelta, j + delta.jDelta);
        }

        public static bool IsCurrentElementInBounds(char[,] matrix, int i, int j)
        {
            if (i < 0 || i >= matrix.GetLength(0))
            {
                return false;
            }

            if (j < 0 || j >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        protected static char[,] ConvertTo2DArray(string[] lines)
        {

            int rows = lines.Length;
            int columns = lines[0].Length;

            char[,] array = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = lines[i][j];
                }
            }

            return array;

        }
    }
}
