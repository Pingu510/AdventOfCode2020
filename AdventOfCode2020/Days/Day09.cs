using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day09
    {
        public static long PartOne()
        {
            int preambleL = 25;
            var input = InputReader.GetLargeInts(InputReader.ReadFile("day9.txt"));
            var preamble = SetPreamble(input.GetRange(0, preambleL));

            for (int i = preambleL; i < input.Count(); i++)
            {
                long toMatch = input[i];
                bool found = FindMatchOfTwo(toMatch, preamble);
                if (!found) return toMatch;

                preamble = SetPreamble(input.GetRange(i - preambleL + 1, preambleL));
            }
            return 0;
        }

        static bool FindMatchOfTwo(long match, long[] list)
        {
            bool found = false;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > match)
                {
                    continue;
                }
                for (int j = 0; j < list.Length; j++)
                {
                    if (i == j || list[j] > match)
                    {
                        continue;
                    }

                    if (list[i] + list[j] == match)
                    {
                        return true;
                    }
                    if (j == list.Length)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static long[] SetPreamble(List<long> input)
        {
            var preamble = new long[input.Count()];
            for (int i = 0; i < input.Count(); i++)
            {
                preamble[i] = input[i];
            }
            return preamble;
        }

        public static long PartTwo()
        {
            var match = PartOne();
            var input = InputReader.GetLargeInts(InputReader.ReadFile("day9.txt"));


            int startIndex = 0;
            while (true)
            {
                long count = 0;
                long sml = long.MaxValue;
                long lrg = 0;

                for (int i = startIndex; i < input.Count(); i++)
                {
                    count += input[i];
                    sml = input[i] < sml ? input[i]: sml;
                    lrg = input[i] > lrg ? input[i]: lrg;
                    if (count == match)
                    {
                        Console.WriteLine(match);
                        return sml + lrg;
                    }
                    else if (count > match)
                    {
                        startIndex++;
                        break;
                    }
                }
                if (startIndex >= input.Count)
                {
                    break;
                }
            }

            return 0;
        }
    }
}
