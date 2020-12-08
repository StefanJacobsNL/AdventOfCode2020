using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var rules = new List<string>();
            var usedInstructions = new List<int>();
            int counter = 0;

            foreach (var item in input)
            {
                rules.Add(item);
            }

            for (int i = 0; i < rules.Count; i++)
            {
                if (usedInstructions.Where(x => x == i).Count() == 0)
                {
                    if (rules[i].Contains("acc"))
                    {
                        counter += GetAcc(rules[i]);
                    }
                    else if (rules[i].Contains("jmp"))
                    {
                        i += GetJmp(rules[i]);

                        i--;
                    }
                    else if (rules[i].Contains("nop"))
                    {
                    }

                    usedInstructions.Add(i);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"The answer of part 1 is: { counter } ");
        }

        public static int GetAcc(string instruction)
        {
            int counter = 0;

            if (instruction.Split(" ")[1].Contains("+"))
            {
                counter += int.Parse(instruction.Split(" +")[1]);
            }
            else if (instruction.Split(" ")[1].Contains("-"))
            {
                counter -= int.Parse(instruction.Split(" -")[1]);
            }

            return counter;
        }

        public static int GetJmp(string instruction)
        {
            int counter = 0;

            if (instruction.Split(" ")[1].Contains("+"))
            {
                counter += int.Parse(instruction.Split(" +")[1]);
            }
            else if (instruction.Split(" ")[1].Contains("-"))
            {
                counter -= int.Parse(instruction.Split(" -")[1]);
            }

            return counter;
        }
    }
}