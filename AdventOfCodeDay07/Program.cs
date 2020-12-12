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
            int answerPart1 = 0;
            int answerPart2 = 0;
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
                    if (parents.Count() != 0)
                    {
                        answerPart1 = CheckBags(parents);
                    }
                }
            }

            var bags = Bag.ParseMultiple(File.ReadAllLines("input.txt"));

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
            Console.WriteLine($"The answer of part 2 is: { bags[shinyGold].TotalChildren } ");

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

    public class Bag
    {
        public string Name { get; set; }
        public IList<Bag> Children { get; set; } = new List<Bag>();

        public Bag(string name)
        {
            Name = name;
        }

        public int TotalChildren
        {
            get
            {
                int count = 0;
                count += Children.Count;

                foreach (var child in Children)
                {
                    count += child.TotalChildren;
                }

                return count;
            }
        }

        public static IDictionary<string, Bag> ParseMultiple(IEnumerable<string> data)
        {
            var bags = new Dictionary<string, Bag>();

            foreach (var line in data)
            {
                var name = line.Split(" bags contain ")[0];
                bags.Add(name, new Bag(name));
            }

            foreach (var line in data)
            {
                var splitItems = new[] { " bags contain ", "bags", "bag", ".", ",", "no other bags." };

                var bagData = line.Split(splitItems, StringSplitOptions.RemoveEmptyEntries).Select(b => b.Trim()).ToList();

                var currentBag = bags[bagData[0]];

                foreach (var bag in bagData.Skip(1))
                {
                    int numberOfBags = int.Parse(bag.Split(' ')[0]);
                    string bagName = bag.Substring(bag.IndexOf(' ') + 1);

                    for (int i = 0; i < numberOfBags; i++)
                    {
                        currentBag.Children.Add(bags[bagName]);
                    }
                }
            }

            return bags;
        }
    }
}