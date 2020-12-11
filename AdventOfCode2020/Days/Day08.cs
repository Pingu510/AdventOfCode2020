using System;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day08
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
            var instructions = ResetList();
            int count = 0;
            int pos = 0;

            while (true)
            {
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

            return count;
        }

        public static int PartTwo()
        {
            int count = 0;

            var originalList = ResetList().Length;
            for (int i = 0; i < ResetList().Length; i++)
            {
                var instructions = ResetList();
                count = 0;
                int pos = 0;

                switch (instructions[i].oppType)
                {
                    case "acc":
                        continue;
                    case "jmp":
                        instructions[i].oppType = "nop";
                        break;
                    case "nop":
                        instructions[i].oppType = "jmp";
                        break;
                    default:
                        break;
                }

                while (true)
                {
                    if (pos >= instructions.Length)
                    {
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
