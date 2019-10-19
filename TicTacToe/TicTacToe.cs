
using System;

namespace TicTacToe
{
    class TicTacToe
    {
        static char player1 = 'X', player2 = 'O', space = '#';
        static char[,] Field = new char[3, 3];
        static int playersAmount = 2, playerX, playerY, StepCounter=playersAmount,height=3,width=3;
        static string coord1, coord2;
        static bool successX, successY,BreakFlag=false,WinFlag=false;
        static void Main()
        {
            Init();
            while (!WinFlag||!BreakFlag)
            {
                Draw();
                Input();
                Logic();
            }
            Result();
        }

        static void Init()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Field[i, j] = space;
                }
            }
        }
        static void Draw()
        {
            //Console.Clear();
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
                Console.WriteLine($"{WhoseTurn()}, coord1");
                coord1 = Console.ReadLine();
                successX = int.TryParse(coord1, out playerX);
            if (successX){}
            else
            {
                Input();
                return;
            }
            Console.WriteLine($"{WhoseTurn()}, coord2");
            coord2 = Console.ReadLine();
            successY = int.TryParse(coord2, out playerY);
            if (successY){}
            else
            {
                Input();
                return;
            }
        }
        static void Logic()
        {
            TryPlace();
            if (IsCombination())
            {
                 Draw();
                 return;
            }
            StepCounter++;
            if (StepCounter == playersAmount + 10) BreakFlag = true;
        }
        static void TryPlace()
        {
            if (IsPlaceable())
            {
                Place();
            }
            else
            {
                Input();
                TryPlace();
                return;
            }
        }
        static bool IsPlaceable()
        {
            if ((playerX <= 2) && (playerY <= 2) && (playerX >= 0) && (playerY >= 0))
            {
                if (Field[playerX, playerY] == space)
                    return true;
            }
            return false;
        }
        static void Place()
        {
            Field[playerX, playerY] = WhoseTurn();
        }
        static bool IsCombination()
        {
            if ((Field[0, 0] != space) && (Field[0, 1] != space) && (Field[0, 2] != space)) return CheckWin(0,0,0,1,0,2);
            if ((Field[0, 0] != space) && (Field[1, 0] != space) && (Field[2, 0] != space)) return CheckWin(0,0,1,0,2,0);
            if ((Field[1, 0] != space) && (Field[1, 1] != space) && (Field[1, 2] != space)) return CheckWin(1,0,1,1,1,2);
            if ((Field[2, 0] != space) && (Field[2, 1] != space) && (Field[2, 2] != space)) return CheckWin(2,0,2,1,2,2);
            if ((Field[0, 1] != space) && (Field[1, 1] != space) && (Field[2, 1] != space)) return CheckWin(0,1,1,1,2,1);
            if ((Field[0, 2] != space) && (Field[1, 2] != space) && (Field[2, 2] != space)) return CheckWin(0,2,1,2,2,2);
            if ((Field[0, 0] != space) && (Field[1, 1] != space) && (Field[2, 2] != space)) return CheckWin(0,0,1,1,2,2);
            if ((Field[0, 2] != space) && (Field[1, 1] != space) && (Field[2, 0] != space)) return CheckWin(0,2,1,1,2,0);
            else return false;
        }
        static bool CheckWin(int c1, int c2, int c3, int c4, int c5, int c6)
        {
            if (Field[c1, c2] == WhoseTurn() && Field[c3, c4] == WhoseTurn() && Field[c5, c6] == WhoseTurn())
            {
                WinFlag = true;
                return true;
            }
            return false;
        }
        static char WhoseTurn()
        {
            switch (StepCounter % playersAmount)
            {
                case 0:
                    return player1;
                case 1:
                    return player2;
                default:
                    return '!';
            }
        }
        static void Result()
        {
            if (WinFlag) Console.WriteLine($"{WhoseTurn()},Wins!");
            else Console.WriteLine("DRAW.");
        }
    }
}
