using System;

namespace AdventOfCodeDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");

            int[] result = new int[200];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = Convert.ToInt32(input[i]);
            }

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    // if 2020 together then multiply 
                    if (result[i] + result[j] == 2020)
                    {
                        System.Console.WriteLine(result[i] * result[j]);
                    }
                }
            }            
        }
    }
}
