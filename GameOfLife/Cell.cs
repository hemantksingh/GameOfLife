namespace GameOfLife
{
    public class Cell
    {
        public readonly bool IsAlive;
        private readonly int _x;
        private readonly int _y;

        public Cell(int x, int y, bool isAlive)
        {
            _x = x;
            _y = y;
            IsAlive = isAlive;
        }

        private int NoOfLiveNeighbours(Cell[,] life)
        {
            int noOfLiveNeighbours = 0;
            foreach (Cell cell in life)
            {
                if (cell.IsAlive && IsANeighbourOf(cell))
                    noOfLiveNeighbours++;
            }
            return noOfLiveNeighbours;
        }

        private bool IsANeighbourOf(Cell cell)
        {
            if (IsSameAs(cell)) return false;

            Cell distance = DistanceFrom(cell);
            return (distance._x == 0 || distance._x == -1 || distance._x == 1)
                   && (distance._y == 0 || distance._y == -1 || distance._y == 1);
        }


        private Cell DistanceFrom(Cell cell)
        {
            return new Cell(_x - cell._x, _y - cell._y, cell.IsAlive);
        }

        private bool IsSameAs(Cell cell)
        {
            return _x == cell._x && _y == cell._y;
        }

        public Cell EvolveFrom(Cell[,] life)
        {
            Cell nextCell;
            int noOfLiveNeighbours = NoOfLiveNeighbours(life);
            if (IsAlive)
            {
                if (noOfLiveNeighbours < 2 || noOfLiveNeighbours > 3)
                    nextCell = CreateDeadCell();
                else
                    nextCell = CreateLiveCell();
            }
            else
            {
                nextCell = noOfLiveNeighbours == 3 ? CreateLiveCell() : CreateDeadCell();
            }

            return nextCell;
        }

        private Cell CreateLiveCell()
        {
            return new Cell(_x, _y, true);
        }

        private Cell CreateDeadCell()
        {
            return new Cell(_x, _y, false);
        }
    }
}