using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Green_vs_Red_OOP
{
    public class Grid
    {
        public Grid(int x, int y)
        {
            this.allNumbers = new int[x, y];
            this.forNextGeneration = new int[x, y];
            this.xLength = x;
            this.yLength = y;
        }

        public int xLength { get; private set; }
        public int yLength { get; private set; }

        public int[,] allNumbers { get; set; }
        private int[,] forNextGeneration { get; set; }

        public void SetTheGridGenerationZero()
        {
            Console.WriteLine("Please write the first lines of the grid without separators (1010)");
            for (int y = 0; y < yLength; y++)
            {
                Console.WriteLine(yLength - y + " line left");
                string currentLine = Console.ReadLine();
                for (int x = 0; x < xLength; x++)
                {
                    this.allNumbers[y, x] = currentLine[x] - '0';
                }
            }
            Array.Copy(this.allNumbers, this.forNextGeneration, this.allNumbers.Length);
        }

        public void CalculateNextGeneration()
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
                            greenCellsCount += this.allNumbers[column - 1, row - 1];
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column - 1, row + 1];
                            greenCellsCount += this.allNumbers[column, row - 1];
                            greenCellsCount += this.allNumbers[column, row + 1];
                            greenCellsCount += this.allNumbers[column + 1, row - 1];
                            greenCellsCount += this.allNumbers[column + 1, row];
                            greenCellsCount += this.allNumbers[column + 1, row + 1];
                        }
                        else if (columnLeft)
                        {
                            greenCellsCount += this.allNumbers[column - 1, row - 1];
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column, row - 1];
                            greenCellsCount += this.allNumbers[column + 1, row - 1];
                            greenCellsCount += this.allNumbers[column + 1, row];
                        }
                        else if (columnRight)
                        {
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column - 1, row + 1];
                            greenCellsCount += this.allNumbers[column, row + 1];
                            greenCellsCount += this.allNumbers[column + 1, row];
                            greenCellsCount += this.allNumbers[column + 1, row + 1];
                        }
                        else
                        {
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column + 1, row];
                        }
                    }
                    else if (rowAbove)
                    {
                        if (columnLeft && columnRight)
                        {
                            greenCellsCount += this.allNumbers[column - 1, row - 1];
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column - 1, row + 1];
                            greenCellsCount += this.allNumbers[column, row - 1];
                            greenCellsCount += this.allNumbers[column, row + 1];
                        }
                        else if (columnLeft)
                        {
                            greenCellsCount += this.allNumbers[column - 1, row - 1];
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column, row - 1];
                        }
                        else if (columnRight)
                        {
                            greenCellsCount += this.allNumbers[column - 1, row];
                            greenCellsCount += this.allNumbers[column - 1, row + 1];
                            greenCellsCount += this.allNumbers[column, row + 1];
                        }
                    }
                    else if (rowBelow)
                    {
                        if (columnLeft && columnRight)
                        {
                            greenCellsCount += this.allNumbers[column, row - 1];
                            greenCellsCount += this.allNumbers[column, row + 1];
                            greenCellsCount += this.allNumbers[column + 1, row - 1];
                            greenCellsCount += this.allNumbers[column + 1, row];
                            greenCellsCount += this.allNumbers[column + 1, row + 1];
                        }
                        else if (columnLeft)
                        {
                            greenCellsCount += this.allNumbers[column, row - 1];
                            greenCellsCount += this.allNumbers[column + 1, row - 1];
                            greenCellsCount += this.allNumbers[column + 1, row];
                        }
                        else if (columnRight)
                        {
                            greenCellsCount += this.allNumbers[column, row + 1];
                            greenCellsCount += this.allNumbers[column + 1, row];
                            greenCellsCount += this.allNumbers[column + 1, row + 1];
                        }
                    }

                    //If current cell is red
                    if (this.allNumbers[column, row] == 0)
                    {
                        if (greenCellsCount == 3 || greenCellsCount == 6)
                        {
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
                            forNextGeneration[column, row] = 0;
                        }
                        else
                        {
                            forNextGeneration[column, row] = 1;
                        }
                    }
                }
            }

            Array.Copy(this.forNextGeneration, this.allNumbers, this.forNextGeneration.Length);

            PrintCurrentGeneration();

            

        }

        public void PrintCurrentGeneration()
        {
            for (int i = 0; i < this.xLength; i++)
            {
                for (int j = 0; j < this.yLength; j++)
                {
                    Console.Write(this.allNumbers[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int CheckForSearchedPoint(int coodinateX, int coodinateY)
        {
            if (this.allNumbers[coodinateX, coodinateY] == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
