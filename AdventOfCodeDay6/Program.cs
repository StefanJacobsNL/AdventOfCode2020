using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var declarationFormList = new List<string>();
            int counter = 0;
            int answer = 0;
            int checkAnswer = 0;

            foreach (var item in input)
            {
                counter++;
                if (string.IsNullOrEmpty(item))
                {
                    checkAnswer = checkAnswers(declarationFormList);

                    answer += checkAnswer;

                    declarationFormList.Clear();
                }
                else
                {
                    declarationFormList.Add(item);
                }
            }

            checkAnswer = checkAnswers(declarationFormList);

            answer += checkAnswer;

            Console.WriteLine($"The answer of part 1 is: { answer } ");
        }

        public static int checkAnswers(IEnumerable<string> declarationFormList)
        {
            int counter = 0;
            var letterList = new List<char>();

            foreach (var item in declarationFormList)
            {
                var listSplits = item.ToCharArray();

                foreach (var letter in listSplits)
                {
                    if (letterList.Contains(letter) == false)
                    {
                        letterList.Add(letter);
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}