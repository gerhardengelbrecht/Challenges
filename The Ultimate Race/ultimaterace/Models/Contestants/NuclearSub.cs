using System;

namespace UltimateRace.Models.Contestants
{
    public class NuclearSub
    {
        public string Name = "NuclearSub";
        public int AverageSpeedInKnots = 40;
        public double BreakdownProbability = 0.0;
        public int AverageSpeed { get; set; }

        public NuclearSub()
        {
            this.AverageSpeed = Convert.ToInt32(this.AverageSpeedInKnots * 1.852);
        }
    }
}