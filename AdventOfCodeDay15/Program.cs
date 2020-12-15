using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay15
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").ToList();
            List<long> numbers = new List<long>();
            long firstRound = 2020;
            long secondRound = 30000000;

            foreach (var item in input[0].Split(','))
            {
                numbers.Add(long.Parse(item));
            }

            Console.WriteLine($"The answer of part 1 is: { NumberGame(numbers, firstRound) } ");

            Console.WriteLine($"The answer of part 2 is: { NumberGame(numbers, secondRound) } ");
        }

        public static long NumberGame(List<long> numbers, long rounds)
        {
            long answer = numbers[0];
            int counter = 0;
            var numberDictionary = new Dictionary<long, long>();

            foreach (var item in numbers)
            {
                numberDictionary.Add(item, counter);
                answer = item;
                counter++;
            }

            long lastIndex = numbers.Count() - 1;

            for (int index = numbers.Count; index < rounds; index++)
            {
                if (numberDictionary.ContainsKey(answer) && numberDictionary[answer] == lastIndex)
                {
                    answer = 0;
                }
                else if (!numberDictionary.ContainsKey(answer))
                {
                    numberDictionary.Add(answer, index);
                }
                else
                {
                    var earlierIndex = numberDictionary[answer] + 1;
                    numberDictionary[answer] = index - 1;
                    answer = index - earlierIndex;
                    if (!numberDictionary.ContainsKey(answer))
                    {
                        numberDictionary.Add(answer, index);
                    }
                }
                lastIndex = index;
            }

            return answer;
        }
    }
}