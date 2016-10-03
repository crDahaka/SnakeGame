namespace SnakeGame
{
    using System;
    using System.Drawing;

    public class Food
    {
        public Point Point;
        Random rnd = new Random();

        public Food()
        {
            Point = new Point(rnd.Next(2, Console.WindowHeight - 2), rnd.Next(2, Console.WindowWidth - 2));
        }

        public void Draw()
        {
            Console.SetCursorPosition(Point.Y, Point.X);
            Console.Write('*');
        }
    }
}
