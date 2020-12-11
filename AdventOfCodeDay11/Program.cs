using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var seatsLayout = new List<string>();
            int answerPart1 = 0;
            int answerPart2 = 0;

            foreach (var item in input)
            {
                seatsLayout.Add(item);
            }

            answerPart1 = CheckSeatTraffic(seatsLayout);

            Console.WriteLine($"The answer of part 1 is: { answerPart1 } ");

            seatsLayout.Clear();

            foreach (var item in input)
            {
                seatsLayout.Add(item);
            }

            answerPart2 = NewCheckSeatTraffic(seatsLayout);

            Console.WriteLine($"The answer of part 1 is: { answerPart2 } ");


        }


        public static int CheckSeatTraffic(List<string> seatsLayout)
        {
            int answer = 0;
            bool checkChanges = false;
            
            var newLayout = new List<string>();

            while (checkChanges == false)
            {
                for (int row = 0; row < seatsLayout.Count; row++)
                {
                    for (int seat = 0; seat < seatsLayout[row].Length; seat++)
                    {
                        int emptySeat = 0;
                        int fullSeat = 0;
                        int topRow = 0;
                        int downRow = 0;
                        int leftSeat = 0;
                        int rightSeat = 0;

                        if (row != 0)
                        {
                            topRow = row - 1;
                        }
                        if (row != seatsLayout.Count)
                        {
                            downRow = row + 1;
                        }

                        if (seat != 0)
                        {
                            leftSeat = seat - 1;
                        }
                        if (seat != seatsLayout[row].Length)
                        {
                            rightSeat = seat + 1;
                        }

                        //left seat
                        if (leftSeat != seat)
                        {
                            if (seatsLayout[row][leftSeat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[row][leftSeat] == '#')
                            {
                                fullSeat++;
                            }
                        }
                        //Right seat
                        if (rightSeat != seatsLayout[row].Length)
                        {
                            if (seatsLayout[row][rightSeat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[row][rightSeat] == '#')
                            {
                                fullSeat++;
                            }
                        }

                        //top left seat
                        if (leftSeat != seat && topRow != row)
                        {
                            if (seatsLayout[topRow][leftSeat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[topRow][leftSeat] == '#')
                            {
                                fullSeat++;
                            }
                        }
                        //top Right seat
                        if (rightSeat != seatsLayout[row].Length && topRow != row)
                        {
                            if (seatsLayout[topRow][rightSeat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[topRow][rightSeat] == '#')
                            {
                                fullSeat++;
                            }
                        }

                        //down left seat
                        if (leftSeat != seat && downRow != seatsLayout.Count)
                        {
                            if (seatsLayout[downRow][leftSeat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[downRow][leftSeat] == '#')
                            {
                                fullSeat++;
                            }
                        }
                        //down Right seat
                        if (rightSeat != seatsLayout[row].Length && downRow != seatsLayout.Count)
                        {
                            if (seatsLayout[downRow][rightSeat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[downRow][rightSeat] == '#')
                            {
                                fullSeat++;
                            }
                        }

                        //top seat
                        if (topRow != row)
                        {
                            if (seatsLayout[topRow][seat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[topRow][seat] == '#')
                            {
                                fullSeat++;
                            }
                        }
                        //down seat
                        if (downRow != seatsLayout.Count)
                        {
                            if (seatsLayout[downRow][seat] == 'L')
                            {
                                emptySeat++;
                            }
                            else if (seatsLayout[downRow][seat] == '#')
                            {
                                fullSeat++;
                            }
                        }

                        if (newLayout.ElementAtOrDefault(row) == null)
                        {
                            if (seatsLayout[row][seat] == 'L')
                            {
                                if (fullSeat == 0)
                                {
                                    newLayout.Add("#");
                                }
                                else
                                {
                                    newLayout.Add("L");
                                }
                            }
                            else if (seatsLayout[row][seat] == '#')
                            {
                                if (fullSeat >= 4)
                                {
                                    newLayout.Add("L");
                                }
                                else
                                {
                                    newLayout.Add("#");
                                }
                            }
                            else if (seatsLayout[row][seat] == '.')
                            {
                                newLayout.Add(".");
                            }
                        }
                        else
                        {
                            if (seatsLayout[row][seat] == 'L')
                            {
                                if (fullSeat == 0)
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "#");
                                }
                                else
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "L");
                                }
                            }
                            else if (seatsLayout[row][seat] == '#')
                            {
                                if (fullSeat >= 4)
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "L");
                                }
                                else
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "#");
                                }
                            }
                            else if (seatsLayout[row][seat] == '.')
                            {
                                newLayout[row] = newLayout[row].Insert(seat, ".");
                            }
                        }
                    }
                }

                checkChanges = seatsLayout.SequenceEqual(newLayout);

                seatsLayout.Clear();

                foreach (var item in newLayout)
                {
                    seatsLayout.Add(item);
                }

                newLayout.Clear();

            }

            answer = seatsLayout.Sum(x => x.Count(x => x == '#'));

            return answer;
        }

        public static int NewCheckSeatTraffic(List<string> seatsLayout)
        {
            int answer = 0;
            bool checkChanges = false;

            var newLayout = new List<string>();

            while (checkChanges == false)
            {
                for (int row = 0; row < seatsLayout.Count; row++)
                {
                    for (int seat = 0; seat < seatsLayout[row].Length; seat++)
                    {
                        int emptySeat = 0;
                        int fullSeat = 0;
                        int topRow = 0;
                        int topRightCorner = 0;
                        int rightSeat = 0;
                        int downRightCorner = 0;
                        int downRow = 0;
                        int downLeftCorner = 0;
                        int leftSeat = 0;
                        int topLeftCorner = 0;
                        int newSeat = 0;

                        // Top
                        if (row != 0)
                        {
                            for (int look = row - 1; look < row; look--)
                            {
                                if (look > -1)
                                {
                                    if (seatsLayout[look][seat] == 'L')
                                    {
                                        emptySeat++;
                                        break;
                                    }
                                    if (seatsLayout[look][seat] == '#')
                                    {
                                        fullSeat++;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // Top right
                        if (row != 0 && seat != seatsLayout[row].Length)
                        {
                            newSeat = seat + 1;
                            for (int look = row - 1; look < row; look--, newSeat++)
                            {
                                if (newSeat != seatsLayout[row].Length && look > -1)
                                {
                                    if (seatsLayout[look][newSeat] == 'L')
                                    {
                                        emptySeat++;
                                        break;
                                    }
                                    if (seatsLayout[look][newSeat] == '#')
                                    {
                                        fullSeat++;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // Right
                        if (seat != seatsLayout[row].Length)
                        {
                            for (int look = seat + 1; look < seatsLayout[row].Length; look++)
                            {
                                if (seatsLayout[row][look] == 'L')
                                {
                                    emptySeat++;
                                    break;
                                }
                                if (seatsLayout[row][look] == '#')
                                {
                                    fullSeat++;
                                    break;
                                }
                            }
                        }
                        // Down right
                        if (seat != seatsLayout[row].Length && row != seatsLayout.Count)
                        {
                            newSeat = seat + 1;
                            for (int look = row + 1; look < seatsLayout.Count; look++, newSeat++)
                            {
                                if (newSeat < seatsLayout[row].Length && look < seatsLayout.Count)
                                {
                                    if (seatsLayout[look][newSeat] == 'L')
                                    {
                                        emptySeat++;
                                        break;
                                    }
                                    if (seatsLayout[look][newSeat] == '#')
                                    {
                                        fullSeat++;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // Down
                        if (row != seatsLayout.Count)
                        {
                            for (int look = row + 1; look < seatsLayout.Count; look++)
                            {
                                if (seatsLayout[look][seat] == 'L')
                                {
                                    emptySeat++;
                                    break;
                                }
                                if (seatsLayout[look][seat] == '#')
                                {
                                    fullSeat++;
                                    break;
                                }
                            }
                        }
                        // Down left
                        if (seat != 0 && row != seatsLayout.Count)
                        {
                            newSeat = seat - 1;
                            for (int look = row + 1; look < seatsLayout.Count; look++, newSeat--)
                            {
                                if (row < seatsLayout.Count && newSeat > -1)
                                {
                                    if (seatsLayout[look][newSeat] == 'L')
                                    {
                                        emptySeat++;
                                        break;
                                    }
                                    if (seatsLayout[look][newSeat] == '#')
                                    {
                                        fullSeat++;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // Left
                        if (seat != 0)
                        {
                            for (int look = seat - 1; 0 < seat; look--)
                            {
                                if (look > -1)
                                {
                                    if (seatsLayout[row][look] == 'L')
                                    {
                                        emptySeat++;
                                        break;
                                    }
                                    if (seatsLayout[row][look] == '#')
                                    {
                                        fullSeat++;
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // Top left
                        if (row != 0 && seat != 0)
                        {
                            if (seat != seatsLayout[row].Length && row != seatsLayout.Count)
                            {
                                newSeat = seat - 1;
                                for (int look = row - 1; look < row; look--, newSeat--)
                                {
                                    if (newSeat > -1 && look > -1)
                                    {
                                        if (seatsLayout[look][newSeat] == 'L')
                                        {
                                            emptySeat++;
                                            break;
                                        }
                                        if (seatsLayout[look][newSeat] == '#')
                                        {
                                            fullSeat++;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }


                        if (newLayout.ElementAtOrDefault(row) == null)
                        {
                            if (seatsLayout[row][seat] == 'L')
                            {
                                if (fullSeat == 0)
                                {
                                    newLayout.Add("#");
                                }
                                else
                                {
                                    newLayout.Add("L");
                                }
                            }
                            else if (seatsLayout[row][seat] == '#')
                            {
                                if (fullSeat >= 5)
                                {
                                    newLayout.Add("L");
                                }
                                else
                                {
                                    newLayout.Add("#");
                                }
                            }
                            else if (seatsLayout[row][seat] == '.')
                            {
                                newLayout.Add(".");
                            }
                        }
                        else
                        {
                            if (seatsLayout[row][seat] == 'L')
                            {
                                if (fullSeat == 0)
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "#");
                                }
                                else
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "L");
                                }
                            }
                            else if (seatsLayout[row][seat] == '#')
                            {
                                if (fullSeat >= 5)
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "L");
                                }
                                else
                                {
                                    newLayout[row] = newLayout[row].Insert(seat, "#");
                                }
                            }
                            else if (seatsLayout[row][seat] == '.')
                            {
                                newLayout[row] = newLayout[row].Insert(seat, ".");
                            }
                        }
                    }
                }

                checkChanges = seatsLayout.SequenceEqual(newLayout);

                seatsLayout.Clear();

                foreach (var item in newLayout)
                {
                    seatsLayout.Add(item);
                }

                newLayout.Clear();

            }

            answer = seatsLayout.Sum(x => x.Count(x => x == '#'));

            return answer;
        }
    }
}