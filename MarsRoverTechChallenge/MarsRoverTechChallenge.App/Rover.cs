using System;

namespace MarsRoverTechChallenge.App
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public string Command { get; set; }
        public bool Crash { get; set; }
        // public int PlateauX { get; set; }
        // public int PlateauY { get; set; }

        public Rover(string startLocation, string command)
        {
            var splitLocation = startLocation.Split(" ");
            X = Int32.Parse(splitLocation[0]);
            Y = Int32.Parse(splitLocation[1]);
            Direction = splitLocation[2];
            Command = command;
            Crash = false;
        }

        //public Rover(string startLocation, string command, string[] plateauSize)
        //{
        //    var splitLocation = startLocation.Split(" ");
        //    X = Int32.Parse(splitLocation[0]);
        //    Y = Int32.Parse(splitLocation[1]);
        //    Direction = splitLocation[2];
        //    Command = command;
        //    Crash = false;
        //    PlateauX = Int32.Parse(plateauSize[0]);
        //    PlateauY = Int32.Parse(plateauSize[1]);
        //}

        public void TurnLeft()
        {
            switch (Direction)
            {
                case "N":
                    Direction = "W";
                    break;
                case "W":
                    Direction = "S";
                    break;
                case "S":
                    Direction = "E";
                    break;
                case "E":
                    Direction = "N";
                    break;
                default:
                    Console.WriteLine("Invalid direction");
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case "N":
                    Direction = "E";
                    break;
                case "E":
                    Direction = "S";
                    break;
                case "S":
                    Direction = "W";
                    break;
                case "W":
                    Direction = "N";
                    break;
                default:
                    Console.WriteLine("Invalid direction");
                    break;
            }
        }

        public void Move()
        {
            if (Crash == false)
            {
                switch (Direction)
                {
                    case "N":
                        // CheckIfCrashed(++Y, "++y");
                        ++Y;
                        break;
                    case "W":
                        // CheckIfCrashed(, "--x");
                        --X;
                        break;
                    case "S":
                        // CheckIfCrashed(--Y, "--y");
                        --Y;
                        break;
                    case "E":
                        // CheckIfCrashed(++X, "++x");
                        ++X;
                        break;
                    default:
                        Console.WriteLine("Invalid direction");
                        break;
                }
            }
        }

        //public void CheckIfCrashed(int positionChange, string fieldEval)
        //{
        //    switch (fieldEval)
        //    {
        //        case "++y":
        //            if (positionChange > PlateauY)
        //            {
        //                Crash = true;
        //            }
        //            break;
        //        case "--x":
        //            if (positionChange < PlateauX)
        //            {
        //                Crash = true;
        //            }
        //            break;
        //        case "--y":
        //            if (positionChange < PlateauY)
        //            {
        //                Crash = true;
        //            }
        //            break;
        //        case "++x":
        //            if (positionChange > PlateauX)
        //            {
        //                Crash = true;
        //            }
        //            break;
        //        default:
        //            Console.WriteLine("Invalid field to evaluate.");
        //            break;

        //    }

        //    if (Crash)
        //    {
        //        Console.WriteLine("This Rover has crashed.");
        //    }
        //}

        public void ExecuteCommands()
        {
            foreach (var command in Command)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            }
        }

        public void ReportFinalPosition()
        {
            Console.WriteLine("\n\n" + X + " " + Y + " " + Direction);
            Console.WriteLine("----------------------------\n");
        }


    }
}
