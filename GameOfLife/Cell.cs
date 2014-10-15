using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public Cell(int x, int y, bool isAlive)
        {
            this.x = x;
            this.y = y;
            this.IsAlive = isAlive;
        }

        private readonly int x;
        private readonly int y;
        public readonly bool IsAlive;


        /// <summary>
        /// TODO: This can be optimised. Rather than navigating through all the cells in life,
        /// there must be a clever way of narrowing down the number of cells to navigate.
        /// </summary>
        internal int NoOfLiveNeighbours(Cell[,] life)
        {
            int noOfLiveNeighbours = 0;
            foreach (Cell cell in life)
            {
                if (cell.IsAlive && this.IsANeighbourOf(cell))
                    noOfLiveNeighbours++;
            }
            return noOfLiveNeighbours;
        }

        private bool IsANeighbourOf(Cell cell)
        {
            if (this.IsSameAs(cell)) return false;

            Cell distance = this.DistanceFrom(cell);
            return (distance.x == 0 || distance.x == -1 || distance.x == 1)
                        && (distance.y == 0 || distance.y == -1 || distance.y == 1);
        }


        private Cell DistanceFrom(Cell cell)
        {
            return new Cell(this.x - cell.x, this.y - cell.y, cell.IsAlive);
        }

        private bool IsSameAs(Cell cell)
        {
            return this.x == cell.x && this.y == cell.y;
        }

        public Cell Evolve(int noOfLiveNeighbours)
        {
            Cell nextCell;
            if (this.IsAlive)
            {
                if (noOfLiveNeighbours < 2 || noOfLiveNeighbours > 3)
                    nextCell = CreateDeadCell();
                else
                    nextCell = CreateLiveCell();
            }
            else
            {
                if (noOfLiveNeighbours == 3)
                    nextCell = CreateLiveCell();
                else
                    nextCell = CreateDeadCell();
            }

            return nextCell;
        }

        private Cell CreateLiveCell()
        {
            return new Cell(x, y, true);
        }

        private Cell CreateDeadCell()
        {
            return new Cell(x, y, false);
        }
    }
}