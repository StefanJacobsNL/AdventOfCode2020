using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeDay5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            int row = 8;

            var seatIDList = new List<int>();

            foreach (var item in input)
            {
                int rowNumber = GetRow(item.Substring(0, 7));
                int columnNumber = GetColumn(item.Substring(7));
                int seatID = rowNumber * row + columnNumber;
                seatIDList.Add(seatID);
            }

            int maxSeatID = seatIDList.Max();

            Console.WriteLine($"The answer of part 1 is: the highest seat ID is { maxSeatID } ");
        }

        public static int GetRow(string seatInput)
        {
            int minRows = 0;
            int maxRows = 127;

            for (int i = 0; i < seatInput.Length; i++)
            {
                int size = (maxRows - minRows) + 1;
                int newSize = size / 2;

                if (seatInput[i] == 'F')
                {
                    maxRows -= newSize;
                }
                else if (seatInput[i] == 'B')
                {
                    minRows += newSize;
                }
            }

            return minRows;
        }

        public static int GetColumn(string seatInput)
        {
            int minColumn = 0;
            int maxColumn = 7;

            for (int i = 0; i < seatInput.Length; i++)
            {
                int size = (maxColumn - minColumn) + 1;
                int newSize = size / 2;

                if (seatInput[i] == 'L')
                {
                    maxColumn -= newSize;
                }
                else if (seatInput[i] == 'R')
                {
                    minColumn += newSize;
                }
            }

            return minColumn;
        }
    }
}