using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {

        static int width = 15;
        static int height = 10;
        static int blockFreq = 10;
        static int finishX = 0;
        static int finishY = 0;
        static int newX = 0;
        static int newY = 0;
        static int playerX = 0;
        static int playerY = 0;


        static void Main(string[] args)
        {

            char[,] field = CreateField(width, height, blockFreq);
            (playerX,playerY) = PlaceCharacter();
            while (!IsEndGame())
            {
                DrawField(field,width,height);            
                (int dx,int dy) = InputKey();
                (int newX, int newY) = MoveLogic(dx, dy);
                TryMove(field, newX,newY); 
            }
            Console.Clear();
            Console.ReadKey();
        }
        private static void DrawField(char[,] field, int width, int height)
        {
            Console.Clear();
            char cell;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (i == playerX && j == playerY)
                    {
                        cell = '@';
                    }
                    else if (i == finishX && j == finishY)
                    {
                        cell = 'F';
                    }
                    else
                    {
                        cell = field[i, j];
                    }
                    Console.Write(cell);
                }
                Console.WriteLine();
            }
        }
        private static char[,] CreateField(int width, int height, int blockFreq)
        {
            Random random = new Random();
            char cell;
            char[,] field = new char[width, height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; ++i)
                {
                    int value = random.Next(0, 100);
                    if (value < blockFreq)
                    {
                        cell = '#';
                    }
                    else
                    {
                        cell = ' ';
                    }
                    field[i, j] = cell;
                }
            }
            return field;
        }
        private static (int, int) PlaceCharacter()
        {
           Random rnd = new Random();
           int x = rnd.Next(0, width);
           int y = rnd.Next(0, height);
           return (y, x);
        }
        private static (int, int) InputKey()
        {
            int dx = 0;
            int dy = 0;
            ConsoleKeyInfo moveKey = Console.ReadKey();
            if(moveKey.Key == ConsoleKey.UpArrow)
            {
                dy = -1;
            }
            else if(moveKey.Key == ConsoleKey.DownArrow)
            {
                dy = 1;
            }
            else if(moveKey.Key == ConsoleKey.LeftArrow)
            {
                dx = -1;
            }
            else if(moveKey.Key == ConsoleKey.RightArrow)
            {
                dx = 1;
            }
            return (dx, dy);
        }

        private static (int, int) MoveLogic(int dx, int dy)
        {
            int newX = playerX + dx;
            int newY = playerY + dy;
            return (newX, newY);
        }
        private static void TryMove(char[,] field, int newX, int newY)
        {
            Move(newX,newY);
        }
        private static bool CanMove(char[,] field, int newX, int newY)
        {
            if (field[newX, newY] == '#')
            {
                return false;
            }
            return true;
        }
        private static void Move(int newX, int newY)
        {
            playerX = newX;
            playerY = newY;
        }
        private static bool IsEndGame()
        {
            if (playerX == finishX && playerY == finishY)
            {
                return true;
            }
            return false;
        }

    }
}
