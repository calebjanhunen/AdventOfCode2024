namespace AdventOfCode2024
{
    internal class Utils
    {
        public static string[] ReadFile(string filename)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"../../Inputs/{filename}";
            string fullPath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
            return File.ReadAllLines(relativePath);
        }

        public static string ReadToString(string filename)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, @"../../../"));
            string fullPath = Path.GetFullPath(Path.Combine(projectRoot, "Inputs", filename));
            return File.ReadAllText(fullPath);
        }

        public static char[,] To2DArray(string input)
        {
            // Split the input into lines
            string[] lines = input.Split('\n');

            // Initialize the 2D array
            char[,] charArray = new char[lines.Length, lines[0].Trim().Length];

            // Fill the 2D array
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();  // Remove extra spaces
                for (int j = 0; j < line.Length; j++)
                {
                    charArray[i, j] = line[j];
                }
            }

            return charArray;
        }
    }
}
