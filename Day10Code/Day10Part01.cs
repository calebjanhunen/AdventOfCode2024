using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2024.Day10Code
{
    public class Day10Part01
    {
        public static void Solve()
        {
            /*
             * - loop through input
             * - If a 0 is found
             *      - result = result + traverse(left) + traverse(right) + travserse(up) + traverse(down)
             *      
             *      
             * traverse(inputArr, val, i, j)
             *      - if val is 9
             *          - return 1
             *      - if i and j are out of bounds
             *          - return 0
             *      - if inputArr[i][j] != val + 1
             *          - return 0
             *      - return traverse(left) + traverse(right) + traverse(up) + traverse(down)
             */

            string file = Utils.ReadToString("day10.txt");
            int[][] input = To2DArray(file);

            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    bool[,] visited = new bool[input.Length, input[0].Length];
                    HashSet<(int, int)> reachableNines = [];
                    if (input[i][j] == 0)
                    {
                        Traverse(input, input[i][j], i, j, visited, reachableNines);
                        result += reachableNines.Count;
                    }
                }
            }
            Console.WriteLine(result);
        }

        private static void Traverse(int[][] input, int prevVal, int i, int j, bool[,] visited, HashSet<(int, int)> reachableNines)
        {
            if (AreIndexValuesOutOfBounds(input, i, j))
            {
                return;
            }

            if (visited[i, j])
            {
                return;
            }

            visited[i, j] = true;
            var currentVal = input[i][j];
            if (currentVal == 9)
            {
                reachableNines.Add((i, j));
                return;
            }

            // Check left
            if (!AreIndexValuesOutOfBounds(input, i, j - 1) && input[i][j - 1] == currentVal + 1)
            {
                Traverse(input, currentVal, i, j - 1, visited, reachableNines);
            }

            // Check right
            if (!AreIndexValuesOutOfBounds(input, i, j + 1) && input[i][j + 1] == currentVal + 1)
            {
                Traverse(input, currentVal, i, j + 1, visited, reachableNines);
            }

            // Check up
            if (!AreIndexValuesOutOfBounds(input, i - 1, j) && input[i - 1][j] == currentVal + 1)
            {
                Traverse(input, currentVal, i - 1, j, visited, reachableNines);
            }

            // Check down
            if (!AreIndexValuesOutOfBounds(input, i + 1, j) && input[i + 1][j] == currentVal + 1)
            {
                Traverse(input, currentVal, i + 1, j, visited, reachableNines);
            }
        }

        private static int[][] To2DArray(string input)
        {
            int[][] output = input
                .Split('\n')
                .Select(row => row.Where(char.IsDigit).Select(element => int.Parse(element.ToString())).ToArray())
                .ToArray();

            return output;
        }

        private static bool AreIndexValuesOutOfBounds(int[][] input, int i, int j)
        {
            if (i < 0 || i > input.Length - 1)
            {
                return true;
            }

            if (j < 0 || j > input[0].Length - 1)
            {
                return true;
            }
            return false;
        }
    }
}
