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
            int answerPart2 = 0;

            answerPart1 = TravelActions(input);
            answerPart2 = WaypointTracking(input);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");
            Console.WriteLine($"The answer of part 2 is: { answerPart2 } ");
        }


        public static int TravelActions(List<string> travelActions)
        {
            int answer = 0;
            int shipX = 0;
            int shipY = 0;
            
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
                    shipY += newMovement;
                }
                else if (newDirection == 'S')
                {
                    shipY -= newMovement;
                }
                else if (newDirection == 'E')
                {
                    shipX += newMovement;
                }
                else if (newDirection == 'W')
                {
                    shipX -= newMovement;
                }
                else if (newDirection == 'F')
                {
                    if (currentDirection == 'N')
                    {
                        shipY += newMovement;
                    }
                    else if (currentDirection == 'S')
                    {
                        shipY -= newMovement;
                    }
                    else if (currentDirection == 'E')
                    {
                        shipX += newMovement;
                    }
                    else if (currentDirection == 'W')
                    {
                        shipX -= newMovement;
                    }
                }
            }

            answer = Math.Abs(shipX) + Math.Abs(shipY);

            return answer;
        }

        public static int WaypointTracking(List<string> travelActions)
        {
            int answer = 0;
            int shipX = 0;
            int shipY = 0;
            int waypointX = 10;
            int waypointY = 1;
            
            foreach (var item in travelActions)
            {
                var newDirection = item[0];
                int newMovement = int.Parse(item.Split(item[0]).Last());
                int currentWaypointX = waypointX;
                int currentWaypointY = waypointY;

                if (newDirection == 'L' || newDirection == 'R')
                {
                    if (newMovement == 90)
                    {
                        if (newDirection == 'R')
                        {
                            waypointX = currentWaypointY;
                            waypointY = -currentWaypointX;
                        }
                        else if (newDirection == 'L')
                        {
                            waypointX = -currentWaypointY;
                            waypointY = currentWaypointX;
                        }

                    }
                    else if (newMovement == 180)
                    {
                        waypointY = -currentWaypointY;
                        waypointX = -currentWaypointX;
                    }
                    else if (newMovement == 270)
                    {
                        if (newDirection == 'R')
                        {
                            waypointX = -currentWaypointY;
                            waypointY = currentWaypointX;
                        }
                        else if (newDirection == 'L')
                        {
                            waypointX = currentWaypointY;
                            waypointY = -currentWaypointX;
                        }
                    }
                }
                else if (newDirection == 'N')
                {
                    waypointY += newMovement;
                }
                else if (newDirection == 'S')
                {
                    waypointY -= newMovement;
                }
                else if (newDirection == 'E')
                {
                    waypointX += newMovement;
                }
                else if (newDirection == 'W')
                {
                    waypointX -= newMovement;
                }
                else if (newDirection == 'F')
                {
                    shipY += waypointY * newMovement;
                    shipX += waypointX * newMovement;
                }
            }

            answer = Math.Abs(shipX) + Math.Abs(shipY);

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