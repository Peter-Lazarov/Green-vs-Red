using System;

namespace Green_vs_Red
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the Grid
            //int xLength = 4;
            //int yLength = 4;
            Console.WriteLine("Please write the size of the grid in this format x,y (3,9)");
            string firstLine = Console.ReadLine();
            string[] tempArray = firstLine.Split(",");

            int xLength = 0;
            int yLength = 0;

            try
            {
                xLength = Int32.Parse(tempArray[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("The " + tempArray[0] + " is not a number");
            }

            try
            {
                yLength = Int32.Parse(tempArray[1]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("The " + tempArray[1] + " is not a number");
            }

            int[,] allNumbers = new int[yLength, xLength];

            Console.WriteLine("Please write the first lines of the grid without separators (1010)");
            for (int y = 0; y < yLength; y++)
            {
                Console.WriteLine(yLength - y + " line left");
                string currentLine = Console.ReadLine();
                for (int x = 0; x < xLength; x++)
                {
                    allNumbers[y, x] = currentLine[x] - '0';
                }
            }

            Console.WriteLine("Please write the coordinate of cell to be checked how many times will be green and number of turns x,y,turns (1,2,10)");

            int coordinateX = 0;
            int coordinateY = 0;
            int turnsMax = 0;
            string coordinatesLine = Console.ReadLine();
            tempArray = coordinatesLine.Split(",");

            try
            {
                coordinateX = Int32.Parse(tempArray[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("The " + tempArray[0] + " is not a number");
            }

            try
            {
                coordinateY = Int32.Parse(tempArray[1]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("The " + tempArray[1] + " is not a number");
            }

            try
            {
                turnsMax = Int32.Parse(tempArray[2]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("The " + tempArray[2] + " is not a number");
            }

            int[,] forNextGeneration = new int[yLength, xLength];
            Array.Copy(allNumbers, forNextGeneration, allNumbers.Length);

            int a = 0;
            int turns = 0;
            while (turns < turnsMax)
            {
                for (int column = 0; column < yLength; column++)
                {
                    for (int row = 0; row < xLength; row++)
                    {
                        bool rowAbove = false;
                        bool rowBelow = false;

                        bool columnLeft = false;
                        bool columnRight = false;
                        int greenCellsCount = 0;

                        if (column - 1 > -1)
                        {
                            rowAbove = true;
                        }

                        if (column + 1 < xLength)
                        {
                            rowBelow = true;
                        }

                        if (row - 1 > -1)
                        {
                            columnLeft = true;
                        }

                        if (row + 1 < yLength)
                        {
                            columnRight = true;
                        }

                        if (rowAbove && rowBelow)
                        {
                            if (columnLeft && columnRight)
                            {
                                //full check - return count of green cells
                                greenCellsCount += allNumbers[column - 1, row - 1];
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column - 1, row + 1];
                                greenCellsCount += allNumbers[column, row - 1];
                                greenCellsCount += allNumbers[column, row + 1];
                                greenCellsCount += allNumbers[column + 1, row - 1];
                                greenCellsCount += allNumbers[column + 1, row];
                                greenCellsCount += allNumbers[column + 1, row + 1];
                            }
                            else if (columnLeft)
                            {
                                greenCellsCount += allNumbers[column - 1, row - 1];
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column, row - 1];
                                greenCellsCount += allNumbers[column + 1, row - 1];
                                greenCellsCount += allNumbers[column + 1, row];
                            }
                            else if (columnRight)
                            {
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column - 1, row + 1];
                                greenCellsCount += allNumbers[column, row + 1];
                                greenCellsCount += allNumbers[column + 1, row];
                                greenCellsCount += allNumbers[column + 1, row + 1];
                            }
                            else
                            {
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column + 1, row];
                            }
                        }
                        else if (rowAbove)
                        {
                            if (columnLeft && columnRight)
                            {
                                greenCellsCount += allNumbers[column - 1, row - 1];
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column - 1, row + 1];
                                greenCellsCount += allNumbers[column, row - 1];
                                greenCellsCount += allNumbers[column, row + 1];
                            }
                            else if (columnLeft)
                            {
                                greenCellsCount += allNumbers[column - 1, row - 1];
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column, row - 1];
                            }
                            else if (columnRight)
                            {
                                greenCellsCount += allNumbers[column - 1, row];
                                greenCellsCount += allNumbers[column - 1, row + 1];
                                greenCellsCount += allNumbers[column, row + 1];
                            }
                        }
                        else if (rowBelow)
                        {
                            if (columnLeft && columnRight)
                            {
                                greenCellsCount += allNumbers[column, row - 1];
                                greenCellsCount += allNumbers[column, row + 1];
                                greenCellsCount += allNumbers[column + 1, row - 1];
                                greenCellsCount += allNumbers[column + 1, row];
                                greenCellsCount += allNumbers[column + 1, row + 1];
                            }
                            else if (columnLeft)
                            {
                                greenCellsCount += allNumbers[column, row - 1];
                                greenCellsCount += allNumbers[column + 1, row - 1];
                                greenCellsCount += allNumbers[column + 1, row];
                            }
                            else if (columnRight)
                            {
                                greenCellsCount += allNumbers[column, row + 1];
                                greenCellsCount += allNumbers[column + 1, row];
                                greenCellsCount += allNumbers[column + 1, row + 1];
                            }
                        }

                        //If current cell is red
                        if (allNumbers[column, row] == 0)
                        {
                            if (greenCellsCount == 3 || greenCellsCount == 6)
                            {
                                //turn cell to green color - 1
                                forNextGeneration[column, row] = 1;
                            }
                            else
                            {
                                forNextGeneration[column, row] = 0;
                            }
                        }
                        //If current cell is green
                        else
                        {
                            if (greenCellsCount != 2 && greenCellsCount != 3 && greenCellsCount != 6)
                            {
                                //turn cell to red color - 0
                                forNextGeneration[column, row] = 0;
                            }
                            else
                            {
                                forNextGeneration[column, row] = 1;
                            }
                        }
                    }
                }
                Console.WriteLine();
                Array.Copy(forNextGeneration, allNumbers, forNextGeneration.Length);

                for (int i = 0; i < xLength; i++)
                {
                    for (int j = 0; j < yLength; j++)
                    {
                        Console.Write(allNumbers[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();

                if (allNumbers[coordinateX, coordinateY] == 1)
                {
                    a++;
                }

                turns++;
            }

            //Console.WriteLine(turns);

            Console.WriteLine("The cell " + coordinateX + "," + coordinateY + " was green " + a + " times.");
        }
    }
}
