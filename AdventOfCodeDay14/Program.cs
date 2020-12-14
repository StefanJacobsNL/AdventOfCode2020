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
            long answerPart1 = 0;

            answerPart1 = SumOfAllValues(input);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
        }

        public static long SumOfAllValues(List<string> input)
        {
            long answer = 0;
            long memoryKey = 0;
            long memoryValue = 0;
            string mask = "";
            string result = "";
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
                    result = Convert.ToString(int.Parse(splitMemory[1]), 2);
                    memoryKey = Convert.ToInt64(splitMemory[0]);

                    char[] charArray = result.PadLeft(36, '0').ToCharArray();

                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] == '1')
                        {
                            charArray[i] = '1';
                        }
                        else if (mask[i] == '0')
                        {
                            charArray[i] = '0';
                        }
                    }

                    result = new string(charArray);

                    memoryValue = Convert.ToInt64(result, 2);

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

            answer = memory.Values.Sum();

            return answer;
        }
    }
}