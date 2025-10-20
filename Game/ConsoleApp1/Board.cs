using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        private string[,] grid;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new string[Height, Width];
            Console.ForegroundColor = ConsoleColor.Blue;
            // Initialize the board with empty spaces
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    grid[y, x] = "[~]";
                }
            }
            
        }


        public void PlaceTerrian(int x, int y, string terrian)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException("Position is out of bounds.");
            if (terrian == "water")
            {
                x = x - 1;
                y = y - 1;
                grid[y, x] = "[~]";                
            }
            else if (terrian == "land")
            {
                x = x - 1;
                y = y - 1;
                grid[y, x] = "[#]";
              
            }
        }

        public void PlacePiece(int x, int y, string symbol)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException("Position is out of bounds.");
            grid[y, x] = symbol;
        }

        public void Display()
        {

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (grid[y, x] == "[#]")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(grid[y, x]);
                    }
                    else if (grid[y, x] == "[~]")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(grid[y, x]);
                    }
                    else if (grid[y,x] == "⛵")
                    {
                        Console.OutputEncoding = System.Text.Encoding.Unicode;
                        Console.Write(grid[y, x]);
                    }
                    else
                    {
                        Console.ResetColor();
                    }                   
                }
                Console.WriteLine();
            }
        }

        public string[,] Boardgrid()
        {
            return grid;
        }

        public void Baseboard()
        {

        }
}
