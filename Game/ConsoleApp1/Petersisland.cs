using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Petersisland
    {
        public Board board = new(10, 10);

        public Petersisland()
        {
          
            for (int y = 1; y < board.Height+1; y++)
            {
                for (int x = 1; x < board.Width +1; x++)
                {
                    board.PlaceTerrian(x, y, "land");
                }
            }




            board.PlaceTerrian(2, 2, "water");
            board.PlaceTerrian(2, 3, "water");
            board.PlaceTerrian(3, 2, "water");
            board.PlaceTerrian(3, 3, "water");

            board.PlaceTerrian(7, 5, "water");
            board.PlaceTerrian(8, 5, "water");
            board.PlaceTerrian(8, 6, "water");
            board.PlaceTerrian(6, 6, "water");
            board.PlaceTerrian(6, 7, "water");
            board.PlaceTerrian(7, 6, "water");
            board.PlaceTerrian(7, 7, "water");

        }

        public void DisplayBoard()
        {
            board.Display();
        }
    }
}
