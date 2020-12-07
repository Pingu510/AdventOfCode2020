using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class Day7
    {
        static List<string> bagNames = new List<string>();
        public static int PartOne()
        {
            int count = 0;
            var input = InputReader.ReadFile("day7.txt");
            string bagText = "shiny gold bag";
            count += RecursiveBag_p1(input, bagText);
            int c = bagNames.Distinct().Count() - 1;
            return c;
        }

        //Count goes wrong in the ether, Aka when..
        //ToDo fix items that contain other bags that contain shinies
        private static int RecursiveBag_p1(string[] input, string currentBag)
        {
            int count = 0;
            var bags = input.Where(x => x.Contains(currentBag)).ToList();
            foreach (var item in bags)
            {
                if (item.Contains(currentBag + "s contain"))
                {
                    bagNames.Add(currentBag);
                    continue;
                }
                //count += Int32.Parse(item.Substring(item.IndexOf(currentBag) - 2, 2).Trim());
                var newBag = item.Substring(0, item.IndexOf("s contain"));
                count += RecursiveBag_p1(input, newBag);
            }
            if (bags.Count() == 1)
            {
                //bagNames.Add(currentBag);
                count++;
            }
            return count;
        }


        public static int PartTwo()
        {
            int count = 0;
            var input = InputReader.ReadFile("day7.txt");
            string bagText = "shiny gold bag";
            count += RecursiveBag_p2(input, bagText);
            return count;
        }

        // ToDo Multiply by parent
        private static int RecursiveBag_p2(string[] input, string currentBag)
        {
            int count = 0;
            string[] split = { "contain no other bag", "contain", ",", "." };
            var bags = input.FirstOrDefault(x => x.Contains(currentBag + "s contain")).Replace("bags", "bag").Split(split, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < bags.Length; i++)
            {
                bags[i] = bags[i].Trim();
                var newBag = bags[i].Trim().Substring(bags[i].IndexOf(' ') + 1);
                int multiplier = Int32.Parse(bags[i].Substring(0, bags[i].IndexOf(' ')).Trim());
                count += multiplier * RecursiveBag_p2(input, newBag);
            }
            if (bags.Count() == 1)
            {
                count += 1;
            }
            return count;
        }
    }
}
