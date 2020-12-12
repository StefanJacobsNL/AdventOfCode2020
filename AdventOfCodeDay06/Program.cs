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

            Console.WriteLine($"The answer of part 2 is: { answer } ");
        }

        public static int checkAnswers(IEnumerable<string> declarationFormList)
        {
            int counter = 0;
            var letterList = new List<char>();
            int groupSize = declarationFormList.Count();

            foreach (var item in declarationFormList)
            {
                var listSplits = item.ToCharArray();

                foreach (var letter in listSplits)
                {
                    letterList.Add(letter);
                }
            }

            letterList.Sort();

            if (groupSize == 1)
            {
                foreach (var item in letterList)
                {
                    counter++;
                }
            }
            else
            {
                var getDuplicates = letterList.GroupBy(x => x).Where(x => x.Count() == groupSize);

                foreach (var item in getDuplicates)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}