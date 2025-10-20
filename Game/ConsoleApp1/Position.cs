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
            Board board = new Board(10,10);
            board.PlacePiece(5, 5, "⛵");
        } 

        public void MoveByKeyPress()
        {
            while (gameload)
            {
                var input = Console.ReadKey(false).Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        Position newUp = MoveUp();
                        //Board newboard = new Board(newboard.Width, newboard.Height);
                        //newboard.PlacePiece(newUp.x, newUp.y, "⛵");
                        //newboard.Display();
                        return;

                    case ConsoleKey.DownArrow:
                        Position newDown = MoveDown();
                        //Board newboard = new Board(newboard.Width, newboard.Height);
                        //newboard.PlacePiece(newDown.x, newDown.y, "⛵");
                        //newboard.Display();
                        return;

                    case ConsoleKey.LeftArrow:
                        Position newLeft = MoveLeft();
                        //Board newboard = new Board(newboard.Width, newboard.Height);
                        //newboard.PlacePiece(newLeft.x, newLeft.y, "⛵");
                        //newboard.Display();
                        return;
                    case ConsoleKey.RightArrow:
                        Position newRight = MoveRight();
                        //Board newboard = new Board(newboard.Width, newboard.Height);
                        //newboard.PlacePiece(newRight.x, newRight.y, "⛵");
                        //newboard.Display();
                        return;
                    default:
                        throw new Exception("Wrong input");
                }
            }
        }

        public Position MoveUp()
        {
            this.x += 0;
            this.y += 1;

            Position position = new Position(this.x, this.y);
            return position;
        }

        public Position MoveDown()
        {
            this.x += 0;
            this.y += -1;

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
