using System;

namespace AdventOfCode2020.Days
{
    /// <summary>
    /// Day 3: Toboggan Trajectory
    /// </summary>
    public class Day3
    {
        public static Int64 DayThree()
        {
            long output = 1L * CalculateTreeHits((1, 1)) * CalculateTreeHits((3, 1)) * CalculateTreeHits((5, 1)) * CalculateTreeHits((7, 1)) * CalculateTreeHits((1, 2));
            return output;
        }

        static int CalculateTreeHits((int x, int y) slope)
        {
            int treeCount = 0;
            (int x, int y) slopeHeading = (slope.x, slope.y);
            (int x, int y) currentPos = (0, 0);
            currentPos = slopeHeading;

            var input = InputReader.ReadFile("day3.txt");
            var inputWidth = input[0].Length;
            //modulus?
            for (; currentPos.y < input.Length; currentPos.y = currentPos.y + slopeHeading.y)
            {
                var remainder = currentPos.x % inputWidth;

                var place = input[currentPos.y][remainder];
                if (place == '#')
                {
                    treeCount++;
                }
                currentPos.x = currentPos.x + slopeHeading.x;
            }

            return treeCount;
        }
    }
}