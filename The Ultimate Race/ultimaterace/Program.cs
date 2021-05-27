using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UltimateRace.Models;
using UltimateRace.Models.Contestants;

namespace UltimateRace
{
    class Program
    {
        static int NumberOfContestants = 6;
        static Thread[] Contestant = new Thread[NumberOfContestants];
        static int CurrentContestant = 0;
        static Scoreboard Scoreboard = new Scoreboard();
        static Random Random = new Random();
        static List<Vehicle> Contestants = new List<Vehicle>();
        private static bool _bikeHasFinished = false;
        private static bool _teslaHasFinished = false;
        private static bool _nuclearSubHasFinished = false;
        private static bool _chopperHasFinished = false;
        private static bool _bikeHasWon = false;
        private static bool _teslaHasWon = false;
        private static bool _nuclearSubHasWon = false;
        private static bool _chopperHasWon = false;
        private static int _position = 0;


        static void Main(string[] args)
        {
            // Announcements();
            EnrollContestants();
            ThreadContestants();
            StartRace();
        }

        private static void EnrollContestants()
        {
            EnrollChopper();
            EnrollBike();
            EnrollTesla();
            EnrollNuclearSub();
        }

        private static void EnrollChopper()
        {
            var chopperProperties = new Chopper();
            var chopper = new Vehicle
            {
                Name = chopperProperties.Name,
                FuelCapacity = chopperProperties.FuelCapacity,
                TimeToRefuelHours = chopperProperties.TimeToRefuelHours,
                FuelUsagePerHour = chopperProperties.FuelUsagePerHour,
                AverageSpeed = chopperProperties.AverageSpeed,
                BreakDownProbability = chopperProperties.BreakdownProbability
            };

            Contestants.Add(chopper);
        }

        private static void EnrollNuclearSub()
        {
            var nuclearSubProperties = new NuclearSub();
            var nuclearSub = new Vehicle
            {
                Name = nuclearSubProperties.Name,
                AverageSpeed = nuclearSubProperties.AverageSpeed,
                BreakDownProbability = nuclearSubProperties.BreakdownProbability
            };

            Contestants.Add(nuclearSub);
        }

        private static void EnrollTesla()
        {
            var teslaProperties = new Tesla();
            var tesla = new Vehicle
            {
                Name = teslaProperties.Name,
                TimeToRefuelHours = teslaProperties.TimeToRefuelHours,
                AverageSpeed = teslaProperties.AverageSpeed,
                BreakDownProbability = teslaProperties.BreakdownProbability,
                EngineKw = teslaProperties.EngineKw,
                BatteryPack = teslaProperties.EngineKw
            };

            Contestants.Add(tesla);
        }

        private static void EnrollBike()
        {
            var bikeProperties = new Bike();
            var bike = new Vehicle
            {
                Name = bikeProperties.Name,
                FuelCapacity = (int) bikeProperties.FuelCapacity,
                TimeToRefuelHours = bikeProperties.TimeToRefuelHours,
                AverageSpeed = bikeProperties.AverageSpeed,
                BreakDownProbability = bikeProperties.BreakdownProbability,
                KilometersPerLiter = bikeProperties.KilometersPerLiter
            };

            Contestants.Add(bike);
        }

        private static void Announcements()
        {
            Console.WriteLine("WELCOME!!!");
            Thread.Sleep(1000);
            Console.WriteLine("To the ULTIMATE RACE!!!");
            Thread.Sleep(1000);
            Console.WriteLine("Travel from Cairo to Cape Town.");
            Thread.Sleep(1000);
            Console.Write("A journey of blood");
            Thread.Sleep(1000);
            Console.Write(", sweat");
            Thread.Sleep(1000);
            Console.WriteLine(", and gears!");
            Thread.Sleep(1000);
            Console.WriteLine("Gentlemen, start your engine!");
            Thread.Sleep(1000);
            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("1");
            Thread.Sleep(1000);
            Console.WriteLine("Go!!!!");
            Thread.Sleep(1000);
        }

