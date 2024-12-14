using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day13Code
{
    public class Day13Part02
    {
        public static void Solve()
        {
            string inputFile = Utils.ReadToString("day13.txt");

            string[] input = inputFile.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            string patternA = @"Button A: X\+(\d+), Y\+(\d+)";
            string patternB = @"Button B: X\+(\d+), Y\+(\d+)";
            string patternPrize = @"Prize: X=(\d+), Y=(\d+)";

            long finalResult = 0;
            foreach (var clawMachine in input)
            {
                //Console.WriteLine(clawMachine);
                PriorityQueue<(int x, int y, int cost, int numAPresses, int numBPresses), int> priorityQ = new();
                Dictionary<(int x, int y), int> visited = [];

                Match matchA = Regex.Match(clawMachine, patternA);
                Match matchB = Regex.Match(clawMachine, patternB);
                Match matchPrize = Regex.Match(clawMachine, patternPrize);

                int btnA_X = int.Parse(matchA.Groups[1].Value);
                int btnA_Y = int.Parse(matchA.Groups[2].Value);
                int btnB_X = int.Parse(matchB.Groups[1].Value);
                int btnB_Y = int.Parse(matchB.Groups[2].Value);
                long prizeX = long.Parse(matchPrize.Groups[1].Value) + 10000000000000;
                long prizeY = long.Parse(matchPrize.Groups[2].Value) + 10000000000000;

                double delta = btnA_X * btnB_Y - btnA_Y * btnB_X;

                double x = (btnB_Y * prizeX - btnB_X * prizeY) / delta;
                double y = (btnA_X * prizeY - btnA_Y * prizeX) / delta;
                Console.WriteLine($"{x} {y}");

                // failed constraint
                if (x < 0 || y < 0)
                {
                    continue;
                }

                // intersection points are not integers
                if (x % 1 != 0 || y % 1 != 0)
                {
                    continue;
                }

                finalResult += (long)x * 3 + (long)y * 1;
            }
            Console.WriteLine($"Final result: {finalResult}");
        }
    }
}
