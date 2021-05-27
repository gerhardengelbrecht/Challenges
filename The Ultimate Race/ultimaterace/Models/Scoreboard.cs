namespace UltimateRace.Models
{
    public class Scoreboard
    {
        public Scoreboard()
        {
            this.ChopperPosition = 0;
            this.BikePosition = 0;
            this.TeslaPosition = 0;
            this.NuclearSubPosition = 0;
        }

        public int ChopperDistanceToTravelToWin = 300; //7400;
        public int BikeDistanceToTravelToWin = 400; //9800;
        public int TeslaDistanceToTravelToWin = 500; //10200;
        public int NuclearSubDistanceToTravelToWin = 600; //11500;
        public int ChopperPosition { get; set; }
        public int BikePosition { get; set; }
        public int TeslaPosition { get; set; }
        public int NuclearSubPosition { get; set; }
    }
}