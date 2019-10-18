
using System;

namespace TicTacToe
{
    class TicTacToe
    {
        static char player1 = 'X', player2 = 'O', space = '#';
        static char[,] Field = new char[3, 3];
        static int player1X, player1Y, player2X, player2Y;
        static string coord1,coord2;
        static bool successX,successY;
        static void Main()
        {
            Init();
            while (!IsEndGame())
            {
                Draw();
                Input();
                Logic();
            }
        }

        static void Init()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Field[i, j] = space;
                }
            }
        }
        static void Draw()
        {
            //Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Field[i, j]);
                }
                Console.WriteLine();
            }
        }
        static bool StepX = true;
        static void Input()
        {
            if (StepX)
            {
                Console.WriteLine($"{player1}, coord1");
                coord1 = Console.ReadLine();
                successX = int.TryParse(coord1, out player1X);
                if (successX);
                else
                {
                    Input();
                }
                
                
                Console.WriteLine($"{player1}, coord2");
                coord2 = Console.ReadLine();
                successY = int.TryParse(coord2, out player1Y);
                if (successY);
                else
                {
                    Input();
                }
            }
            else
            {
                Console.WriteLine($"{player2}, coord1");
                coord1 = Console.ReadLine();
                successX = int.TryParse(coord1, out player2X);
                if (successX);
                else
                {
                    Input();
                }


                Console.WriteLine($"{player2}, coord2");
                coord2 = Console.ReadLine();
                successY = int.TryParse(coord2, out player2Y);
                if (successY) ;
                else
                {
                    Input();
                }
            }
        }
        static void Logic()
        {
            TryPlace();
            IsEndGame();
        }
        static void TryPlace()
        {
            if (IsPlaceable())
            {
                Place();
            }
        }
        static bool IsPlaceable()
        {
            if ((player1X <= 2) && (player1Y <= 2) && (player2X >= 0) && (player2Y >= 0))
            {
                if (StepX)
                {
                    if (Field[player1X, player1Y] == space)
                        return true;
                }
                if (Field[player2X, player2Y] == space)
                    return true;

            }
            return false;
        }
        static void Place()
        {
            if (StepX)
            {
                Field[player1X, player1Y] = player1;
                StepX = !StepX;
            }
            else
            {
                Field[player2X, player2Y] = player2;
                StepX = !StepX;
            }
        }
        static bool IsEndGame()
        {
            if ((Field[0, 0] == player1) && (Field[0, 1] == player1) && (Field[0, 2] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[0, 0] == player1) && (Field[1, 0] == player1) && (Field[2, 0] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[1, 0] == player1) && (Field[1, 1] == player1) && (Field[1, 2] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[2, 0] == player1) && (Field[2, 1] == player1) && (Field[2, 2] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[0, 1] == player1) && (Field[1, 1] == player1) && (Field[2, 1] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[0, 2] == player1) && (Field[1, 2] == player1) && (Field[2, 2] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[0, 0] == player1) && (Field[1, 1] == player1) && (Field[2, 2] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }
            if ((Field[0, 2] == player1) && (Field[1, 1] == player1) && (Field[2, 0] == player1))
            {
                Console.WriteLine("'X' WINS!");
                return true;
            }

            if ((Field[0, 0] == player2) && (Field[0, 1] == player2) && (Field[0, 2] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[0, 0] == player2) && (Field[1, 0] == player2) && (Field[2, 0] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[1, 0] == player2) && (Field[1, 1] == player2) && (Field[1, 2] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[2, 0] == player2) && (Field[2, 1] == player2) && (Field[2, 2] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[0, 1] == player2) && (Field[1, 1] == player2) && (Field[2, 1] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[0, 2] == player2) && (Field[1, 2] == player2) && (Field[2, 2] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[0, 0] == player2) && (Field[1, 1] == player2) && (Field[2, 2] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            if ((Field[0, 2] == player2) && (Field[1, 1] == player2) && (Field[2, 0] == player2))
            {
                Console.WriteLine("'O' WINS!");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
