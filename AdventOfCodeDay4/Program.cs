using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            Console.WriteLine($"The answer of part 1 is: { counter } passports");
        }

        public static bool checkList(IEnumerable<string> passportList)
        {
            bool checkPassport = false;
            int counter = 0;

            foreach (var item in passportList)
            {
                var listSplit = item.Split(new[] { ' ', });

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
            string countryId = "cid";

            if (key == birthYear)
            {
                check = true;
            }
            else if (key == issueYear)
            {
                check = true;
            }
            else if (key == expireYear)
            {
                check = true;
            }
            else if (key == height)
            {
                check = true;
            }
            else if (key == hairColor)
            {
                check = true;
            }
            else if (key == eyeColor)
            {
                check = true;
            }
            else if (key == passportId)
            {
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }
    }
}