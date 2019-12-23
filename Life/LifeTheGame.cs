using System;
using System.Threading.Tasks;
using MyUtils;
namespace Life
{
    class LifeTheGame
    {
        static int width=5;
        static int height=5;
        static bool[,] Field;
        static void Main(string[] args)
        {
            Input(out Field);
            while (!IsEndGame())
            {
                Draw();
                Logic();
            }
        }
        static void Input(out bool[,] tmp)
        {
            width = 18;
            height = 12;
            tmp=new bool[width,height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    bool b=Rnd.RandIntAB(0, 5)==1;
                    tmp[i, j] = b;
                }
            }
            //tmp[5, 5] = true;
            //tmp[6, 6] = true;
            //tmp[6, 5] = true;
            //tmp[7, 5] = true;
        }
        static void Draw()
        {
            Console.Clear();
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (Field[i,j]==true) Console.BackgroundColor = ConsoleColor.DarkGreen;
                    else Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            System.Threading.Thread.Sleep(400);
            Console.ResetColor();
        }
        static bool IsEndGame() => false;
        static void Logic()
        {
            int[,] ActiveCells=new int[width,height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    ActiveCells[i,j] = NeighboorsActive(i, j);
                }
            }
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    State(i,j,ActiveCells[i,j]);
                }
            }
        }
        static void State(int x,int y,int CellsActive)
        {
            if (CellsActive == 3 || (CellsActive == 2 && Field[x, y])) Field[x, y] = true;
            else Field[x, y] = false;
        }
        static int NeighboorsActive(int x,int y)
        {
            int CellsBehindAlive = 0;
            for (int j = y-1; j <= y+1; j++)
            {
                for (int i = x-1; i <= x+1; i++)
                {
                    if (j == y && i == x) { }
                    else
                    {
                        int x_copy = i;
                        int y_copy = j;
                        if (i == -1) x_copy = width - 1;
                        if (j == -1) y_copy = height - 1;
                        if (i == width) x_copy = 0;
                        if (j == height) y_copy = 0;
                        if (Field[x_copy, y_copy]) CellsBehindAlive++;
                    }
                }
            }
            return CellsBehindAlive;
        }
    }
}
