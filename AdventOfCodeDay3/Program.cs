using System;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepR3D1 = TraverseSlope(3, 1);

            Console.WriteLine($"Currently counted: { stepR3D1 } trees ");
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
                if (currentStepDown == input.Length)
                {
                    checkTree = input[currentStepDown - 1][currentStepRight];
                    if (checkTree == '#')
                    {
                        counter++;
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