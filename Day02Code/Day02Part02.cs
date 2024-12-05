namespace AdventOfCode2024.Day02Code
{
    public class Day02Part02 : Day02
    {
        public static int Solve()
        {
            var fileLines = Utils.ReadFile("day2.txt");
            var matrix = ConvertTo2DArray(fileLines);
            // Loop in 3x3 chunks
            //  ensure edges are in bound
            // check if the center [i + 1, j + 1] is an A
            // check the corners (if 1 corner is M the opposite corner has to be an S, vice versa)
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!IsGridInBound(matrix, i, j))
                    {
                        continue;
                    }

                    // Make sure middle is an A
                    if (matrix[i + 1, j + 1] != 'A')
                    {
                        continue;
                    }

                    // Check top left and bottom right corners
                    if (IsTopLeftAndBottomRightCorrect(matrix, i, j) && IsTopRightAndBottomLeftCorrect(matrix, i, j))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static bool IsGridInBound(char[,] matrix, int i, int j)
        {
            return i + 2 < matrix.GetLength(0) && j + 2 < matrix.GetLength(1);
        }

        private static bool IsTopLeftAndBottomRightCorrect(char[,] matrix, int i, int j)
        {
            return (matrix[i, j], matrix[i + 2, j + 2]) is ('M', 'S') or ('S', 'M');
        }

        private static bool IsTopRightAndBottomLeftCorrect(char[,] matrix, int i, int j)
        {
            return (matrix[i + 2, j], matrix[i, j + 2]) is ('M', 'S') or ('S', 'M');
        }
    }
}
