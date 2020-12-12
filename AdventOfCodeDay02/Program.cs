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

            foreach (var item in input)
            {
                var arraySplit = item.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                int first = int.Parse(arraySplit[0]) - 1;
                int second = int.Parse(arraySplit[1]) - 1;
                char letter = arraySplit[2][0];
                string password = arraySplit[3];
                

                if(password[first] == letter ^ password[second] == letter)
                {
                    counter++;
                }
            }
            Console.WriteLine($"The anwser of part 2 is: {counter}");
        }
    }
}
