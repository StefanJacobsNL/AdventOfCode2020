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
            var numbers = new List<long>();
            long answerPart1 = 0;
            long answerPart2 = 0;
            long joltage = 0;
            

            foreach (var item in input)
            {
                numbers.Add(long.Parse(item));
            }

            numbers.Sort();

            answerPart1 = CheckList(numbers, joltage);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");

            answerPart2 = CheckAllWays(numbers);

            Console.WriteLine($"The answer of part 2 is: { answerPart2 } ");
        }

        public static long CheckList(List<long> numbers, long joltage)
        {
            long answer = 0;
            long difference1 = 0;
            long difference3 = 1;

            foreach (var item in numbers)
            {
                if (joltage + 1 == item)
                {
                    difference1++;
                    joltage = item;
                }
                else if (joltage + 2 == item)
                {
                    joltage = item;
                }
                else if (joltage + 3 == item)
                {
                    difference3++;
                    joltage = item;
                }
            }

            answer = difference1 * difference3;

            return answer;
        }

        public static long CheckAllWays(List<long> adapters)
        {
            long answer = 0;
            var options = new Dictionary<long, long>() { { 0, 1 } };
            var newOptions = new Dictionary<long, long>();

            while (options.Any())
            {
                foreach (var option in options)
                {
                    foreach (var adapter in adapters)
                    {
                        if (adapter > option.Key)
                        {
                            if (adapter <= 3 + option.Key)
                            {
                                if (!newOptions.ContainsKey(adapter))
                                {
                                    newOptions.Add(adapter, option.Value);
                                }
                                else
                                {
                                    newOptions[adapter] += option.Value;
                                }
                            }
                        }
                    }
                }

                options.Clear();

                foreach (var option in newOptions)
                {
                    if (option.Key != adapters.Last())
                    {
                        options.Add(option.Key, option.Value);
                    }
                    else
                    {
                        answer += option.Value;
                    }
                }

                newOptions.Clear();
            }
            return answer;
        }
    }
}