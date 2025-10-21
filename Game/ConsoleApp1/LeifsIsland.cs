using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LeifsIsland
    {
        public Board board = new(10, 10);
        public Map map = new Map();
        public DragonLeif dl = new DragonLeif();

        public LeifsIsland()
        {

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    board.PlaceTerrian(x, y, "land");
                }
            }

                   
            board.PlacePiece(7, 2, dl.symbol);

            makewaterbounderis();
        }
        public void makewaterbounderis()
        {

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if (y == 0 || y == board.Height - 1 || x == 0 || x == board.Width - 1)
                    {
                        board.PlaceTerrian(x, y, "water");
                    }
                }
            }
        }
        public void DisplayBoard()
        {
            board.Display();
        }
    }
}
