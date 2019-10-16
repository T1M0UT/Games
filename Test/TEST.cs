using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class TEST
    {
        static Random random = new Random();
        static int width=90, height=10,frequency;
        static char wall = '#', space = ' ';
        static char[,] A = new char[height, width];

        static void Main()
        {
            Init();
        }
        static void Init()
        {
            Console.WriteLine("Frequency=");
            frequency = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    A[i, j] = Generate();
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(A[i, j]);
                }
                Console.WriteLine();
            }
        }
        static char Generate()
        {
            int num = random.Next(0, 100);
            char symb = (num < frequency ? wall : space);
            return symb;
        }

    }
}
