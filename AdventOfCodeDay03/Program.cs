using System;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            long stepR1D1 = TraverseSlope(1, 1);
            long stepR3D1 = TraverseSlope(3, 1);
            long stepR5D1 = TraverseSlope(5, 1);
            long stepR7D1 = TraverseSlope(7, 1);
            long stepR1D2 = TraverseSlope(1, 2);

            long answer = stepR1D1 * stepR3D1 * stepR5D1 * stepR7D1 * stepR1D2;

            Console.WriteLine($"Part 1 answer: { stepR3D1 } trees ");
            Console.WriteLine($"Part 2 answer: { answer } trees ");

        }


        public static int TraverseSlope(int right, int down)
        {
            var input = File.ReadAllLines("input.txt");
            var newInput = File.ReadAllLines("input.txt");

            int counter = 0;

            int currentStepRight = 0;
            int currentStepDown = 0;

            int rowLength = input[0].Length;

            int checkRowLength = 0;

            do
            {
                char checkTree = ' ';
                if (currentStepDown >= input.Length)
                {
                    if (currentStepDown == input.Length)
                    {
                        checkTree = input[currentStepDown - 1][currentStepRight];
                        if (checkTree == '#')
                        {
                            counter++;
                        }
                    }
                    

                    break;
                }
                else if (currentStepRight < rowLength)
                {
                    checkTree = input[currentStepDown][currentStepRight];
                    input[currentStepDown] = input[currentStepDown].Remove(currentStepRight, 1);
                    input[currentStepDown] = input[currentStepDown].Insert(currentStepRight, "p");

                    currentStepRight += right;
                    currentStepDown += down;

                    if (checkTree == '#')
                    {
                        counter++;
                    }
                    checkRowLength = currentStepRight;

                }
                if (checkRowLength >= input[0].Length)
                {
                    for (int i = 0; i < newInput.Length; i++)
                    {
                        input[i] += newInput[i];
                    }
                    rowLength = rowLength + newInput[0].Length;
                }
            } while (checkRowLength < rowLength);

            return counter;
        }
    }
}