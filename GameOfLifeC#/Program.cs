using GameOfLife.Enums;
using System;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    internal delegate void ProcessHandler(GameState gameState);

    internal class Program
    {
        public static LifeState[,] GridOfLife { get; set; }
        public static LifeState[,] TempGridOfLife { get; set; }
        public static int BoardSizeX { get; set; }
        public static int BoardSizeY { get; set; }
        public static int Generations { get; set; }
        public static char Cell { get; set; }
        public static int XAcross { get; set; }
        public static int YDown { get; set; }
        public static int Sleep { get; set; }

        public static Random Random = new Random();
        public static StringBuilder GridString = new StringBuilder();

        private static void Main()
        {
            ReadInput();
            ConfigureBoard();
            Engine();
        }

        private static void ReadInput()
        {
            while (true)
            {
                int xValue;
                Console.WriteLine("Enter Board X Access Size:");
                var maxConsoleWidth = Console.LargestWindowWidth;
                Console.WriteLine($"The largest width you can choose is: {maxConsoleWidth}");
                var xInput = Console.ReadLine();
                if (int.TryParse(xInput, out xValue) && xValue <= maxConsoleWidth)
                {
                    BoardSizeX = Convert.ToInt32(xValue);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (xValue > maxConsoleWidth)
                    {
                        Console.WriteLine($"Console width cant be greater than: {maxConsoleWidth}");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number.");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            while (true)
            {
                int yValue;
                Console.WriteLine("Enter Board Y Access Size:");
                var maxConsoleHeight = Console.LargestWindowHeight;
                Console.WriteLine($"The largest height you can choose is: {maxConsoleHeight}");
                var yInput = Console.ReadLine();
                if (int.TryParse(yInput, out yValue) && yValue <= maxConsoleHeight )
                {
                    BoardSizeY = Convert.ToInt32(yValue);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (yValue > maxConsoleHeight)
                    {
                        Console.WriteLine($"Console height cant be greater than: {maxConsoleHeight}");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number.");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (true)
            {
                int genValue;
                Console.WriteLine("Enter number of generations:");
                var yInput = Console.ReadLine();
                if (int.TryParse(yInput, out genValue))
                {
                    Generations = Convert.ToInt32(genValue);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.Clear();
        }

        private static void ConfigureBoard()
        {
            Console.CursorVisible = false;
            Cell = (char) 245; // Circle
            // Cell = (char) 254; // Circle
            GridOfLife = new LifeState[BoardSizeX, BoardSizeY];
            TempGridOfLife = new LifeState[BoardSizeX, BoardSizeY];
            XAcross = BoardSizeX - 1;
            YDown = BoardSizeY - 1;
            Console.WindowWidth = XAcross;
            Console.WindowHeight = YDown;
            Sleep = 100;
        }

        private static void Engine()
        {
            ProcessHandler processHandler = ProcessGrid;
            processHandler(GameState.Populate);

            if (Generations == 0)
            {
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        processHandler(GameState.Check);

                        processHandler(GameState.Print);

                        Thread.Sleep(20);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            else
            {
                var generationsCount = 0;
                while (generationsCount <= Generations)
                {
                    processHandler(GameState.Check);

                    processHandler(GameState.Print);

                    Thread.Sleep(Sleep);

                    generationsCount++;
                }
            }
        }

        private static void ProcessGrid(GameState gameState)
        {
            if (gameState == GameState.Print)
            {
                GridOfLife = (LifeState[,]) TempGridOfLife.Clone();
                GridString.Clear();
            }
            else if (gameState == GameState.Check)
            {
                TempGridOfLife = (LifeState[,]) GridOfLife.Clone();
            }

            for (int y = 0; y <= YDown; y++)
            {
                for (int x = 0; x <= XAcross; x++)
                {
                    if (gameState == GameState.Print)
                    {
                        if (GridOfLife[x, y] == LifeState.Alive)
                        {
                            GridString.Append(Cell);
                        }
                        else
                        {
                            GridString.Append(" ");
                        }
                    }
                    else if (gameState == GameState.Check)
                    {
                        CheckGrid(x, y);
                    }
                    else if (gameState == GameState.Populate)
                    {
                        if (Random.Next(1, 11) == 1)
                        {
                            GridOfLife[x, y] = LifeState.Alive;
                        }
                    }
                }

                if (gameState == GameState.Print)
                {
                    if (y != 29)
                    {
                        GridString.AppendLine();
                    }
                }
            }

            if (gameState == GameState.Print)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(GridString);
            }
        }

        private static void CheckGrid(int x, int y)
        {
            var neighbors = CountCellNeighbours(x, y);

            if (GridOfLife[x, y] == LifeState.Alive)
            {
                if (neighbors < 2)
                {
                    TempGridOfLife[x, y] = LifeState.Dead;
                }

                if (neighbors == 2 || neighbors == 3)
                {
                    TempGridOfLife[x, y] = LifeState.Alive;
                }
                else if (neighbors > 3)
                {
                    TempGridOfLife[x, y] = LifeState.Dead;
                }
            }
            else if (neighbors == 3)
            {
                TempGridOfLife[x, y] = LifeState.Alive;
            }
        }

        private static int CountCellNeighbours(int x, int y)
        {
            var neighbours = 0;
            var xTemp = x;
            var yTemp = y;

            if (x - 1 == -1 || x + 1 == XAcross + 1 || y - 1 == -1 || y + 1 == YDown + 1)
            {
                // Left row
                xTemp = x - 1 == -1 ? XAcross : x - 1;
                yTemp = y - 1 == -1 ? YDown : y - 1;
                neighbours = GridOfLife[xTemp, yTemp] == LifeState.Alive ? ++neighbours : neighbours;

                neighbours = GridOfLife[xTemp, y] == LifeState.Alive ? ++neighbours : neighbours;

                yTemp = y + 1 == YDown + 1 ? 0 : y + 1;
                neighbours = GridOfLife[xTemp, yTemp] == LifeState.Alive ? ++neighbours : neighbours;

                // Middle row
                yTemp = y - 1 == -1 ? YDown : y - 1;
                neighbours = GridOfLife[x, yTemp] == LifeState.Alive ? ++neighbours : neighbours;

                yTemp = y + 1 == YDown + 1 ? 0 : y + 1;
                neighbours = GridOfLife[x, yTemp] == LifeState.Alive ? ++neighbours : neighbours;

                // Right row
                xTemp = x + 1 == XAcross + 1 ? 0 : x + 1;
                yTemp = y - 1 == -1 ? YDown : y - 1;
                neighbours = GridOfLife[xTemp, yTemp] == LifeState.Alive ? ++neighbours : neighbours;

                neighbours = GridOfLife[xTemp, y] == LifeState.Alive ? ++neighbours : neighbours;

                yTemp = y + 1 == YDown + 1 ? 0 : y + 1;
                neighbours = GridOfLife[xTemp, yTemp] == LifeState.Alive ? ++neighbours : neighbours;
            }
            else
            {
                // Left row
                neighbours = GridOfLife[x - 1, y - 1] == LifeState.Alive ? ++neighbours : neighbours;
                neighbours = GridOfLife[x - 1, y] == LifeState.Alive ? ++neighbours : neighbours;
                neighbours = GridOfLife[x - 1, y + 1] == LifeState.Alive ? ++neighbours : neighbours;

                // Middle row
                neighbours = GridOfLife[x, y - 1] == LifeState.Alive ? ++neighbours : neighbours;
                neighbours = GridOfLife[x, y + 1] == LifeState.Alive ? ++neighbours : neighbours;

                // Right row
                neighbours = GridOfLife[x + 1, y - 1] == LifeState.Alive ? ++neighbours : neighbours;
                neighbours = GridOfLife[x + 1, y] == LifeState.Alive ? ++neighbours : neighbours;
                neighbours = GridOfLife[x + 1, y + 1] == LifeState.Alive ? ++neighbours : neighbours;
            }

            return neighbours;
        }
    }
}