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
            long answerPart1 = 0;
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