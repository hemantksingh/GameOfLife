using Xunit;

namespace GameOfLife.Test
{
    public class WhenGameStarts
    {
        [Fact]
        public void CellsCanBeSwitchedOn()
        {
            var game = new Game(3, new CellFactory());

            game.SwitchOn(0, 0);
            game.SwitchOn(0, 1);
            game.SwitchOn(1, 1);

            Assert.Equal(3, game.NoOfLiveCells());
        }
    }

    public class WhenGameTicks
    {
        [Fact]
        public void AnyLiveCellWithMoreThanThreeLiveNeighboursDies()
        {
            var game = new Game(3, new CellFactory());
            
            game.SwitchOn(0, 1);
            game.SwitchOn(0, 2);
            game.SwitchOn(1, 0);
            game.SwitchOn(1, 1);
            game.SwitchOn(1, 2);

            game.Tick();

            Assert.False(game.NextLife[1, 1].IsAlive());
        }

        [Fact]
        public void AnyLiveCellWithFewerThanTwoLiveNeighboursDies()
        {
            var game = new Game(3, new CellFactory());
            game.Tick();

            Assert.False(game.NextLife[2, 0].IsAlive());
        }

        [Fact]
        public void AnyLiveCellWithTwoOrThreeThreeLiveNeighboursLivesOn()
        {
            var game = new Game(3, new CellFactory());
            game.SwitchOn(0, 0);
            game.SwitchOn(0, 1);
            game.SwitchOn(1, 1);

            game.Tick();

            Assert.True(game.NextLife[0, 0].IsAlive());
            Assert.True(game.NextLife[0, 1].IsAlive());
            Assert.True(game.NextLife[1, 1].IsAlive());
        }

        [Fact]
        public void AnyDeadCellWithExactlyThreeLiveNeighboursBecomesAlive()
        {
            var game = new Game(3, new CellFactory());
            game.SwitchOn(0, 0);
            game.SwitchOn(0, 1);
            game.SwitchOn(1, 1);

            game.Tick();
            Assert.True(game.NextLife[1, 0].IsAlive());
        }
    }
}
