using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2020.Days
{
    /// <summary>
    /// Day 4: Passport Processing
    /// </summary>
    public class Day4
    {
        class Day4Passport
        {
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

        public static int DayFour()
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
                    foreach (var ppItem in row)
                    {
                        if (ppItem == String.Empty) continue;

                        AssignPPField(ppItem, ref pp);
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
        static void AssignPPField(string item, ref Day4Passport pp)
        {
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
    }
}