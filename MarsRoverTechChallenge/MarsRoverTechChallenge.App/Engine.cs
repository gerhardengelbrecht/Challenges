using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTechChallenge.App
{
    class Engine
    {
        public string[] PlateauSize { get; set; }

        public Engine()
        {
            Rovers = new List<Rover>();
        }

        public void ReadPlateauSize()
        {
            // Assumption: the correct values are going to be entered.
            // ToDo put in while loop incase nothing is entered.
            Console.WriteLine("Enter plateau size (x, y) e.g. \"5 5\": ");
            var plateauSize = Console.ReadLine();
            PlateauSize = plateauSize.Split(" ");
        }

        public List<Rover> Rovers { get; set; }

        public void ReadRoverInputData()
        {
            Console.WriteLine("Enter the number of rovers you want to create");
            var numberOfRovers = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRovers; i++)
            {
                Console.WriteLine("Enter rover start location, e.g: 1 2 N");
                string startLocation = Console.ReadLine();

                // Assumption: command will fall into the parameters of the grid, no checking if rover can go off the grid
                Console.WriteLine("Enter the command for the rover to execute, e.g: LMLMLMLMM");
                string command = Console.ReadLine();

                var rover = new Rover(startLocation, command);

                Rovers.Add(rover);
            }
        }

        public void PopulateTestData()
        {
            PlateauSize = "5 5".Split(" ");

            var rover1 = new Rover("1 2 N", "LMLMLMLMM");
            Rovers.Add(rover1);

            var rover2 = new Rover("3 3 E", "MMRMMRMRRM");
            Rovers.Add(rover2);
        }
    }
}
