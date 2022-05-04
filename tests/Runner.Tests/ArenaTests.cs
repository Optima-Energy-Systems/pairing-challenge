using System;
using Xunit;

namespace RobotWars.Runner.Tests
{
    public class ArenaTests
    {
        [Fact]
        public void ConstructorSetsTheHeightAndWidth()
        {
            var arena = new Arena(5, 5);
            Assert.Equal(5, arena.Height);
            Assert.Equal(5, arena.Width);
        }

        [Fact]
        public void PositionWithinArenaReturnsTrueWhenPositionIsWithinTheArena()
        {
            Assert.True(new Arena(5, 5).PositionWithinArena(0, 0));
            Assert.True(new Arena(5, 5).PositionWithinArena(1, 0));
            Assert.True(new Arena(5, 5).PositionWithinArena(1, 1));
            Assert.True(new Arena(5, 5).PositionWithinArena(3, 4));
            Assert.True(new Arena(5, 5).PositionWithinArena(0, 5));
            Assert.True(new Arena(5, 5).PositionWithinArena(5, 5));            
        }

        [Fact]
        public void PositionWithinArenaReturnsFalseWhenPositionIsOutsideTheArena()
        {
            Assert.False(new Arena(5, 5).PositionWithinArena(6, 6));
            Assert.False(new Arena(5, 5).PositionWithinArena(-1, 0));
            Assert.False(new Arena(5, 5).PositionWithinArena(6, 0));
            Assert.False(new Arena(5, 5).PositionWithinArena(-1, -1));
            Assert.False(new Arena(5, 5).PositionWithinArena(5, 10));
            Assert.False(new Arena(5, 5).PositionWithinArena(-5, -10));
        }
    }
}
