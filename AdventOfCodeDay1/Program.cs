using System;
using System.Linq;

namespace AdventOfCodeDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");

            int[] result = new int[input.Length];

            int counter = 0;

            foreach (var item in input)
            {
                result[counter] = int.Parse(item);
                counter++;
            }

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = i++; j < result.Length; j++)
                {
                    for (int k = j++; k < result.Length; k++)
                    {
                        // if 2020 together then multiply 
                        if (result[i] + result[j] + result[k] == 2020)
                        {
                            int endResult = result[i] * result[j] * result[k];

                            System.Console.WriteLine($"The result: {result[i]} + {result[j]} + {result[k]} = 2020");
                            System.Console.WriteLine($"The result: {result[i]} * {result[j]} * {result[k]} = {endResult}");
                        }
                    }
                }
            }            
        }
    }
}
