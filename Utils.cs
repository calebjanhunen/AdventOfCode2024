using System;
using System.IO;

namespace AdventOfCode2024
{
    internal class Utils
    {
        public static string[] ReadFile(string filename)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = $"../../_Inputs/{filename}";
            string fullPath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
            return File.ReadAllLines(relativePath);
        }
    }
}
