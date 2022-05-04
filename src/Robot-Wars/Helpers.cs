using RobotWars.Runner.Models;

namespace RobotWars.Runner
{
    public static class Helpers
    {
        public static bool ParseDirection(string value, out Direction direction)
        {
            switch (value)
            {
                case "N":
                case "n":
                    direction = Direction.North;
                    return true;
                case "S":
                case "s":
                    direction = Direction.South;
                    return true;
                case "E":
                case "e":
                    direction = Direction.East;
                    return true;
                case "W":
                case "w":
                    direction = Direction.West;
                    return true;
                default:
                    direction = Direction.North;
                    return false;
            }
        }

        public static string DirectionToString(Direction direction) 
            => direction switch
            {
                Direction.North => "N",
                Direction.South => "S",
                Direction.East => "E",
                Direction.West => "W",
                _ => string.Empty,
            };
    }
}
