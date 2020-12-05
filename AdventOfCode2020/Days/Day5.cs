using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class Day5
    {
        public static int PartOne()
        {
            var input = InputReader.ReadFile("day5.txt");
            var seats = new List<int>();
            int highestSeatID = 0;

            foreach (var seatMap in input)
            {
                (int, int) rangeRows = (0, 127);
                (int, int) rangeColumns = (0, 7);
                int i = 0;

                for (; i < 7; i++)
                {
                    GetRow(ref rangeRows, seatMap[i]);
                }

                for (; i < 10; i++)
                {
                    GetColumn(ref rangeColumns, seatMap[i]);
                }
                var seatID = rangeRows.Item1 * 8 + rangeColumns.Item2;
                if (seatID > highestSeatID)
                    highestSeatID = seatID;

                seats.Add(seatID);
            }
            Console.WriteLine(PartTwo(seats).ToString());
            return highestSeatID;
        }

        private static int PartTwo(List<int> seatIDs)
        {
            seatIDs.Sort();
            for (int i = 0; i < seatIDs.Count - 1; i++)
            {
                if (seatIDs[i + 1] != seatIDs[i] + 1)
                {
                    return seatIDs[i] + 1;
                }
            }
            return 0;
        }

        static void GetRow(ref (int, int) range, char direction)
        {
            var move = (range.Item2 - range.Item1) / 2d;
            switch (direction)
            {
                case 'F':
                    range.Item2 = range.Item2 - (int)Math.Floor(move) - 1;
                    break;
                case 'B':
                    range.Item1 = range.Item1 + (int)Math.Ceiling(move);
                    break;
                default:
                    Console.WriteLine("error in row");
                    throw new InvalidCastException();
            }
        }

        static void GetColumn(ref (int, int) range, char direction)
        {
            var move = (range.Item2 - range.Item1) / 2d;
            switch (direction)
            {
                case 'L':
                    range.Item2 = range.Item2 - (int)Math.Floor(move) - 1;
                    break;
                case 'R':
                    range.Item1 = range.Item1 + (int)Math.Ceiling(move);
                    break;
                default:
                    Console.WriteLine("error in column");
                    throw new InvalidCastException();
            }
        }
    }
}
