namespace GameOfLife
{
    class DeadCell : Cell
    {
        public DeadCell(int x, int y) : base(x, y)
        {}

        public override bool IsAlive()
        {
            return false;
        }
    }
}