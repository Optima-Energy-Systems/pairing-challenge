using RobotWars.Runner.Models;
using Xunit;

namespace RobotWars.Runner.Tests
{
    public class HelperTests
    {
        [Theory]
        [InlineData("N", true, Direction.North)]
        [InlineData("n", true, Direction.North)]
        [InlineData("S", true, Direction.South)]
        [InlineData("s", true, Direction.South)]
        [InlineData("E", true, Direction.East)]
        [InlineData("e", true, Direction.East)]
        [InlineData("W", true, Direction.West)]
        [InlineData("w", true, Direction.West)]
        [InlineData("invalid", false, Direction.North)]
        public void ParseDirectionReturnsTheExpectedDirection(string value, bool expectedResult, Direction expectedDirection)
        {
            var result = Helpers.ParseDirection(value, out var direction);
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedDirection, direction);
        }

        [Theory]
        [InlineData(Direction.North, "N")]
        [InlineData(Direction.South, "S")]
        [InlineData(Direction.East, "E")]
        [InlineData(Direction.West, "W")]
        public void DirectionToStringReturnsTheExpectedValue(Direction value, string expectedValue) 
            => Assert.Equal(expectedValue, Helpers.DirectionToString(value));
    }
}
