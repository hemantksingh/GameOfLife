﻿using System.Collections.Generic;

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
            if (noOfLiveNeighbours < 2 || noOfLiveNeighbours > 3)
                return new Cell(X, Y, false);
            return new Cell(X, Y, true);
        }
    }
}