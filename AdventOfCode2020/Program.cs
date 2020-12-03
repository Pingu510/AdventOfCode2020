using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            //Console.WriteLine(Day1().ToString());
            Console.WriteLine(Day2().ToString());


            Console.ReadKey();
        }

        static int Day1()
        {
            var input = InputReader.GetInts(InputReader.ReadFile("day1.txt"));
            //Todo Don't do this
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

        static int Day2()
        {
            int count = 0;
            var input = InputReader.ReadFile("day2.txt");
            foreach (var row in input)
            {
                //1-3 a: abcde
                var items = row.Replace(":", String.Empty).Split(' ', '-');

                //Part 1
                //var occurance = items[3].Count(x => x == Char.Parse(items[2]));
                //if (occurance >= Int32.Parse(items[0]) && occurance <= Int32.Parse(items[1]))
                //{
                //    count++;
                //}

                //Part 2
                var match = Char.Parse(items[2]);
                var pos1 = items[3][Int32.Parse(items[0]) - 1] == match;
                var pos2 = items[3][Int32.Parse(items[1]) - 1] == match;

                if (pos1 && !pos2 || !pos1 && pos2)
                {
                    count++;
                }
            }
            return count;
        }

        static string Day3()
        {
            var slopeHeading = (3, 1);            
            var curremtPosX = (0, 0);


        }
    }
}
