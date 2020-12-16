using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay16
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").ToList();
            var instructions = new List<string>();
            var yourTicket = new List<int>();
            var nearbyTickets = new List<string>();
            int counter = 0;
            string lastItem = "";

            foreach (var item in input)
            {
                if (counter < 3)
                {
                    var splitInstructions = item.Split(new string[] { " ", "or" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var splitInstruction in splitInstructions)
                    {
                        instructions.Add(splitInstruction);
                    }
                    
                    counter++;
                }
                else if (lastItem == "your ticket:")
                {
                    var splitsYourticket = item.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var yourTicketNb in splitsYourticket)
                    {
                        yourTicket.Add(int.Parse(yourTicketNb));
                    }
                }
                else if (lastItem == "nearby tickets:" || counter == 6)
                {
                    nearbyTickets.Add(item);
                    counter = 6;
                }

                lastItem = item;
            }

            Console.WriteLine($"The answer of part 1 is: {ErrorRate(instructions, nearbyTickets)} ");

        }

        public static int ErrorRate(List<string> instructions, List<string> nearbyTickets)
        {
            int answer = 0;

            foreach (var nearbyTicket in nearbyTickets)
            {
                var ticketValues = nearbyTicket.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int countLenght = ticketValues.Count();

                foreach (var ticketValue in ticketValues)
                {
                    int checkValue = int.Parse(ticketValue);
                    bool correctValue = false;

                    foreach (var instruction in instructions)
                    {
                        var splitInstruction = instruction.Split('-');

                        if (splitInstruction.Count() == 2)
                        {
                            if (checkValue >= int.Parse(splitInstruction[0]) && checkValue <= int.Parse(splitInstruction[1]))
                            {
                                correctValue = true;
                                break;
                            }
                        }
                    }

                    if (correctValue == false)
                    {
                        answer += checkValue;
                    }
                }
            }

            return answer;
        }
    }
}