using System.Collections.Generic;

namespace GameOfLife
{
    public abstract class Cell
    {
        protected Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public abstract bool IsAlive();

        /// <summary>
        /// TODO: This can be optimised. Rather than navigating through all the cells in life,
        /// there must be a clever way of narrowing down the number of cells to navigate.
        /// </summary>
        public int NoOfLiveNeighbours(Cell[,] life)
        {
            var liveNeighbours = new List<Cell>();

            foreach (Cell cell in life)
            {
                if (cell.IsAlive() && !cell.IsSameAs(this))
                {
                    int xDistanceFromCell = X - cell.X;
                    int yDistanceFromCell = Y - cell.Y;

                    if ((xDistanceFromCell == 1 || xDistanceFromCell == 0 || xDistanceFromCell == -1) &&
                        (yDistanceFromCell == 1 || yDistanceFromCell == 0 || yDistanceFromCell == -1))
                        liveNeighbours.Add(cell);
                }
            }
            return liveNeighbours.Count;
        }

        private bool IsSameAs(Cell cell)
        {
            return cell.X == this.X && cell.Y == this.Y;
        }

        public Cell Evolve(int noOfLiveNeighbours)
        {
            if (this.IsAlive())
            {
                if (noOfLiveNeighbours < 2 || noOfLiveNeighbours > 3)
                    return new DeadCell(X, Y);
            }
            else if (noOfLiveNeighbours == 3)
                return new AliveCell(X, Y);
            else
                return new DeadCell(X, Y);
            
            return new AliveCell(X, Y);
        }
    }
}