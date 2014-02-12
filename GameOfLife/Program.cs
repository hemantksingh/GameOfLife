using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of ticks:");
            string readLine = Console.ReadLine();
            int noOfTicks;
            if (!int.TryParse(readLine, out noOfTicks))
            {
                Console.WriteLine("'{0}' is an invalid number.", readLine);
                Console.Read();
                return;
            }
            
            var game = new Game(60, new CellFactory());
            foreach (Point point in GetSeed())
            {
                game.BringCellToLifeAt(point.X, point.Y);
            }

            for (int i = 0; i < noOfTicks; i++)
            {
                Console.Clear();
                game.Tick();
                Console.WriteLine(game.ToString());
                Thread.Sleep(300);
            }
            
            Console.ReadKey();
        }

        private static IEnumerable<Point> GetSeed()
        {
            var seed = new List<Point>
                {
                    new Point(1, 32),
                    new Point(2, 32),
                    new Point(3, 32),
                    new Point(3, 33),
                    new Point(2, 34),
                    new Point(27, 43),
                    new Point(27, 44),
                    new Point(27, 45)
                };

            for (int j = 34; j < 44; j++)
            {
                seed.Add(new Point(j, 45));
            }

            return seed;
        }
    }
}
