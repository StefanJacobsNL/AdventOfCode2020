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
                    usedInstructions.Add(i);
                    if (rules[i].Contains("acc"))
                    {
                        counter += GetValue(rules[i]);
                    }
                    else if (rules[i].Contains("jmp"))
                    {
                        i += GetValue(rules[i]);

                        i--;
                    }

                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"The answer of part 1 is: { counter } ");

            counter = 0;
            usedInstructions.Clear();


            for (int i = 0; i < rules.Count; i++)
            {
                if (rules[i].Contains("jmp"))
                {
                    rules[i] = rules[i].Replace("jmp", "nop");
                }
                else if (rules[i].Contains("nop"))
                {
                    rules[i] = rules[i].Replace("nop", "jmp");
                }

                if (CheckList(rules) == 0)
                {
                    if (rules[i].Contains("jmp"))
                    {
                        rules[i] = rules[i].Replace("jmp", "nop");
                    }
                    else if (rules[i].Contains("nop"))
                    {
                        rules[i] = rules[i].Replace("nop", "jmp");
                    }
                }
                else
                {
                    var test = rules[i];
                    
                    counter = CheckList(rules);
                    break;
                }
            }

            Console.WriteLine($"The answer of part 2 is: { counter } ");
        }

        public static int CheckList(List<string> rules)
        {
            int counter = 0;
            int currentInstruction = 0;
            var usedInstructions = new List<int>();

            for (int i = 0; i < rules.Count; i++)
            {
                if (usedInstructions.Any(x => x == i) == false)
                {
                    usedInstructions.Add(i);

                    if (rules[i].Contains("acc"))
                    {
                        counter += GetValue(rules[i]);
                    }
                    else if (rules[i].Contains("jmp"))
                    {
                        i += GetValue(rules[i]);

                        i--;

                        if (i < 0)
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }

                currentInstruction = i;
            }
            if (currentInstruction +1 == rules.Count)
            {
                return counter;
            }
            else
            {
                return 0;
            }
        }

        public static int GetValue(string instruction)
        {
            return int.Parse(instruction.Split(" ")[1]);
        }
    }
}