using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2024.Day01Code
{
    public class Day01
    {
        public static void Solve()
        {
            var lines = Utils.ReadFile("day1.txt");
            var (firstList, secondList) = ParseFile(lines);
            var firstListOrdered = firstList.OrderBy(x => x);
            var secondListOrdered = secondList.OrderBy(x => x);

            var result = firstListOrdered.Select((x, index) => Math.Abs(x - secondListOrdered.ElementAt(index))).Sum();
            Console.WriteLine(result);
        }

        private static (IEnumerable<int> firstList, IEnumerable<int> secondList) ParseFile(string[] lines)
        {
            var firstList = new List<int>();
            var secondList = new List<int>();
            foreach (var line in lines)
            {
                string[] lineSplit = line.Split(' ');
                firstList.Add(int.Parse(lineSplit[0]));
                secondList.Add(int.Parse(lineSplit[3]));
            }

            return (firstList.ToList(), secondList.ToList());
        }
    }
}
