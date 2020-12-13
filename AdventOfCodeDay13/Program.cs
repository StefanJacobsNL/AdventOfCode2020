using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();
            long answerPart1 = 0;
            var busList = new List<int>();
            long timeStap = int.Parse(input[0]);

            var splitInput = input[1].Split(new[] { ',', 'x' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splitInput)
            {
                busList.Add(int.Parse(item));
            }

            answerPart1 = IDOfEarliestBus(timeStap, busList);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
        }

        public static long IDOfEarliestBus(long timeStap, List<int> busList)
        {
            long answer = 0;
            var departList = new List<long>();
            int busId = 0;
            long earliestTime = 0;

            foreach (var item in busList)
            {
                long departTime = GetTimeStapFromBus(item, timeStap);
                departList.Add(departTime);
            }

            foreach (var item in busList)
            {
                if (GetTimeStapFromBus(item, timeStap) == departList.Min())
                {
                    busId = item;
                    earliestTime = GetTimeStapFromBus(item, timeStap);
                }
            }

            answer = busId * (departList.Min() - timeStap);

            return answer;
        }

        public static long GetTimeStapFromBus(int busId, long timeStap)
        {
            long earliestTime = 0;

            while (earliestTime < timeStap)
            {
                earliestTime += busId;
            }

            return earliestTime;
        }
    }
}