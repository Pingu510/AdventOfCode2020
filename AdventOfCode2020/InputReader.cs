using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class InputReader
    {
        //static readonly string folderPath = @"C:\Users\fgidlund\source\repos\AdventOfCode2020\AdventOfCode2020\Inputs\";
        //static readonly string folderPath = @"C:\Users\frgi02\source\repos\Pingu510\AdventOfCode2020\AdventOfCode2020\Inputs\";
        static readonly string folderPath = @"G:\VisualStudioProjects\AdventOfCode2020\AdventOfCode2020\Inputs\";

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