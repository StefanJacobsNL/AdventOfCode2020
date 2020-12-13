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
            long answerPart2 = 0;
            var busList = new List<int>();
            var minutsList = new List<int>();
            long timeStap = int.Parse(input[0]);

            var busSplit = input[1].Split(new[] { ',', 'x' }, StringSplitOptions.RemoveEmptyEntries);
            var indexSplit = input[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var item in busSplit)
            {
                busList.Add(int.Parse(item));

                minutsList.Add(indexSplit.FindIndex(x => x == item));
            }

            answerPart1 = IDOfEarliestBus(timeStap, busList);
            answerPart2 = CheckForGoldenCoin(busList, minutsList);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
            Console.WriteLine($"The answer of part 2 is: { answerPart2 } ");
        }

        public static long CheckForGoldenCoin(List<int> busList, List<int>minutsList)
        {
            long answer = 0;
            long time = 0;
            int getIndex = 0;
            bool foundTime = false;
            var newTimes = new List<long>();
            int counter = 0;
            int counterCorrect = 0;

            foreach (var item in busList)
            {
                newTimes.Add(item);
            }

            while (foundTime == false)
            {
                foreach (var item in minutsList)
                {
                    if (newTimes.Contains(time) == true)
                    {
                        getIndex = newTimes.IndexOf(time);
                        newTimes[getIndex] += busList[getIndex];
                    }
                }

                foreach (var item in newTimes)
                {
                    if (item == newTimes[0] + minutsList[counter])
                    {
                        counterCorrect++;
                    }

                    counter++;
                }

                if (counterCorrect == busList.Count)
                {
                    foundTime = true;
                    answer = newTimes.Min();
                }
                else
                {
                    counter = 0;
                    counterCorrect = 0;
                    time++;
                }
            }

            return answer;
        }

        public static long IDOfEarliestBus(long timeStamp, List<int> busList)
        {
            long answer = 0;
            var departList = new List<long>();
            int busId = 0;
            long earliestTime = 0;

            foreach (var item in busList)
            {
                long departTime = GetTimeStapFromBus(item, timeStamp);
                departList.Add(departTime);
            }

            foreach (var item in busList)
            {
                if (GetTimeStapFromBus(item, timeStamp) == departList.Min())
                {
                    busId = item;
                    earliestTime = GetTimeStapFromBus(item, timeStamp);
                }
            }

            answer = busId * (departList.Min() - timeStamp);

            return answer;
        }

        public static long GetTimeStapFromBus(int busId, long timeStamp)
        {
            long earliestTime = 0;

            while (earliestTime < timeStamp)
            {
                earliestTime += busId;
            }

            return earliestTime;
        }
    }
}