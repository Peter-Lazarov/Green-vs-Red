using System;

namespace Green_vs_Red_OOP
{
    class Start
    {
        static void Main(string[] args)
        {
            //Ask user to enter numbers for grid size
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

            if (xLength > 999 || yLength > 999)
            {
                Console.WriteLine("The x and y must be lower than 1000");
                return;
            }

            //Build the grid
            Grid currentGrid = new Grid(xLength, yLength);
            
            //Setting values in the grid array
            currentGrid.SetTheGridGenerationZero();

            //Entering coordinates for searched point and number of turns
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

            int turns = 0;
            int timesSearchedPointIsOne = 0;

            //Making generations and checks for searched point value
            while (turns < turnsMax)
            {
                currentGrid.CalculateNextGeneration();
                currentGrid.PrintCurrentGeneration();
                timesSearchedPointIsOne += currentGrid.CheckForSearchedPoint(coordinateX, coordinateY);
                turns++;
            }

            Console.WriteLine("The cell " + coordinateX + "," + coordinateY + " was green " + timesSearchedPointIsOne + " times.");
            
        }
    }
}
