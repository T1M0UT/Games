using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne
{
    class GameOne
    {
        static Random random = new Random();
        static char player = '@', wall = '#', finish = 'F', space = ' ';
        static int width=21, height=11, frequency, dx = 0, dy = 0, newX, newY;
        static int FX = random.Next(0,height);
        static int FY = random.Next(0,width);
        static int charX = random.Next(0,height);
        static int charY = random.Next(0,width);
        static char[,] Field = new char[height, width];

        static void Main()
        {
            Init();
            while (!CheckEndGame())
            {
                Draw();
                Input();
                Logic();
            }
            Console.WriteLine("WIN!");
        }

        static void Init()
        {
            Console.WriteLine("Frequency=");
            frequency = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    Field[i, j] = Generate();
                }
            }
            Field[FX, FY] = finish;
            Field[charX, charY] = player;
        }
        static char Generate()
        {
            int num = random.Next(0, 100);
            char symb = (num < frequency ? wall : space);
            return symb;
        }
        static void Draw()
        {
            Console.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(Field[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Input()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    dy = -1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    dy = 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    dx = -1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    dx = 1;
                    break;
            }
        }
        static void Logic()
        {
            TryMove();
            CheckEndGame();
        }
        static void TryMove()
        {
            newX = charX + dy;
            newY = charY + dx;
            if (IsWalkable())
            {
                Goto();
            }
            dx = 0;
            dy = 0;
        }
        static bool IsWalkable()
        {
            if ((newX < height) && (newY < width)&&(newX > 0) && (newY > 0))
            {
                if (Field[newX, newY] != wall)
                    return true;
            }
            return false;
        }
        static void Goto()
        {
            Field[charX, charY] = space;
            charX = newX;
            charY = newY;
            Field[newX, newY] = player;
        }
        static bool CheckEndGame()
        {
            if (Field[charX, charY] == Field[FX, FY]) return true;
            return false;
        }
       
    }
}