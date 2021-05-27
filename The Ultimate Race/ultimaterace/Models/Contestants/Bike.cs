using System;

namespace UltimateRace.Models.Contestants
{
    public class Bike
    {
        public string Name = "Bike";
        public double FuelCapacityDouble = 33.6;
        public double KilometersPerLiter = 8;
        public int AverageSpeed = 161;
        public double TimeToRefuelHours = 0.5;
        public double BreakdownProbability = 0.5;
        public int FuelCapacity { get; set; }

        public Bike()
        {
            this.FuelCapacity = Convert.ToInt32(this.FuelCapacityDouble);
        }
    }
}