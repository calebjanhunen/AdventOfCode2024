using System.Linq;

namespace AdventOfCode2024.Day05Code
{
    public static class Day05Part01
    {
        public static int Solve()
        {
            string orderRulesFile = Utils.ReadToString("day5_order_rules.txt");
            string pagesToProduceFile = Utils.ReadToString("day5_pages_to_produce.txt");
            ConvertToTupleArray(orderRulesFile);
            ConvertTo2DArray(pagesToProduceFile);

            return 1;

            // 1. Store all number to the left of pipe in one array (leftVals)
            // 2. Store all number to the right of pipe in another array (rightVal)
            // 3. loop through each line of pagesToProduce
            // 4. Get all indeces of element in leftVals
            // 5. check if values with same index in rightVals appear before element (out of order if true)
            // 6. Get all indecies of element in rightVals
            // 7. check if values with same index in leftVals appear after element (out of order if true)

            // 1. Store all numbers in orderRUlesFile into a tuple array
            // 2. Loop through each line of pagesToProduce
            // 3. Convert line to hashtable with element as key and index as value
            // 4. For each element loop through the orderRules and check if orderRules[0] or orderRules[1] = index
            // 5. If orderRules[0] is index -> check if index of orderRules[1] in line is greater than index of current element (if hashTable[element] < hashTable[orderRules[1]])
        }

        private static (int, int)[] ConvertToTupleArray(string orderRulesFile)
        {
            return orderRulesFile
                .Split('\n')
                .Select(row => row.Split('|').Select(int.Parse).ToArray())
                .Select(row => (row[0], row[1]))
                .ToArray();
        }

        private static int[][] ConvertTo2DArray(string pagesToProduceFile)
        {
            return pagesToProduceFile
                .Split('\n')
                .Select(row => row.Split(',').Select(int.Parse)
                .ToArray())
                .ToArray();
        }
    }
}
