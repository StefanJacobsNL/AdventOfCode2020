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
            var numbers = new List<int>();
            long answerPart1 = 0;
            int joltage = 0;
            

            foreach (var item in input)
            {
                numbers.Add(int.Parse(item));
            }

            answerPart1 = CheckList(numbers, joltage);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
        }

        public static int CheckList(List<int> numbers, int joltage)
        {
            int answer = 0;
            int difference1 = 0;
            int difference3 = 1;

            numbers.Sort();

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
    }
}