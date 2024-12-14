using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day13Code
{
    public class Day13Part01
    {
        public static void Solve()
        {
            string inputFile = Utils.ReadToString("day13.txt");

            string[] input = inputFile.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            string patternA = @"Button A: X\+(\d+), Y\+(\d+)";
            string patternB = @"Button B: X\+(\d+), Y\+(\d+)";
            string patternPrize = @"Prize: X=(\d+), Y=(\d+)";

            int finalResult = 0;
            foreach (var clawMachine in input)
            {
                Console.WriteLine(clawMachine);
                PriorityQueue<(int x, int y, int cost, int numAPresses, int numBPresses), int> priorityQ = new();
                Dictionary<(int x, int y), int> visited = [];

                Match matchA = Regex.Match(clawMachine, patternA);
                Match matchB = Regex.Match(clawMachine, patternB);
                Match matchPrize = Regex.Match(clawMachine, patternPrize);

                int btnA_X = int.Parse(matchA.Groups[1].Value);
                int btnA_Y = int.Parse(matchA.Groups[2].Value);
                int btnB_X = int.Parse(matchB.Groups[1].Value);
                int btnB_Y = int.Parse(matchB.Groups[2].Value);
                int prizeX = int.Parse(matchPrize.Groups[1].Value);
                int prizeY = int.Parse(matchPrize.Groups[2].Value);

                // Enqueue origin
                priorityQ.Enqueue((0, 0, 0, 0, 0), 0);

                while (priorityQ.Count > 0)
                {
                    (int x, int y, int cost, int numAPresses, int numBPresses) = priorityQ.Dequeue();

                    if (x == prizeX && y == prizeY)
                    {
                        finalResult += cost;
                        break;
                    }

                    if (numAPresses >= 100 || numBPresses >= 100)
                    {
                        continue;
                    }

                    // Press button a
                    int newX = x + btnA_X;
                    int newY = y + btnA_Y;
                    int newCost = cost + 3;

                    if (!visited.ContainsKey((newX, newY)))
                    {
                        visited.Add((newX, newY), cost);
                        priorityQ.Enqueue((newX, newY, newCost, numAPresses + 1, numBPresses), cost);
                    }
                    else
                    {
                        if (newCost < visited[(newX, newY)])
                        {
                            visited[(newX, newY)] = newCost;
                            priorityQ.Enqueue((newX, newY, newCost, numAPresses + 1, numBPresses), cost);
                        }
                    }

                    // Press button b
                    newX = x + btnB_X;
                    newY = y + btnB_Y;
                    newCost = cost + 1;

                    if (!visited.ContainsKey((newX, newY)))
                    {
                        visited.Add((newX, newY), cost);
                        priorityQ.Enqueue((newX, newY, newCost, numAPresses, numBPresses + 1), cost);
                    }
                    else
                    {
                        if (newCost < visited[(newX, newY)])
                        {
                            visited[(newX, newY)] = newCost;
                            priorityQ.Enqueue((newX, newY, newCost, numAPresses, numBPresses + 1), cost);
                        }
                    }
                }
                //Console.WriteLine("No solution");
            }
            Console.WriteLine($"Final result: {finalResult}");
        }
    }
}
