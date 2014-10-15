using Xunit;

namespace GameOfLife.Test
{
    public class WhenGameStarts
    {
        [Fact]
        public void CellsCanBeBroughtToLife()
        {
            var game = new Game(3);

            game.BringCellToLifeAt(0, 0);
            game.BringCellToLifeAt(0, 1);
            game.BringCellToLifeAt(1, 1);

            Assert.True(game.Life[0, 0].IsAlive);
            Assert.True(game.Life[0, 1].IsAlive);
            Assert.True(game.Life[1, 1].IsAlive);
        }
    }

    public class WhenGameTicks
    {
        [Fact]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies()
        {
            var game = new Game(3);

            game.BringCellToLifeAt(0, 1);
            game.BringCellToLifeAt(0, 2);
            game.BringCellToLifeAt(1, 0);
            game.BringCellToLifeAt(1, 1);
            game.BringCellToLifeAt(1, 2);

            game.Tick();

            Assert.False(game.NextLife[1, 1].IsAlive);
        }

        [Fact]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies()
        {
            var game = new Game(3);
            game.Tick();

            Assert.False(game.NextLife[2, 0].IsAlive);
        }

        [Fact]
        public void AnyLiveCellWithTwoOrThreeThreeLiveNeighboursLivesOn()
        {
            var game = new Game(3);
            game.BringCellToLifeAt(0, 0);
            game.BringCellToLifeAt(0, 1);
            game.BringCellToLifeAt(1, 1);

            game.Tick();

            Assert.True(game.NextLife[0, 0].IsAlive);
            Assert.True(game.NextLife[0, 1].IsAlive);
            Assert.True(game.NextLife[1, 1].IsAlive);
        }

        [Fact]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesAlive()
        {
            var game = new Game(3);
            game.BringCellToLifeAt(0, 0);
            game.BringCellToLifeAt(0, 1);
            game.BringCellToLifeAt(1, 1);

            game.Tick();
            Assert.True(game.NextLife[1, 0].IsAlive);
        }
    }
}