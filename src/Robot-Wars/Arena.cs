using RobotWars.Runner.Interfaces;

namespace RobotWars.Runner
{
    public class Arena : IArena
    {
        private readonly int height,
            width;

        private readonly List<IRobot> robots;

        public Arena(int height, int width)
        {
            this.height = height;
            this.width = width;
            robots = new List<IRobot>();
        }

        public int Height => height;

        public int Width => width;

        public IEnumerable<IRobot> Participants => robots;

        public void AddParticipant(IRobot robot)
            => robots.Add(robot);

        public bool PositionWithinArena(int x, int y)
        {
            if (x < 0)
                return false;

            if (x > height)
                return false;

            if (y < 0)
                return false;

            if (y > width)
                return false;

            return true;
        }
    }
}
