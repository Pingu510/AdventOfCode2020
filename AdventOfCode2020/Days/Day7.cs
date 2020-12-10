using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day7
    {
        static List<string> bagNames = new List<string>();

        public static int PartOne()
        {
            var input = InputReader.ReadFile("day7.txt");
            string bagText = "shiny gold bag";
            ContainingBags(input, bagText);
            return bagNames.Distinct().Count() - 1;
        }

        private static void ContainingBags(string[] input, string currentBag)
        {
            var bags = input.Where(x => x.Contains(currentBag)).ToList();
            foreach (var item in bags)
            {
                if (item.Contains(currentBag + "s contain"))
                {
                    bagNames.Add(currentBag);
                    continue;
                }
                var newBag = item.Substring(0, item.IndexOf("s contain"));
                ContainingBags(input, newBag);
            }
            
            return;
        }

        private static int counter = 0;
        public static int PartTwo()
        {
            var input = InputReader.ReadFile("day7.txt");
            string bagText = "shiny gold bag";
            BagContents(input, bagText);
            return counter - 1;
        }

        private static void BagContents(string[] input, string currentBag)
        {
            string[] split = { "contain no other bag", "contain", ",", "." };
            var currentRow = input.FirstOrDefault(x => x.Contains(currentBag + "s contain"));
            var bags = currentRow.Replace("bags", "bag").Split(split, StringSplitOptions.RemoveEmptyEntries);

            int multiplier = 0;
            for (int i = 1; i < bags.Length; i++)
            {
                bags[i] = bags[i].Trim();
                multiplier = Int32.Parse(bags[i].Substring(0, bags[i].IndexOf(' ')).Trim());
                var newBag = bags[i].Substring(bags[i].IndexOf(' ') + 1);
                for (int j = 0; j < multiplier; j++)
                {
                    BagContents(input, newBag);
                }
            }
            counter++;
        }
    }
}
