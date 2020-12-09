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
            var preamble = new List<long>();
            var weaknessList = new List<long>();
            long answerPart1 = 0;
            long answerPart2 = 0;
            int counter = 0;
            int lengthPreamble = 25;
            

            foreach (var item in input)
            {
                numbers.Add(long.Parse(item));
            }

            foreach (var item in numbers)
            {
                if (counter == lengthPreamble)
                {
                    if (checkPreamble(preamble, item, lengthPreamble) == false)
                    {
                        preamble.RemoveAt(0);
                        preamble.Add(item);
                    }
                    else
                    {
                        answerPart1 = item;
                        break;
                    }
                }
                else
                {
                    preamble.Add(item);
                    counter++;
                }
            }

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");

            int index = 0;

            foreach (var item in numbers)
            {
                long sum = item;

                weaknessList.Add(item);

                for (int i = index; i < numbers.Count; i++)
                {
                    if (sum == answerPart1 && item != answerPart1)
                    {
                        weaknessList.Sort();

                        long first = weaknessList.First();
                        long last = weaknessList.Last();

                        answerPart2 = first + last;

                        break;
                    }
                    else if (sum > answerPart1)
                    {
                        index++;
                        sum = numbers[index];
                        weaknessList.Clear();
                        break;
                    }
                    if (sum != numbers[i])
                    {
                        sum += numbers[i];
                        weaknessList.Add(numbers[i]);
                    }
                }

                if (answerPart2 != 0)
                {
                    break;
                }
            }

            Console.WriteLine($"The answer of part 2 is: { answerPart2 } ");
        }

        public static bool checkPreamble(List<long> preamble, long number, int lengthPreamble)
        {
            bool check = false;
            var sumList = new List<long>();

            foreach (var item in preamble)
            {
                for (int i = 0; i < lengthPreamble; i++)
                {
                    if (item != preamble[i])
                    {
                        long sum = item + preamble[i];

                        if (sumList.Where(x => x == sum).Count() == 0)
                        {
                            sumList.Add(sum);
                        }
                    }
                }
            }

            if (sumList.Where(x => x == number).Count() == 0)
            {
                check = true;
            }

            return check;
        }
    }
}