using System.Text;

namespace GameOfLife
{
    public class Game
    {
        public Game(int size)
        {
            Size = size;            
            Life = new Cell[Size,Size];
            CreateLife();
        }

        public Cell[,] NextLife { get; private set; }
        public int Size { get; private set; }
        public Cell[,] Life { get; private set; }

        private void CreateLife()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Cell @newCell = new Cell(x, y, false);
                    Life[x, y] = @newCell;
                }
            }
        }

        public void Tick()
        {
            NextLife = new Cell[Size, Size];

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Cell cell = Life[x, y];
                    int noOfLiveNeighbours = cell.NoOfLiveNeighbours(Life);
                    NextLife[x, y] = cell.Evolve(noOfLiveNeighbours);
                }
            }
            Life = NextLife;
        }

        public void BringCellToLifeAt(int x, int y)
        {
            Cell aliveCell = new Cell(x, y, true);
            Life[x, y] = aliveCell;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    builder.Append(Life[x, y].IsAlive() ? "*" : " ");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}