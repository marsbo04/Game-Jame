using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Position
    {
        int x;
        int y;
        bool gameload = true;

        public Position(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        } 

        //public Position CreateTuplePosition(Position pos)
        //{
        //    (int,int) tuple = (pos.x,pos.y);
        //} Måske ikke nødvendigt

        public void PlaceHeroOnBoard()
        {
            Board board = new Board();
            //board.PlacePiece(5, 5, "⛵");
        } 

        public void MoveByKeyPress()
        {
            while (gameload)
            {
                var input = Console.ReadKey(false).Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow :
                        MoveUp();
                        return;
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        return;
                    case ConsoleKey.LeftArrow:
                        MoveLeft();
                        return;
                    case ConsoleKey.RightArrow:
                        MoveRight();
                        return;
                }
            }
        }

        public void MoveUp()
        {
            this.x += 0;
            this.y += 1;
        }

        public void MoveDown()
        {
            this.x += 0;
            this.y += -1;
        }

        public void MoveRight()
        {
            this.x += 1;
            this.y += 0;
        }

        public void MoveLeft()
        {
            this.x += -1;
            this.y += 0;
        }
    }
}
