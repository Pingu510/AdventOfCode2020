using System;
using System.Linq;

namespace AdventOfCode2020.Days
{
    /// <summary>
    /// Day 2: Password Philosophy
    /// </summary>
    public class Day02
    {
        public static int DayTwo()
        {
            int count = 0;
            var input = InputReader.ReadFile("day2.txt");
            foreach (var row in input)
            {
                //1-3 a: abcde
                var items = row.Replace(":", String.Empty).Split(' ', '-');

                count += DayTwo_p1(items);
                count += DayTwo_p2(items);
            }
            return count;
        }

        static int DayTwo_p1(string[] items)
        {
            var occurance = items[3].Count(x => x == Char.Parse(items[2]));
            if (occurance >= Int32.Parse(items[0]) && occurance <= Int32.Parse(items[1]))
            {
                return 1;
            }

            return 0;
        }

        static int DayTwo_p2(string[] items)
        {
            var match = Char.Parse(items[2]);
            var pos1 = items[3][Int32.Parse(items[0]) - 1] == match;
            var pos2 = items[3][Int32.Parse(items[1]) - 1] == match;

            if (pos1 && !pos2 || !pos1 && pos2)
            {
                return 1;
            }
            return 0;
        }
    }
}