        private static void ThreadContestants()
        {
            for (var i = 0; i <= Contestants.Count; i++)
            {
                Contestant[i] = new Thread(HandleThreadStart);
            }
        }

        private static void StartRace()
        {
            for (var i = 0; i <= Contestants.Count; i++)
            {
                Contestant[i].Start();
            }
        }

        private static void CheckRaceStatus()
        {
            if (!_bikeHasWon && Scoreboard.ChopperPosition > Scoreboard.ChopperDistanceToTravelToWin)
            {
                if (_position == 0)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Bike has won!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
                    _position++;
                }
                else
                {
                    _position++;
                    PositionWon("Bike");
                }

                _bikeHasWon = true;
            }
            else if (!_chopperHasWon && Scoreboard.BikePosition > Scoreboard.BikeDistanceToTravelToWin)
            {
                if (_position == 0)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Chopper has won!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
                    _position++;
                }
                else
                {
                    _position++;
                    PositionWon("Chopper");
                }

                _chopperHasWon = true;
            }
            else if (!_teslaHasWon && Scoreboard.TeslaPosition > Scoreboard.TeslaDistanceToTravelToWin)
            {
                if (_position == 0)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Tesla has won!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
                    _position++;
                }
                else
                {
                    _position++;
                    PositionWon("Tesla");
                }

