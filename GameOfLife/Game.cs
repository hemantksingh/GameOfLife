using System.Text;

namespace GameOfLife
{
    public class Game
    {
        private readonly ICellFactory _cellFactory;

        public Game(int size, ICellFactory cellFactory)
        {
            Size = size;
            _cellFactory = cellFactory;
            
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
                    Cell @newCell = _cellFactory.CreateDeadCell(x, y);
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
            Cell aliveCell = _cellFactory.CreateAliveCell(x, y);
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