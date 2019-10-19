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
        static int width=3, height=3,deep=3,frequency;
        static char wall = '#', space = ' ';
        static char[,,] A = new char[height, width,deep];

        static void Main()
        {
            Init();
        }
        static void Init()
        {
            Console.WriteLine("Frequency=");
            frequency = Convert.ToInt32(Console.ReadLine());
            for (int k = 0; k < deep; k++)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        A[i, j, k] = Generate();
                    }
                }
            }
            for (int k = 0; k < deep; k++)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (k == 2 && i == 2 && j == 2)
                        {
                            A[i, j, k] = '@';
                        }
                        Console.Write(A[i, j, k]);
                    }
                    Console.WriteLine();
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
