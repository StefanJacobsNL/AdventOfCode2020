using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();

            Console.WriteLine($"The answer of part 1 is: { SumOfAllValuesPart1(input) } ");
        }

        public static long SumOfAllValuesPart1(List<string> input)
        {
            string mask = "";
            var memory = new Dictionary<long, long>();

            foreach (var item in input)
            {
                if (item.Contains("mask"))
                {
                    var splitMask = item.Split(new[] { "mask = " }, StringSplitOptions.RemoveEmptyEntries);
                    mask = splitMask[0];
                }
                else if (item.Contains("mem"))
                {
                    var splitMemory = item.Split(new[] { "mem[", "] = " }, StringSplitOptions.RemoveEmptyEntries);
                    string result = Convert.ToString(int.Parse(splitMemory[1]), 2);
                    long memoryKey = Convert.ToInt64(splitMemory[0]);

                    char[] charArray = result.PadLeft(36, '0').ToCharArray();

                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == '1' || mask[i] == '0')
                        {
                            charArray[i] = mask[i];
                        }
                    }

                    result = new string(charArray);

                    long memoryValue = Convert.ToInt64(result, 2);

                    if (!memory.ContainsKey(memoryKey))
                    {
                        memory.Add(memoryKey, memoryValue);
                    }
                    else
                    {
                        memory[memoryKey] = memoryValue;
                    }
                }
            }

            return memory.Values.Sum();
        }
    }
}