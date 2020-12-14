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

            var binaryt = input[2].Split(new[] { "mem[7] =" }, StringSplitOptions.RemoveEmptyEntries);

            //byte binary = Convert.ToByte(int.Parse(binaryt[0]));

            var asdsa = input[0].Split(new[] { "mask = " }, StringSplitOptions.RemoveEmptyEntries);

            var eeee = asdsa[0].Length;

            answerPart1 = SumOfAllValues(input);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
        }

        public static int SumOfAllValues(List<string> input)
        {
            int answer = 0;
            string mask = "";
            string result = "";

            result = Convert.ToString(11, 2);
            Console.WriteLine(result);

            foreach (var item in input)
            {
                if (item.Contains("mask"))
                {
                    var splitItems = item.Split(new[] { "mask =" }, StringSplitOptions.RemoveEmptyEntries);
                    mask = splitItems[0];
                }
                else if (item.Contains("mem"))
                {

                }
            }


            return answer;
        }
    }
}