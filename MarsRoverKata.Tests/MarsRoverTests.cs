using NUnit.Framework;
using MarsRoverKata;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class RoverTests
    {                
        [Test]
        public void SendSingleFCommandToRover()
        {
            

            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var position = rover.SendCommandToRover("F");
            Assert.IsNotNull(position);
            Assert.IsTrue(roverPosition.StartingY == 1);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "N");
        }

         [Test]
        public void SendSingleBCommandToRover()
        {
            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var position = rover.SendCommandToRover("B");
            Assert.IsNotNull(position);
            Assert.IsTrue(roverPosition.StartingY == 10);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "N");
        }

         [Test]
        public void SendSingleRCommandToRover()
        {
            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var position = rover.SendCommandToRover("R");
            Assert.IsNotNull(position);
            Assert.IsTrue(roverPosition.StartingY == 0);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "E");
        }

        [Test]
        public void SendSingleLCommandToRover()
        {
            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var position = rover.SendCommandToRover("L");
            Assert.IsNotNull(position);
            Assert.IsTrue(roverPosition.StartingY == 0);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "W");
        }

         [Test]
        public void SendSingleMultipleCommandToRover()
        {
            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var position = rover.SendCommandToRover("FFFBFFBR");
            Assert.IsNotNull(position);
            Assert.IsTrue(roverPosition.StartingY == 3);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "E");
        }

        [Test]
        public void SendSingleMultipleCommandToRoverMoreTest()
        {
            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var position = rover.SendCommandToRover("FFBBBLLBFFBR");
            Assert.IsNotNull(position);
            Assert.IsTrue(roverPosition.StartingY == 10);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "W");
        }

        [Test]
        public void SendSingleMultipleCommandToRoverMoreTestError()
        {
            Position roverPosition = new Position();
            roverPosition.StartingX = 0;
            roverPosition.StartingY = 0;
            roverPosition.FacingDirection = "N";

            var rover = new Rover(roverPosition, GetObstacles());
            var ex = Assert.Throws<Exception>(() => rover.SendCommandToRover("FFxBBLLBFFBR"));
            Assert.IsTrue(roverPosition.StartingY == 2);
            Assert.IsTrue(roverPosition.StartingX == 0);
            Assert.IsTrue(roverPosition.FacingDirection == "N");
        }


        private List<Obstacle> GetObstacles() 
        {
            return new List<Obstacle>(){
                new Obstacle {
                    PositionX = 3,
                    PositionY = 4
                },
                new Obstacle {
                    PositionX = 10,
                    PositionY = 2
                },
                new Obstacle {
                    PositionX = 4,
                    PositionY = 6
                }
            };
        }
    }
}