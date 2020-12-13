using System;

namespace AdventOfCode2020.Days
{
    public class Boat
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
    }

    public class Day12
    {
        public static int PartOne()
        {
            var current = new Boat { Direction = 'E', X = 0, Y = 0 };
            var input = InputReader.ReadFile("day12.txt");

            foreach (var instuction in input)
            {
                var number = Int32.Parse(instuction.Substring(1));
                var command = instuction[0];
                if (command == 'F')
                {
                    command = current.Direction;
                }

                switch (command)
                {
                    case 'N':
                        current.Y += number;
                        break;
                    case 'S':
                        current.Y += -number;
                        break;
                    case 'W':
                        current.X += -number;
                        break;
                    case 'E':
                        current.X += number;
                        break;
                    case 'L':
                        current.Direction = Turn('L', number, current.Direction);
                        break;
                    case 'R':
                        current.Direction = Turn('R', number, current.Direction);
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }

            return Math.Abs(current.X) + Math.Abs(current.Y);
        }

        static char Turn(char turnType, int turn, char currentDirection)
        {
            var directions = new char[] { 'N', 'E', 'S', 'W' };

            var x = turn / 90;
            if (turnType == 'L')
            {
                x = -x;
            }

            var newD = Array.IndexOf(directions, currentDirection) + x +4;
            return directions[newD % 4]; ;
        }
    
        public static int PartTwo()
        {
            return 0;
        }
    }
}
