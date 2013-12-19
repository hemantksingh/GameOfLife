namespace GameOfLife
{
    public class CellFactory : ICellFactory
    {
        public Cell CreateAliveCell(int x, int y)
        {
            return new AliveCell(x, y);
        }

        public Cell CreateDeadCell(int x, int y)
        {
            return new DeadCell(x, y);
        }

    }
}
