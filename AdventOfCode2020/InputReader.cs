using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class InputReader
    {
        static readonly string folderPath = System.IO.Path.GetFullPath(@"..\..\") + "Inputs\\";

        public static string[] ReadFile(string fileName)
        {
            return System.IO.File.ReadAllLines(folderPath + fileName);
        }

        public static List<int> GetInts(string[] input)
        {
            var output = new List<int>();
            foreach (var item in input)
            {
                output.Add(Int32.Parse(item.Trim()));
            }
            return output;
        }
    }
}