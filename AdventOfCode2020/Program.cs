using AdventOfCode2020.Days;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Console.WriteLine(Day5.PartOne().ToString());


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

        static Int64 Day3()
        {
            long output = 1L * Day3f((1, 1)) * Day3f((3, 1)) * Day3f((5, 1)) * Day3f((7, 1)) * Day3f((1, 2));
            return output;
        }

        static int Day3f((int x, int y) slope)
        {
            int treeCount = 0;
            (int x, int y) slopeHeading = (slope.x, slope.y);
            (int x, int y) currentPos = (0, 0);
            currentPos = slopeHeading;

            var input = InputReader.ReadFile("day3.txt");
            var inputWidth = input[0].Length;
            //modulus?
            for (; currentPos.y < input.Length; currentPos.y = currentPos.y + slopeHeading.y)
            {
                var remainder = currentPos.x % inputWidth;

                var place = input[currentPos.y][remainder];
                if (place == '#')
                {
                    treeCount++;
                }
                currentPos.x = currentPos.x + slopeHeading.x;
            }

            return treeCount;
        }

        class Day4Passport
        {
            //[StringLength(4)]
            [Required]
            public int? byr { get; set; }

            [Required]
            public int? iyr { get; set; }

            [Required]
            public int? eyr { get; set; }

            [Required]
            public string hgt { get; set; }

            [RegularExpression("^#[a-fA-F0-9]{6}$")]
            [Required]
            public string hcl { get; set; }


            [Required]
            public string ecl { get; set; }

            [Required]
            [RegularExpression("[0-9]{9}")]
            public string pid { get; set; }

            public string cid { get; set; }

            public bool Validate()
            {
                if (this.ValidateYear(this.byr, 1920, 2002) && this.ValidateYear(this.iyr, 2010, 2020) && this.ValidateYear(this.eyr, 2020, 2030)
                    && this.ValidateEyecolor(this.ecl)
                    && this.ValidateHeight(this.hgt))
                {
                    return true;
                }
                return false;
            }
            bool ValidateYear(int? input, int min, int max)
            {
                if (input <= max && input >= min)
                    return true;
                return false;
            }

            bool ValidateEyecolor(string input)
            {
                switch (input)
                {
                    case "amb":
                    case "blu":
                    case "brn":
                    case "gry":
                    case "grn":
                    case "hzl":
                    case "oth":
                        return true;
                    default:
                        return false;
                }
            }

            bool ValidateHeight(string input)
            {
                var x = input.Substring(input.Length - 2);
                int max;
                int min;
                switch (input.Substring(input.Length - 2))
                {
                    case "cm":
                        min = 150;
                        max = 193;
                        break;
                    case "in":
                        min = 59;
                        max = 76;
                        break;
                    default:
                        return false;
                }

                int length = Int32.Parse(input.Substring(0, input.Length - 2));
                if (length <= max && length >= min)
                {
                    return true;
                }
                return false;
            }
        }

        static int Day4()
        {
            var count = 0;
            var input = InputReader.ReadFile("day4.txt");

            for (int i = 0; i < input.Length;)
            {
                //Get batch
                int batchEnd = Array.IndexOf(input, String.Empty, i + 1);
                var pp = new Day4Passport();
                int index = i;
                while (index <= batchEnd || batchEnd == -1)
                {
                    var row = input[index].Split(' ');
                    foreach (var item in row)
                    {
                        if (item == String.Empty) continue;

                        int num;
                        switch (item.Substring(0, 3).Trim())
                        {
                            case "byr":
                                if (Int32.TryParse(item.Substring(4).Trim(), out num))
                                {
                                    pp.byr = num;
                                }
                                break;
                            case "iyr":
                                if (Int32.TryParse(item.Substring(4).Trim(), out num))
                                {
                                    pp.iyr = num;
                                }
                                break;
                            case "eyr":
                                if (Int32.TryParse(item.Substring(4).Trim(), out num))
                                {
                                    pp.eyr = num;
                                }
                                break;
                            case "hgt":
                                pp.hgt = item.Substring(4).Trim();
                                break;
                            case "hcl":
                                pp.hcl = item.Substring(4).Trim();
                                break;
                            case "ecl":
                                pp.ecl = item.Substring(4).Trim();
                                break;
                            case "pid":
                                pp.pid = item.Substring(4).Trim();
                                break;
                            case "cid":
                                pp.cid = item.Substring(4).Trim();
                                break;
                            default:
                                Console.WriteLine("invalid: " + item.Substring(0, 3).Trim());
                                break;
                        }
                    }
                    index++;
                    if (batchEnd == -1) break;
                }
                i = index;

                var context = new ValidationContext(pp, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(pp, context, results, true))
                {
                    if (pp.Validate())
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
