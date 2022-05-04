using RobotWars.Runner.Interfaces;
using RobotWars.Runner.Models;

namespace RobotWars.Runner
{
    public class Robot : IRobot
    {
        private readonly IArena arena;
        public Direction Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Robot(IArena arena, int x, int y, Direction direction)
        {
            this.arena = arena;
            X = x;
            Y = y;
            direction = direction;
            this.arena.AddParticipant(this);
        }


        public void Execute(string commands)
        {
            foreach ((var command, var item) in Parse(commands))
            {
                switch (command)
                {
                    case CommandType.Turn:
                        Turn(item);
                        break;
                    case CommandType.Move:
                        Move();
                        break;
                }
            }
        }

        public override string ToString() 
            => $"{X} {Y} {Helpers.DirectionToString(Direction)}";

        private static IEnumerable<(CommandType, char)> Parse(string value)
        {
            foreach (var item in value.ToCharArray())
            {
                if (item == 'L' || item == 'R')
                {
                    yield return (CommandType.Turn, item);
                    continue;
                }

                if (item == 'M')
                    yield return (CommandType.Move, item);
            }
        }

        private void Move()
        {
            var xValue = -1;
            var yValue = -1;
            switch (Direction)
            {
                case Direction.South:
                    yValue = Y - 1;
                    xValue = X;
                    break;
                case Direction.East:
                    xValue = X + 1;
                    yValue = Y;
                    break;
                case Direction.West:
                    xValue = X - 1;
                    yValue = Y;
                    break;
                case Direction.North:
                    xValue = X;
                    yValue = Y + 1;
                    break;
            }

            if (!arena.PositionWithinArena(xValue, yValue))
                new Exception("Unable to move - Already at the bounds of the arena");

            X = xValue;
            Y = yValue;
        }

        private void Turn(char directionToTurn)
        {
            if (directionToTurn == 'R')
            {
                if (Direction == Direction.West)
                {
                    Direction = Direction.North;
                    return;
                }

                Direction = (Direction)(int)Direction + 1;
                return;
            }

            if (directionToTurn == 'L')
            {
                if (Direction == Direction.North)
                {
                    Direction = Direction.West;
                    return;
                }

                Direction = (Direction)(int)Direction - 1;
                return;
            }

            throw new ArgumentException($"Parameter {directionToTurn} is invalid - Expected values 'R' or 'L'", nameof(directionToTurn));
        }
    }
}
