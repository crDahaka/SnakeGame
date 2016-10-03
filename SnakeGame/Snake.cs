namespace SnakeGame
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Snake
    {
        public List<Point> Body;
        public Point Head;
        public char[] dirArrow = { '<', '>', '^', 'V' };
        public Direction Dir;

        public Snake(int firstCreation)
        {
            Body = new List<Point>();

            for (int i = 0; i < firstCreation; i++)
            {
                Body.Add(new Point(0, i));
            }
        }

        public void Update()
        {
            Body.RemoveAt(0);
            Body.Add(Head);
        }

        public void Draw()
        {
            for (int i = 0; i < Body.Count - 1; i++)
            {
                Console.SetCursorPosition(Body[i].Y, Body[i].X);
                Console.WriteLine("*");
            }

            Console.SetCursorPosition(Head.Y, Head.X);
            Console.Write(dirArrow[(int)Dir]);
        }

        public void Grow()
        {
            Body.Add(new Point(0, 0));
        }
    }
}
