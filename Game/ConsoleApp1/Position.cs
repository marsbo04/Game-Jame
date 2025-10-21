
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Position
    {
        public int x;
        public int y;
        bool gameload = true;
        private Board? baseboard;
        private Board? boardreference;
        private string previousTerrain; 
        private string? symbol;
        private string[,] bound;

        public Position(int X, int Y)
        {
            this.x = X;
            this.y = Y;
           
        }
        public Position(int X, int Y, Board refe)
        {
            this.x = X;

            this.y = Y;
            BoardReference(refe);
        }
        public void BoardReference(Board refe)
        {
            boardreference = refe;

        }
        public void PlaceHeroOnBoard(Board baseboard, string symbole)
        {
            this.symbol = symbole;

            this.baseboard = baseboard;

            var grid = boardreference.Boardgrid();
            if (y >= 0 && y < baseboard.Height && x >= 0 && x < baseboard.Width)
            {
                this.previousTerrain = grid[y, x]; 
                baseboard.PlacePiece(x, y, symbol);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Initial position is out of board bounds.");
            }
        }

        public void MoveByKeyPress()
        {
            if (baseboard == null)
                throw new InvalidOperationException("BaseBoard reference is not set. Call PlaceHeroOnBoard(baseboard) first.");

            while (gameload)
            {
                Console.Clear();
                baseboard.Display();
                var input = Console.ReadKey(false).Key;

                // save old coords
                int oldX = this.x;
                int oldY = this.y;

              
                int newX = oldX;
                int newY = oldY;

                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        newY = oldY - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        newY = oldY + 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        newX = oldX - 1;
                        break;

                    case ConsoleKey.RightArrow:
                        newX = oldX + 1;
                        break;

                    default:
                        
                        throw new Exception("Wrong input");
                }
                
                

                // bounds check
                if (newX < 0 || newX >= baseboard.Width || newY < 0 || newY >= baseboard.Height)
                {
                  
                    continue;
                }
                if (bound != null && baseboard.Boardgrid()[newY, newX] == bound[newY, newX] && baseboard.Boardgrid()[newY, newX] == baseboard.Boardgrid()[0,5])
                {
                    continue;
                }


                baseboard.PlacePiece(oldX, oldY, previousTerrain);
                Console.Clear();

                var grid = baseboard.Boardgrid();
                previousTerrain = grid[newY, newX] ?? "[~]";

                baseboard.PlacePiece(newX, newY, symbol);
                this.x = newX;
                this.y = newY;

                baseboard.Display();

                return;
            }
        }

      public string[,] SetBound(string[,] bound)
        {
           this.bound = bound;
            return bound;
        }
        public Position MoveUp()
        {
            this.x += 0;
            this.y += -1;
            Position position = new Position(this.x, this.y);
            return position;
        }

        public Position MoveDown()
        {
            this.x += 0;
            this.y += 1;
            Position position = new Position(this.x, this.y);
            return position;
        }

        public Position MoveRight()
        {
            this.x += 1;
            this.y += 0;
            Position position = new Position(this.x, this.y);
            return position;
        }

        public Position MoveLeft()
        {
            this.x += -1;
            this.y += 0;
            Position position = new Position(this.x, this.y);
            return position;
        }
    }
}