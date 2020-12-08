using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class Day8
    {
        public class Instructions
        {
            public string oppType { get; set; }
            public int oppMove { get; set; }
            public bool isRan { get; set; }
        }

        static Instructions[] ResetList()
        {
            var input = InputReader.ReadFile("day8.txt");
            var result = from l in input
                         select new Instructions()
                         {
                             oppType = l.Substring(0, 3),
                             oppMove = Int32.Parse(l.Substring(3).Trim()),
                             isRan = false
                         };
            return result.ToArray();
        }

        public static int PartOne()
        {
            bool finished = false;
            int count = 0;

            foreach (var line in ResetList())
            {
                var instructions = ResetList();

                count = 0;
                int pos = 0;
                string savedOpp = line.oppType;
                switch (line.oppType)
                {
                    case "acc":
                        continue;
                    case "jmp":
                        line.oppType = "nop";
                        break;
                    case "nop":
                        line.oppType = "jmp";
                        break;
                    default:
                        break;
                }

                while (true)
                {
                    if (pos >= instructions.Length)
                    {
                        finished = true;
                        goto End;
                    }
                    if (instructions[pos].isRan) break;

                    switch (instructions[pos].oppType)
                    {
                        case "acc":
                            instructions[pos].isRan = true;
                            count += instructions[pos].oppMove;
                            pos++;
                            break;
                        case "jmp":
                            instructions[pos].isRan = true;
                            pos += instructions[pos].oppMove;
                            break;
                        case "nop":
                            instructions[pos].isRan = true;
                            pos++;
                            break;
                        default:
                            break;
                    }
                }
            }
            End:
            return count;
        }
    }
}
