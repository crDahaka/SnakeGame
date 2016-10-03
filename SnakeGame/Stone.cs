namespace SnakeGame
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Stone
    {
        public List<Point> List;
        public Point StoneObj;

        Random rnd = new Random();

        public Stone(Point Food)
        {
            List = new List<Point>();
            refreshRocks(Food);
        }

        public void refreshRocks(Point Food)
        {
            List.Clear();
            for (int i = 0; i < 5; i++)
            {
                StoneObj = new Point(rnd.Next(2, Console.WindowHeight - 2), rnd.Next(2, Console.WindowWidth - 2));
                while (StoneObj.X == Food.X && StoneObj.Y == Food.Y)
                    StoneObj = new Point(rnd.Next(2, Console.WindowHeight - 2), rnd.Next(2, Console.WindowWidth - 2));
                List.Add(StoneObj);
            }
        }

        public void Draw()
        {
            foreach (Point Stone in List)
            {
                Console.SetCursorPosition(Stone.Y, Stone.X);
                Console.WriteLine('=');
            }
        }
    }
}