                _teslaHasWon = true;
            }
            else if (!_nuclearSubHasWon && Scoreboard.NuclearSubPosition > Scoreboard.NuclearSubDistanceToTravelToWin)
            {
                if (_position == 0)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("NuclearSub has won!");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
                    _position++;
                }
                else
                {
                    _position++;
                    PositionWon("NuclearSub");
                }

                _nuclearSubHasWon = true;
            }
            
            if (_nuclearSubHasWon && _chopperHasWon && _teslaHasWon && _bikeHasWon)
            {
                Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Race is finished!");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");

                Thread.Sleep(1000);

                Contestant[1].Interrupt();
                Contestant[2].Interrupt();
                Contestant[3].Interrupt();
                Contestant[4].Interrupt();
            }
        }

        private static void PositionWon(string vehicle)
        {
            if (_position == 2)
            {
                Console.WriteLine($"Finished: {vehicle} came {_position}nd.\n");
            }
            else if (_position == 3)
            {
                Console.WriteLine($"Finished: {vehicle} came {_position}rd.\n");
            }
            else if (_position == 4)
            {
                Console.WriteLine($"Finished: {vehicle} came {_position}th.\n");
            }
        }

        protected static void HandleThreadStart()
        {
            if (CurrentContestant == 0)
            {
                CurrentContestant++;
                StartChopper();
            }
            else if (CurrentContestant == 1)
            {
                CurrentContestant++;
                StartBike();
            }
            else if (CurrentContestant == 2)
            {
                CurrentContestant++;
                StartTesla();
            }
            else if (CurrentContestant == 3)
            {
                CurrentContestant++;
                StartNuclearSub();
            }
        }

        private static void StartChopper()
        {
            var chopper = Contestants.Single(c => c.Name == "Chopper");
            int fuel = chopper.FuelCapacity;

            while (!_chopperHasFinished)
            {
                Thread.Sleep(1000);
                Scoreboard.ChopperPosition += chopper.AverageSpeed;
                Console.WriteLine(
                    $"TRAVELED: Chopper has traveled -----------------> {Scoreboard.ChopperPosition} Km / And still has todo {Scoreboard.ChopperDistanceToTravelToWin - Scoreboard.ChopperPosition}\n");
                fuel -= chopper.FuelUsagePerHour;

                if (fuel < 0)
                {
                    Console.WriteLine("MISHAP: Chopper out of fuel :(\n");
                    Thread.Sleep(chopper.FuelUsagePerHour * 1000);
                    fuel = chopper.FuelCapacity;
                    Console.WriteLine("MISHAP: Chopper is back in the air and in the race!!\n");
                }

                VehicleBreakDown(chopper);

                if (Scoreboard.ChopperPosition > Scoreboard.ChopperDistanceToTravelToWin)
                {
                    _chopperHasFinished = true;
                    CheckRaceStatus();
                }
            }
        }

        private static void StartBike()
        {
            var bike = Contestants.Single(b => b.Name == "Bike");
            int fuel = bike.FuelCapacity;

            while (!_bikeHasFinished)
            {
                Thread.Sleep(1000);
                Scoreboard.BikePosition += bike.AverageSpeed;
                Console.WriteLine(
                    $"TRAVELED: Bike has traveled -----------------> {Scoreboard.BikePosition} Km / And still has todo {Scoreboard.BikeDistanceToTravelToWin - Scoreboard.BikePosition}\n");
                fuel -= (int) (bike.AverageSpeed / bike.KilometersPerLiter);

                if (fuel < 0)
                {
                    Console.WriteLine("MISHAP: Bike out of fuel :(\n");
                    Thread.Sleep((int) (bike.TimeToRefuelHours * 1000));
                    fuel = (int) bike.TimeToRefuelHours;
                    Console.WriteLine("MISHAP: Bike is back on the dirt tracks and in the race!!\n");
                }


                VehicleBreakDown(bike);

                if (Scoreboard.BikePosition > Scoreboard.BikeDistanceToTravelToWin)
                {
                    _bikeHasFinished = true;
                    CheckRaceStatus();
                }
            }
        }

        private static void StartTesla()
        {
            var tesla = Contestants.Single(t => t.Name == "Tesla");

            double batteryLeft = tesla.BatteryPack;

            while (!_teslaHasFinished)
            {
                Thread.Sleep(1000);
                Scoreboard.TeslaPosition += tesla.AverageSpeed;
                Console.WriteLine($"TRAVELED: Tesla has traveled -----------------> {Scoreboard.TeslaPosition} Km / And still has todo {Scoreboard.TeslaDistanceToTravelToWin - Scoreboard.TeslaPosition}\n");
                batteryLeft -= tesla.EngineKw;

                if (batteryLeft < 0)
                {
                    Console.WriteLine("MISHAP: Tesla out of battery :(\n");
                    Thread.Sleep((int) tesla.TimeToRefuelHours * 1000);
                    batteryLeft = tesla.BatteryPack;
                    Console.WriteLine("MISHAP: Tesla is back on the road and in the race!!\n");
                }

                VehicleBreakDown(tesla);

                if (Scoreboard.TeslaPosition > Scoreboard.TeslaDistanceToTravelToWin)
                {
                    _teslaHasFinished = true;
                    CheckRaceStatus();
                }
            }
        }

        private static void StartNuclearSub()
        {
            var nuclearSub = Contestants.Single(n => n.Name == "NuclearSub");

            while (!_nuclearSubHasFinished)
            {
                Thread.Sleep(1000);
                Scoreboard.NuclearSubPosition += nuclearSub.AverageSpeed;
                Console.WriteLine($"TRAVELED: Sub has traveled -----------------> {Scoreboard.NuclearSubPosition} Km / And still has todo {Scoreboard.NuclearSubDistanceToTravelToWin - Scoreboard.NuclearSubPosition}\n");

                VehicleBreakDown(nuclearSub);


                if (Scoreboard.NuclearSubPosition > Scoreboard.NuclearSubDistanceToTravelToWin)
                {
                    _nuclearSubHasFinished = true;
                    CheckRaceStatus();
                }
            }
        }

        private static void VehicleBreakDown(Vehicle model)
        {
            if (Random.NextDouble() < model.BreakDownProbability)
            {
                int repairTime = (int) (Random.NextDouble() / Random.NextDouble() * 1000) + 1000;
                Console.WriteLine($"MISHAP: {model.Name} has broken down :(\n");
                Console.WriteLine($"MISHAP: It will take {repairTime / 1000} Hrs to repair\n");
                Thread.Sleep(repairTime);
                Console.WriteLine($"RESOLUTION: {model.Name} is back in the water and in the race!!\n");
            }
        }
    }
}