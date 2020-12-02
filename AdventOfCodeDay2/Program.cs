using System;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("InputDay2.txt");

            int counter = 0;

            int[] result = new int[input.Length];

            foreach (var item in input)
            {
                var arraySplit = item.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                
                string letter = arraySplit[2];

                int test = arraySplit[3].Count(x => x == arraySplit[2][0]);


                if(test >= int.Parse(arraySplit[0]) && test <= int.Parse(arraySplit[1]))
                {
                    counter++;
                }
            }
            Console.WriteLine($"The anwser is: {counter}");
        }
    }
}
