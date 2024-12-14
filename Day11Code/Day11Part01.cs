using System;
using System.Collections.Generic;

namespace AdventOfCode2024.Day11Code
{
    public class Day11Part01
    {

        public static void Solve()
        {

            string fileString = Utils.ReadToString("day11.txt");
            var inputLL = ConvertToLL(fileString);

            var blinks = 25;
            for (int i = 0; i < blinks; i++)
            {
                var currentNode = inputLL.First;
                while (currentNode != null)
                {
                    if (currentNode.Value == "0")
                    {
                        currentNode.Value = "1";
                    }
                    else if (currentNode.Value.Length % 2 == 0)
                    {
                        (string firstHalf, string secondHalf) = SplitAndTrim(currentNode.Value);
                        currentNode.Value = firstHalf;
                        inputLL.AddAfter(currentNode, secondHalf);

                        // Skip over node just added
                        currentNode = currentNode.Next;
                    }
                    else
                    {
                        currentNode.Value = MultiplyBy2024(currentNode.Value);
                    }
                    currentNode = currentNode.Next;
                }
            }
            Console.WriteLine(inputLL.Count);
        }

        internal static (string, string) SplitAndTrim(string val)
        {
            var mid = val.Length / 2;

            string firstHalf = val.Substring(0, mid);

            string secondHalfTrimmed = val.Substring(mid).TrimStart('0');

            if (string.IsNullOrEmpty(secondHalfTrimmed))
            {
                secondHalfTrimmed = "0";
            }
            return (firstHalf, secondHalfTrimmed);
        }

        internal static string MultiplyBy2024(string val)
        {
            return (long.Parse(val) * 2024).ToString();
        }

        private static LinkedList<string> ConvertToLL(string input)
        {
            LinkedList<string> list = new LinkedList<string>();
            string[] inputArr = input.Split(' ');

            foreach (string num in inputArr)
            {
                list.AddLast(num);
            }

            return list;
        }
    }
}
