using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days
{
    /// <summary>
    /// Day 6: Custom Customs
    /// </summary>
    public class Day06
    {
        public static int PartOne()
        {
            int count = 0;
            var input = InputReader.ReadFile("dag6emma.txt");
            var groups = new List<string>();

            string groupAnswers = "";
            for (int i = 0; i < input.Length; i++)
            {
                //Get batch
                int batchEnd = Array.IndexOf(input, String.Empty, i + 1);
                if (batchEnd != i)
                {
                    groupAnswers += input[i];
                    if (batchEnd -1 == i || (batchEnd == -1 && i == input.Length -1))
                    {
                        groups.Add(groupAnswers);
                        i++;
                        groupAnswers = "";
                    }
                }
            }

            foreach (var group in groups)
            {
                string newString = string.Join("", group.ToCharArray().Distinct());
                count += newString.Length;
            }

            return count;
        }

        public static int PartTwo()
        {
            int count = 0;
            var input = InputReader.ReadFile("day6.txt");
            var groups = new List<(string answers,int members)>();

            string groupAnswers = "";
            int groupMembers = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //Get batch
                int batchEnd = Array.IndexOf(input, String.Empty, i + 1);
                if (batchEnd != i)
                {
                    groupAnswers += input[i];
                    groupMembers += 1;
                    if (batchEnd - 1 == i || (batchEnd == -1 && i == input.Length - 1))
                    {

                        groups.Add((groupAnswers, groupMembers));
                        i++;
                        groupAnswers = "";
                        groupMembers = 0;
                    }
                }
            }

            //This could be moved to previous loop to skip some steps but for clarity I'll keep it here
            foreach (var group in groups)
            {
                var ch = group.answers.ToCharArray();
                for (int i = 0; i < ch.Length; i++)
                {
                    var o = ch.Count(x => x == ch[i]);
                    if (o == group.members)
                    {
                        count++;
                        ch[i] = ' ';
                    }
                }               
            }

            return count;
        }
    }
}
