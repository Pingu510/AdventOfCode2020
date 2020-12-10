using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class Day10
    {
        public static int PartOne()
        {
            int ada1 = 0;
            int ada3 = 1;
            var input = InputReader.GetInts(InputReader.ReadFile("day10.txt"));
            input.Sort();

            int jolts = 0;
            int myDevice = input.Last() + 3;

            foreach (var adapter in input)
            {
                if (adapter == jolts + 3)
                {
                    ada3++;
                }
                else if (adapter == jolts + 1)
                {
                    ada1++;
                }
                jolts = adapter;
            }
            return ada1 * ada3;
        }

        static HashSet<List<int>> Collection = new HashSet<List<int>>();
        public static int PartTwo()
        {

            var allAdapters = InputReader.GetInts(InputReader.ReadFile("day10.txt"));
            allAdapters.Sort();
            allAdapters.Insert(0, 0);
            Collection.Add(allAdapters);

            RunList(allAdapters, 0, allAdapters.Last());

            //foreach (var l in Collection)
            //{
            //    foreach (var item in l)
            //    {
            //        Console.Write(item + ",");
            //    }
            //    Console.Write("\n");
            //}
            return Collection.Count(); //ger 16464 när output = 19208
        }

        static void RunList(List<int> currentTrial, int index, int end)
        {
            if (index >= currentTrial.Count()) return;

            if (currentTrial[index] == end)
            {
                Collection.Add(currentTrial);
                return;
            }

            //pos+1
            if (currentTrial[index + 1] == currentTrial[index] + 1 || currentTrial[index + 1] == currentTrial[index] + 2 || currentTrial[index + 1] == currentTrial[index] + 3)
            {
                var i = index + 1;
                RunList(currentTrial, i, end);
            }

            if (index + 2 >= currentTrial.Count()) return;
            //pos+2
            if (currentTrial[index + 2] == currentTrial[index] + 1 || currentTrial[index + 2] == currentTrial[index] + 2 || currentTrial[index + 2] == currentTrial[index] + 3)
            {
                var i = index + 1;
                var x = currentTrial.ToList();
                x.RemoveAt(i - 1);
                RunList(x, i, end);
            }

            if (index + 3 >= currentTrial.Count()) return;
            //pos+3
            if (currentTrial[index + 3] == currentTrial[index] + 1 || currentTrial[index + 3] == currentTrial[index] + 2 || currentTrial[index + 3] == currentTrial[index] + 3)
            {
                var i = index + 2;
                var x = currentTrial.ToList();
                x.RemoveAt(i - 1);
                x.RemoveAt(i - 2);
                RunList(x, i, end);
            }
        }
    }
}
