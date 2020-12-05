using System.Linq;

namespace AdventOfCode2020.Days
{
    /// <summary>
    /// Day 1: Report Repair
    /// </summary>
    public class Day1
    {
        public static int DayOne()
        {
            var input = InputReader.GetInts(InputReader.ReadFile("day1.txt"));
            //Todo Skip the loops
            while (input.Count > 2)
            {
                for (int i = input.Count() - 1; i > 1; i--)
                {
                    for (int j = input.Count() - 2; j > 0; j--)
                    {
                        if (input[0] + input[i] + input[j] == 2020)
                        {
                            return input[0] * input[i] * input[j];
                        }
                    }
                }
                input.Remove(input[0]);
            }
            return 0;
        }
    }
}