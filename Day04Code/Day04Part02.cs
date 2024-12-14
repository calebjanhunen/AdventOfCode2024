namespace AdventOfCode2024.Day04Code
{
    public class Day04Part02 : Day04Part01
    {
        public static int Solve()
        {
            var fileLines = Utils.ReadFile("day4.txt");
            var matrix = ConvertTo2DArray(fileLines);
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
