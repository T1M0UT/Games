using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeOnBacktracking
{
    class MazeBacktracking
    {
        static void Main(string[] args)
        {
            int width = 12, height = 12;
            char[,] arr = new char[width, height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    arr[i, j] = '#';
                }
            }
            for (int j = 2; j < height; j += 3)
            {
                for (int i = 0; i < width; i ++)
                {
                    arr[i, j] = '@';
                }
            }
            for (int j = 0; j < height; j++)
            {
                for (int i = 2; i < width; i+=3)
                {
                    arr[i, j] = '@';
                }
            }
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
