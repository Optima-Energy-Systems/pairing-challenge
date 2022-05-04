namespace RobotWars.Runner.Interfaces
{
    public interface IArena
    {
        int Height { get; }

        int Width { get; }

        IEnumerable<IRobot> Participants { get; }

        bool PositionWithinArena(int x, int y);

        void AddParticipant(IRobot robot);
    }
}
