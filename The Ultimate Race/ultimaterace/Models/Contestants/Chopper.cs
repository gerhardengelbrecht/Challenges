using System;

namespace UltimateRace.Models.Contestants
{
    public class Chopper
    {
        public string Name = "Chopper";
        public int FuelCapacityGallons = 20;
        public int FuelUsagePerHourGallons = 8;
        public int AverageSpeed = 180;
        public int TimeToRefuelHours = 3;
        public double BreakdownProbability = 0.2;
        public int FuelCapacity { get; set; }
        public int FuelUsagePerHour { get; set; }

        public Chopper()
        {
            this.FuelCapacity = Convert.ToInt32(this.FuelCapacityGallons * 3.785);
            this.FuelUsagePerHour = Convert.ToInt32(this.FuelUsagePerHourGallons * 3.785);
        }
    }
}