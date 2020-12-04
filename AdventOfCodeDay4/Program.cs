using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            int counter = 0;
            
            var passportList = new List<string>();

            foreach (var item in input)
            {
                if (string.IsNullOrEmpty(item))
                {
                    if (checkList(passportList) == true)
                    {
                        counter++;
                    }
                    passportList.Clear();
                }
                else
                {
                    passportList.Add(item);
                }
            }

            if (checkList(passportList) == true)
            {
                counter++;
            }

            Console.WriteLine($"The answer of part 2 is: { counter } passports");
        }

        public static bool checkList(IEnumerable<string> passportList)
        {
            bool checkPassport = false;
            int counter = 0;

            foreach (var item in passportList)
            {
                var listSplit = item.Split(new[] { ' ' });

                bool passportCheck = false;

                foreach (var entry in listSplit)
                {
                    var key = entry.Split(':').First();
                    var value = entry.Split(':').Last();

                    passportCheck = CheckPassport(key, value);

                    if (passportCheck == true)
                    {
                        counter++;
                    }
                    if (counter == 7)
                    {
                        return true;
                    }
                }
            }
            return checkPassport;
        }

        public static bool CheckPassport(string key, string value)
        {
            bool check = false;

            string birthYear = "byr";
            string issueYear = "iyr";
            string expireYear = "eyr";
            string height = "hgt";
            string hairColor = "hcl";
            string eyeColor = "ecl";
            string passportId = "pid";

            int numberValue = 0;

            
            if (key == birthYear)
            {
                numberValue = int.Parse(value);
                if (value.Length == 4 && (numberValue >= 1920 && numberValue <= 2002))
                {
                    check = true;
                }
            }
            else if (key == issueYear)
            {
                numberValue = int.Parse(value);
                if (value.Length == 4 && (numberValue >= 2010 && numberValue <= 2020))
                {
                    check = true;
                }
            }
            else if (key == expireYear)
            {
                numberValue = int.Parse(value);
                if (value.Length == 4 && (numberValue >= 2020 && numberValue <= 2030))
                {
                    check = true;
                }
            }
            else if (key == height)
            {
                var splitHeight = Regex.Match(value, @"^(\d+)(\w+)$");
                int valueHeight = int.Parse(splitHeight.Groups[1].Value);
                string valueMS = splitHeight.Groups[2].Value;

                if (valueMS == "cm" && valueHeight >= 150 && valueHeight <= 193)
                {
                    check = true;
                }
                else if (valueMS == "in" && valueHeight >= 59 && valueHeight <= 76)
                {
                    check = true;
                }
            }
            else if (key == hairColor)
            {
                if (Regex.IsMatch(value, @"^#(\d|[a-f]){6}$"))
                {
                    check = true;
                }
            }
            else if (key == eyeColor)
            {
                if (Regex.IsMatch(value, @"^(amb|blu|brn|gry|grn|hzl|oth)$"))
                {
                    check = true;
                }
            }
            else if (key == passportId)
            {
                if (Regex.IsMatch(value, @"^\d{9}$"))
                {
                    check = true;
                }
            }
            else
            {
                check = false;
            }

            return check;
        }
    }
}