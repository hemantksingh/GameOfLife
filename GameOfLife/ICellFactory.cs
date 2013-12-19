namespace GameOfLife
{
    public interface ICellFactory
    {
        Cell CreateAliveCell(int x, int y);
        Cell CreateDeadCell(int x, int y);
    }
}