using System;
using Xunit;
using MarsRoverTechChallenge.App;

namespace MarsRoverTechChallenge.UnitTests
{
    public class RoverMovementUnitTests
    {
        // 1. Rover should turn left
        // 2. Rover should turn right
        // 3. Rover should move forward
        // 4. Rover should go to "2 4 N"
        // 5. Rover should go to "3 4 E"
        // 6. Rover should give a error "coordinates outside of grid"
        // 7. Rover should calculate if movement is possible before moving
        // 8. Rover should give signal that commands have have been executed // so that next Rover can begin its movements 
        // 9. Next Rover needs to get command that it needs to start it set of commands

        // Test Data
        // Test Input:
        // 5 5 // Start of app you enter the plateau size
        // 1 2 N
        // LMLMLMLMM

        // 3 3 E
        // MMRMMRMRRM

        //Expected Output:
        //1 3 N
        //5 1 E

        // Assumption all Rovers operate on the same size plateau

        [Fact]
        public void TurnLeft_FacingNorth_FacingWest()
        {
            var rover = new Rover("1 2 N", "L");

            rover.TurnLeft();

            Assert.Equal("W",rover.Direction);
        }

        [Fact]
        public void TurnLeft_FacingWest_FacingSouth()
        {
            var rover = new Rover("1 2 W", "L");

            rover.TurnLeft();

            Assert.Equal("S",rover.Direction);
        }

        [Fact]
        public void TurnLeft_FacingSouth_FacingEast()
        {
            var rover = new Rover("1 2 S", "L");

            rover.TurnLeft();

            Assert.Equal("E",rover.Direction);
        }

        [Fact]
        public void TurnLeft_FacingEast_FacingNorth()
        {
            var rover = new Rover("1 2 E", "L");

            rover.TurnLeft();

            Assert.Equal("N",rover.Direction);
        }

        [Fact]
        public void TurnRight_FacingNorth_FacingEast()
        {
            var rover = new Rover("1 2 N", "R");

            rover.TurnRight();

            Assert.Equal("E",rover.Direction);
        }

        [Fact]
        public void TurnRight_FacingEast_FacingSouth()
        {
            var rover = new Rover("1 2 E", "R");

            rover.TurnRight();

            Assert.Equal("S",rover.Direction);
        }

        [Fact]
        public void TurnRight_FacingSouth_FacingWest()
        {
            var rover = new Rover("1 2 S", "R");

            rover.TurnRight();

            Assert.Equal("W",rover.Direction);
        }

        [Fact]
        public void TurnRight_FacingWest_FacingNorth()
        {
            var rover = new Rover("1 2 W", "R");

            rover.TurnRight();

            Assert.Equal("N",rover.Direction);
        }

        [Fact]
        public void MoveForward_FacingNorth_YPositionIncreaseByOne()
        {
            var rover = new Rover("1 2 N", "M");

            var splitLocation = "1 2 N".Split(" ");
            var y = Int32.Parse(splitLocation[1]);

            rover.Move();

            Assert.Equal(y + 1,rover.Y);
        }

        [Fact]
        public void MoveForward_FacingEast_XPositionIncreaseByOne()
        {
            var rover = new Rover("1 2 E", "M");

            var splitLocation = "1 2 E".Split(" ");
            var x = Int32.Parse(splitLocation[0]);

            rover.Move();

            Assert.Equal(x + 1,rover.X);
        }

        [Fact]
        public void MoveForward_FacingSouth_YPositionDecreaseByOne()
        {
            var rover = new Rover("1 2 S", "M");

            var splitLocation = "1 2 S".Split(" ");
            var y = Int32.Parse(splitLocation[1]);

            rover.Move();

            Assert.Equal(y - 1,rover.Y);
        }

        [Fact]
        public void MoveForward_FacingWest_XPositionDecreaseByOne()
        {
            var rover = new Rover("1 2 W", "M");

            var splitLocation = "1 2 W".Split(" ");
            var x = Int32.Parse(splitLocation[0]);

            rover.Move();

            Assert.Equal(x - 1,rover.X);
        }
    }
}
