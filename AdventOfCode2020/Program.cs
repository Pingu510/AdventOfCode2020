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
            Console.WriteLine(Day1().ToString());

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
    }
}
