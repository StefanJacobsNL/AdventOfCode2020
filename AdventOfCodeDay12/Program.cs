using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();
            int answerPart1 = 0;

            answerPart1 = TravelActions(input);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
        }


        public static int TravelActions(List<string> travelActions)
        {
            int answer = 0;
            int x = 0;
            int y = 0;
            char currentDirection = 'E';

            foreach (var item in travelActions)
            {
                var newDirection = item[0];
                int newMovement = int.Parse(item.Split(item[0]).Last());

                if (newDirection == 'L' || newDirection == 'R')
                {
                    currentDirection = GoLeftOrRight(currentDirection, item);
                }
                else if (newDirection == 'N')
                {
                    y += newMovement;
                }
                else if (newDirection == 'S')
                {
                    y -= newMovement;
                }
                else if (newDirection == 'E')
                {
                    x += newMovement;
                }
                else if (newDirection == 'W')
                {
                    x -= newMovement;
                }
                else if (newDirection == 'F')
                {
                    if (currentDirection == 'N')
                    {
                        y += newMovement;
                    }
                    else if (currentDirection == 'S')
                    {
                        y -= newMovement;
                    }
                    else if (currentDirection == 'E')
                    {
                        x += newMovement;
                    }
                    else if (currentDirection == 'W')
                    {
                        x -= newMovement;
                    }
                }
            }

            answer = Math.Abs(x) + Math.Abs(y);

            return answer;
        }


        public static char GoLeftOrRight(char currentDirection, string newDirection)
        {
            char leftOrRight = newDirection[0];
            int turningDegrees = int.Parse(newDirection.Split(leftOrRight).Last());


            if (turningDegrees == 90)
            {
                if (currentDirection == 'N')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'W';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'E';
                    }
                }
                else if (currentDirection == 'S')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'E';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'W';
                    }
                }
                else if (currentDirection == 'E')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'N';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'S';
                    }
                }
                else if (currentDirection == 'W')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'S';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'N';
                    }
                }
            }
            else if (turningDegrees == 180)
            {
                if (currentDirection == 'N')
                {
                    currentDirection = 'S';
                }
                else if (currentDirection == 'S')
                {
                    currentDirection = 'N';
                }
                else if (currentDirection == 'E')
                {
                    currentDirection = 'W';
                }
                else if (currentDirection == 'W')
                {
                    currentDirection = 'E';
                }
            }
            else if (turningDegrees == 270)
            {
                if (currentDirection == 'N')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'E';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'W';
                    }
                }
                else if (currentDirection == 'S')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'W';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'E';
                    }
                }
                else if (currentDirection == 'E')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'S';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'N';
                    }
                }
                else if (currentDirection == 'W')
                {
                    if (leftOrRight == 'L')
                    {
                        currentDirection = 'N';
                    }
                    else if (leftOrRight == 'R')
                    {
                        currentDirection = 'S';
                    }
                }
            }

            

            return currentDirection;
        }
    }
}