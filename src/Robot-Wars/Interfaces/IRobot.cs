using RobotWars.Runner.Models;

namespace RobotWars.Runner.Interfaces
{
    public interface IRobot
    {
        int X { get; }

        int Y { get; }

        Direction Direction { get; }

        void Execute(string commands);
    }
}
