using System;
namespace Maze
{
  class Maze
  {
    static Random random = new Random();
    static char player = '@', wall = '#', finish = 'F', space = ' ', wallTop='^', wallBottom='v',wallBoth='I';
    static int width=21, height=11, deep = 4,
    // Change values up here ↑
    frequency, dx = 0, dy = 0, dz = 0, newX, newY, newZ,
    FX = random.Next(1,width),
    FY = random.Next(1,height),
    FZ = random.Next(1, deep),
    charX = random.Next(1,width),
    charY = random.Next(1,height),
    charZ = random.Next(1,deep);
    static char[,,] Field = new char[deep,height,width];
    static char[,,] PlayArena = new char [deep,height,width];
    static bool Win=false;
    static void Main()
    {
        Init();
        while (!IsEndGame())
        {
            Draw();
            Input();
            Logic();
        }
        WhatHappened();
    }
    static void Init()
    {
      StartReader();
      MapGeneration();
      VisualMap();
    }
    static void MapGeneration()
    {   
        Console.Write("Walls percent (30-50 percent - optimally) = ");
        frequency = Convert.ToInt32(Console.ReadLine());
        for (int i=0; i < deep; i++)
        {
            for (int j = 1; j < height; j++)
            {
                for (int k = 1; k < width; k++)
                {
                    Field[i,j,k] = Generate();
                    PlayArena[i,j,k]=Field[i,j,k];
                }
            }
        }
        PlayArena[FZ,FY,FX] = Field[FZ,FY,FX] = finish;
        PlayArena[charZ, charY, charX] = Field[charZ, charY, charX] = player;
    }
    static char Generate()
    {
        int num = random.Next(0, 100);
        char symb = (num < frequency ? wall : space);
        return symb;
    }

    static void VisualMap()
    {
      for (int i = 0; i < deep; i++)
        {
            for (int j = 1; j < height; j++)
            {
                for (int k = 1; k < width; k++)
                {
                    PlayArena[i,j,k] = BuildMapPointers(i,j,k);
                }
            }
        }
    }
    static void StartReader()
    {
      Console.WriteLine("Type 'rules' to be aware of them. Or press 'enter' to start.");
      string input = Console.ReadLine();
      if (String.IsNullOrEmpty(input)){}
      else
      {
        Console.WriteLine($"1.This is the maze in which you play as '{player}' and you need to reach '{finish}'.");
        Console.WriteLine("2.There is a chance that there will be no passage.");
        Console.WriteLine("3.This maze is three-dimensional. Use WASD+RF to move.");
        Console.WriteLine($"4.There are some '{wall}' - walls.");
        Console.WriteLine($"5.There are several pointers like '{wallTop}', '{wallBottom}', '{wallBoth}' that show in which direction the '{wall}” is in the third dimension.");
        Console.WriteLine("Good luck! Press enter to start.");
        
        input = Console.ReadLine();
      }
    }
    static char BuildMapPointers(int Z,int Y,int X)
    {
      char wasInited = Field[Z,Y,X], willBeInited = wasInited;
      bool bottom = false, top = false;
      if (wasInited==finish) 
      {
        return finish; 
      }
      if(Field[Z,Y,X]!=wall)
      {    
        if (Z-1>0)
        {
          if (Field[Z-1,Y,X]==wall)
          {
            willBeInited = wallBottom;
            bottom = true;
          }        
        }
        if (Z+1<deep)
        {
          if (Field[Z+1,Y,X]==wall)
          {
            willBeInited = wallTop;
            top = true;
          }
        }
        if(bottom && top) willBeInited = wallBoth; 
      }
      return willBeInited;
    }
    static void Draw()
    {
    Console.Clear();
    for (int j = 0; j < height; j++)
    {
        for (int k = 0; k < width; k++)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if (j==charY && k == charX) Console.BackgroundColor = ConsoleColor.Red;
            if (PlayArena[charZ,j,k] == finish) Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(PlayArena[charZ, j, k]);
        }
        Console.WriteLine();
    }
    Console.ResetColor();
    }
    static void Input()
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.W:
                dy = -1;
                break;
            case ConsoleKey.S:
                dy = 1;
                break;
            case ConsoleKey.A:
                dx = -1;
                break;
            case ConsoleKey.D:
                dx = 1;
                break;
            case ConsoleKey.R:
                dz = 1;
                break;
            case ConsoleKey.F:
                dz = -1;
                break;    
        }
    }
    static void Logic()
    {
        TryMove();
        IsEndGame();
    }
    static void TryMove()
    {
        newX = charX + dx;
        newY = charY + dy;
        newZ = charZ + dz;
        if (IsWalkable())
        {
            Goto();
        }
        dx = 0;
        dy = 0;
        dz = 0;
    }
    static bool IsWalkable()
    {
        if ((newX < width) && (newY < height)&&(newX > 0) && (newY > 0) && (newZ > 0)&&(newZ < deep))
        {
            if (Field[newZ, newY, newX] != wall)
                return true;
        }
        return false;
    }
    static void Goto()
    {
        Field[charZ,charY,charX] = space;
        PlayArena[charZ, charY, charX] = BuildMapPointers(charZ,charY,charX);
        charX = newX;
        charY = newY;
        charZ = newZ;
        PlayArena[newZ, newY, newX] = Field[newZ, newY, newX] = player;
    }
    static bool IsEndGame()
    {
        if (Field[charZ, charY, charX] == Field[FZ, FY, FX]) 
        {
          Win = true;
          return true;
        }
        return false;
    }
    static void WhatHappened()
    {
      if (Win)
      {
        Console.WriteLine("Congratulations, you won!");
      }
      else Console.WriteLine("Something went wrong..");
    }
  }
}
