namespace SnakeGame
{
    using System;
    using System.Drawing;
    using System.Linq;

    public class GameEngine
    {
        public double MS, LineHeightRatio;
        public int Points;
        public Snake Snake;
        public Food Food;
        public Stone Stones;

        public GameEngine()
        {
            Snake = new Snake(3);
            Food = new Food();
            Stones = new Stone(Food.Point);
            Snake.Dir = Direction.Right;
            MS = 6.0;
            LineHeightRatio = 1.6;
            Points = 0;
        }

        private void RenderArena()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Food.Draw();

            Console.ForegroundColor = ConsoleColor.Green;
            Snake.Draw();

            Console.ForegroundColor = ConsoleColor.Red;
            Stones.Draw();
        }

        public void MakeMove()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {

                    Snake.Dir = Direction.Left;
                    MS = 6.0;

                }
                else if (userInput.Key == ConsoleKey.RightArrow)
                {

                    Snake.Dir = Direction.Right;
                    MS = 6.0;

                }
                else if (userInput.Key == ConsoleKey.UpArrow)
                {

                    Snake.Dir = Direction.Up;
                    MS = 6.0 * LineHeightRatio;

                }
                else if (userInput.Key == ConsoleKey.DownArrow)
                {

                    Snake.Dir = Direction.Down;
                    MS = 6.0 * LineHeightRatio;

                }
            }
        }

        public void GameOver(string message)
        {
            Console.Clear();

            Console.WriteLine("Game Over!");
            Console.WriteLine(message);
            Console.WriteLine("\nPoints: " + Points);
            Console.WriteLine("\nTap 'R' to restart...");

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.KeyChar != 'R' && key.KeyChar != 'r')
            {
                key = Console.ReadKey(true);
            }
            GameEngine eng = new GameEngine();
            eng.Run();
        }

        public void Run()
        {
            while (true)
            {
                MakeMove();

                if (Snake.Dir == Direction.Left)
                {
                    for (int i = 0; i < Snake.Body.Count; i++)
                    {
                        if (Snake.Body[i].X == Snake.Head.X && Snake.Body[i].Y == Snake.Head.Y - 1)
                        {
                            GameOver("Collision with body!");
                        }
                    }
                    Snake.Head.Y--;
                }
                else if (Snake.Dir == Direction.Right)
                {
                    for (int i = 0; i < Snake.Body.Count; i++)
                    {
                        if (Snake.Body[i].X == Snake.Head.X - 1 && Snake.Body[i].Y == Snake.Head.Y + 1)
                        {
                            GameOver("Collision with body!!");
                        }
                    }
                    Snake.Head.Y++;
                }
                else if (Snake.Dir == Direction.Up)
                {
                    for (int i = 0; i < Snake.Body.Count; i++)
                    {
                        if (Snake.Body[i].X == Snake.Head.X - 1 && Snake.Body[i].Y == Snake.Head.Y)
                        {
                            GameOver("Collision with body!!");
                        }
                    }
                    Snake.Head.X--;
                }

                else if (Snake.Dir == Direction.Down)
                {
                    for (int i = 0; i < Snake.Body.Count; i++)
                    {
                        if (Snake.Body[i].X == Snake.Head.X + 1 && Snake.Body[i].Y == Snake.Head.Y)
                        {
                            GameOver("Collision with body!!");
                        }
                    }
                    Snake.Head.X++;
                }

                Snake.Update();

                foreach (Point p in Snake.Body.ToList())
                {
                    if (p.X == Food.Point.X && p.Y == Food.Point.Y)
                    {
                        Points++;
                        Food = new Food();
                        Snake.Grow();
                    }
                }

                if (Snake.Head.X < 0 || Snake.Head.Y < 0 || Snake.Head.X == Console.WindowHeight ||
                     Snake.Head.Y == Console.WindowWidth)
                {
                    GameOver("Crashed a wall.");
                }

                foreach (Point Stone in Stones.List)
                {
                    if (Stone.X == Snake.Head.X && Stone.Y == Snake.Head.Y)
                    {
                        GameOver("Crashed a rock");
                    }
                }

                RenderArena();

                System.Threading.Thread.Sleep((int)MS * 10);
            }
        }

    }
}