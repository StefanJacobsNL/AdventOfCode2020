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
            List<int> numbers = new List<int>();

            foreach (var item in input[0].Split(','))
            {
                numbers.Add(int.Parse(item));
            }


            Console.WriteLine($"The answer of part 1 is: { NumberGame(numbers) } ");
        }

        public static int NumberGame(List<int> numbers)
        {
            int answer = numbers[0];
            int index = 0;
            List<int> usedNumbers = new List<int>();

            for (int i = 0; i < 2020; i++)
            {
                if (index < numbers.Count)
                {
                    if (!usedNumbers.Contains(numbers[index]))
                    {
                        usedNumbers.Add(numbers[index]);
                        answer = numbers[index];
                        index++;
                    }
                }
                else if (usedNumbers.Where(x => x == answer).Count() == 1)
                {
                    usedNumbers.Add(answer);
                    usedNumbers.Add(0);
                    numbers.Add(0);
                    answer = 0;
                    index++;
                }
                else
                {
                    var allIndexes = numbers.Select((item, index) => new { itemName = item, position = index }).Where(i => i.itemName == answer).ToList();

                    int lastNumber = allIndexes.Count() - 1;

                    int lastIndex = allIndexes[lastNumber].position + 1;
                    int secondLastIndex = allIndexes[lastNumber - 1].position + 1;

                    answer = lastIndex - secondLastIndex;
                    numbers.Add(answer);
                    usedNumbers.Add(answer);
                    index++;
                    
                }
            }

            answer = numbers.Last();

            return answer;
        }
    }
}