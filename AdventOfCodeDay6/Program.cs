using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay7
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var parents = new List<string>();
            int answer = 0;
            string shinyGold = "shiny gold";

            foreach (var item in input)
            {
                var bagsSplit = item.Split(new string[] { " contain ", "bags", "bag", ".", ", " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < bagsSplit.Length; i++)
                {
                    if (bagsSplit[i].Contains(shinyGold))
                    {
                        parents.Add(bagsSplit[0]);
                    }
                }
            }

            foreach (var item in input)
            {
                var inputSplit = item.Split(new string[] { " contain ", "bags", "bag", ".", ", " }, StringSplitOptions.RemoveEmptyEntries);

                answer = CheckBags(parents);
            }

            Console.WriteLine($"The answer of part 1 is: { answer } ");
        }

        public static int CheckBags(List<string> parents)
        {
            var input = File.ReadAllLines("input.txt");

            foreach (var item in input)
            {
                var bagsSplit = item.Split(new string[] { " contain ", "bags", "bag", ".", ", " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < bagsSplit.Length; i++)
                {
                    for (int countParents = 0; countParents < parents.Count(); countParents++)
                    {
                        if (bagsSplit[i].Contains(parents[countParents]))
                        {
                            if (parents.Contains(bagsSplit[0]) == false)
                            {
                                parents.Add(bagsSplit[0]);
                                CheckBags(parents);
                            }
                        }
                    }
                }
            }

            return parents.Count();
        }
    }
}