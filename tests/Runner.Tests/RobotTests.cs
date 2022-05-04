using RobotWars.Runner.Models;
using System;
using Xunit;

namespace RobotWars.Runner.Tests
{
    public class RobotTests
    {
        [Fact]
        public void ConstructorSetsTheExpectedPropertyValues()
        {
            var robot = new Robot(new Arena(5, 5), 1, 2, Direction.North);
            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);
            Assert.Equal(Direction.North, robot.Direction);
        }

        [Fact]
        public void ExecuteTurnsTheRobotLeft()
        {
            var robot = new Robot(new Arena(5, 5), 1, 2, Direction.North);
            robot.Execute("L");
            Assert.Equal("1 2 W", robot.ToString());
        }

        [Fact]
        public void ExecuteTurnsTheRobotRight()
        {
            var robot = new Robot(new Arena(5, 5), 1, 2, Direction.South);
            robot.Execute("R");
            Assert.Equal("1 2 W", robot.ToString());
        }

        [Fact]
        public void ExecuteMovesTheRobot()
        {
            var robot = new Robot(new Arena(5, 5), 1, 2, Direction.North);
            robot.Execute("M");
            Assert.Equal("1 3 N", robot.ToString());
        }

        [Fact]
        public void ExecuteThrowsAnExceptionWhenTheRobotWillHitTheArenaBounds() 
            => Assert.Throws<Exception>(() =>
            {
                try
                {
                    var robot = new Robot(new Arena(2, 2), 1, 1, Direction.South);
                    robot.Execute("MM");
                }
                catch (Exception exp)
                {
                    Assert.Equal("Unable to move - Already at the bounds of the arena", exp.Message);
                    throw;
                }
            });

        [Fact]
        public void ExecuteResultsInTheExpectedOutputWhenTheRobotStaysWithinTheArena()
        {
            var robot = new Robot(new Arena(5, 5), 1, 2, Direction.North);
            robot.Execute("LMLMLMLMM");
            Assert.Equal("1 3 N", robot.ToString());

            robot = new Robot(new Arena(5, 5), 3, 3, Direction.East);
            robot.Execute("MMRMMRMRRM");
            Assert.Equal("5 1 E", robot.ToString());
        }

        [Fact]
        public void ExecuteResultsInAnExceptionWhenRobotMovesOutsideOfTheArena() 
            => Assert.Throws<Exception>(() =>
            {
                try
                {
                    var robot = new Robot(new Arena(5, 5), 1, 2, Direction.North);
                    robot.Execute("MMMM");
                }
                catch(Exception exp)
                {
                    Assert.Equal("Unable to move - Already at the bounds of the arena", exp.Message);
                    throw;
                }
            });
    }
}
