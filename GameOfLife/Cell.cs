using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public Cell(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            alive = isAlive;
        }

        public readonly int X;
        public readonly int Y;
        private readonly bool alive;

        public bool IsAlive()
        {
            return alive;
        }

        /// <summary>
        /// TODO: This can be optimised. Rather than navigating through all the cells in life,
        /// there must be a clever way of narrowing down the number of cells to navigate.
        /// </summary>
        public int NoOfLiveNeighbours(Cell[,] life)
        {
            var liveNeighbours = 0;

            foreach (Cell cell in life)
            {
                if (cell.IsAlive() && !cell.IsSameAs(this))
                {
                    int xDistanceFromCell = X - cell.X;
                    int yDistanceFromCell = Y - cell.Y;

                    if ((xDistanceFromCell == 1 || xDistanceFromCell == 0 || xDistanceFromCell == -1) &&
                        (yDistanceFromCell == 1 || yDistanceFromCell == 0 || yDistanceFromCell == -1))
                        liveNeighbours++;
                }
            }
            return liveNeighbours;
        }

        private bool IsSameAs(Cell cell)
        {
            return cell.X == this.X && cell.Y == this.Y;
        }

        public Cell Evolve(int noOfLiveNeighbours)
        {
            Cell nextCell;
            if (this.IsAlive())
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
            return new Cell(X, Y, true);
        }

        private Cell CreateDeadCell()
        {
            return new Cell(X, Y, false);
        }
    }
}