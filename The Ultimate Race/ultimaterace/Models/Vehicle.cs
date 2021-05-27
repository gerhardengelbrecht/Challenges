namespace UltimateRace.Models
{
    public class Vehicle
    {
        public string Name { get; set; }
        public double TimeToRefuelHours { get; set; }
        public int FuelCapacity { get; set; }
        public int FuelUsagePerHour { get; set; }
        public int AverageSpeed { get; set; }
        public double BreakDownProbability { get; set; }
        public int EngineKw { get; set; }
        public int BatteryPack { get; set; }
        public double KilometersPerLiter { get; set; }

        public Vehicle()
        {
        }
    }
}
