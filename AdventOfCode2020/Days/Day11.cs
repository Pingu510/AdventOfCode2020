using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class Day11
    {
        public static int PartOne()
        {
            char empty = 'L';
            char occupied = '#';
            bool changed = true;

            var input = InputReader.ReadFile("day11.txt");
            int rounds = 0;

            var currentChange = input.Clone() as string[];
            while (changed)
            {
                changed = false;

                for (int rowY = 0; rowY < input.Length; rowY++)
                {
                    for (int posX = 0; posX < input[rowY].Length; posX++)
                    {
                        if (input[rowY][posX] == '.') continue;

                        int adjacent = AdjacentOccupiedSeats(input, (posX, rowY));
                        switch (input[rowY][posX])
                        {
                            case 'L':
                                if (adjacent == 0)
                                {
                                    var r = currentChange[rowY].Insert(posX, occupied.ToString()).Remove(posX + 1, 1);
                                    currentChange[rowY] = r;
                                    changed = true;
                                }
                                break;
                            case '#':
                                if (adjacent >= 4)
                                {
                                    var r = currentChange[rowY].Insert(posX, empty.ToString()).Remove(posX + 1, 1);
                                    currentChange[rowY] = r;
                                    changed = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                input = currentChange.Clone() as string[];
                //rounds++;
                //foreach (var item in input)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine();
               
            }
            //Console.WriteLine(rounds);

            int count = 0;
            foreach (var s in input)
            {
                count += s.Count(x => x == occupied);
            }
            return count;
        }

        static int AdjacentOccupiedSeats(string[] map, (int x, int y) position)
        {
            int count = 0;

            var testPos = new List<(int x, int y)>
            {
                (position.x-1, position.y-1),
                (position.x, position.y-1),
                (position.x+1, position.y-1),
                (position.x-1, position.y),
                (position.x+1, position.y),
                (position.x-1, position.y+1),
                (position.x, position.y+1),
                (position.x+1, position.y+1)
            };

            foreach (var item in testPos)
            {
                if (item.x < 0 || item.x >= map.Length || item.y < 0 || item.y >= map.Length)
                {
                    continue;
                }
                if (map[item.y][item.x] == '#')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
