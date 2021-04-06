using System;

namespace MarsRoverTechChallenge.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.ReadPlateauSize();
            engine.ReadRoverInputData();
            //engine.PopulateTestData();

            foreach (var rover in engine.Rovers)
            {
                rover.ExecuteCommands();
                rover.ReportFinalPosition();
            }
        }
    }
}
