namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseBoard baseboard = new BaseBoard();
            Position pos = new Position(0, 5, baseboard.board);
            bool gameload = true;
            string[,]? bound = null; // Fix CS0165: Initialize 'bound' to null
            pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");
            baseboard.DisplayBoard();
            while (gameload)
            {
                bool inmainmap = true;
                bool onland = false;
                

                while (inmainmap)
                {
                    pos.MoveByKeyPress();
                    string[,] grid = new BaseBoard().board.Boardgrid();
                    if (grid[pos.y, pos.x] == grid[5, 8])
                    {
                        inmainmap = false;
                        onland = true;
                    }
                }
                
                Console.Clear();
                Petersisland landboard = new Petersisland();

                    Position landpos = new Position(0, 5, landboard.board);
                    landpos.PlaceHeroOnBoard(landboard.board, "[⛵]");
                    landboard.board.Display();
                    landpos.PlaceHeroOnBoard(landboard.board, "[@]");

                    while (onland)
                    {

                    string[,] grid = landboard.board.Boardgrid();
                    for (int y = 0; y < landboard.board.Height; y++)
                    {
                        for (int x = 0; x < landboard.board.Width; x++)
                        {
                            if (y == 0 || y == landboard.board.Height - 1 || x == 0 || x == landboard.board.Width - 1)
                            {
                                string[,] landbound = landboard.board.Boardgrid();
                                bound = landbound;
                                landpos.SetBound(landbound);
                            }
                        }
                    }
                    

                        landpos.MoveByKeyPress();

                    if (grid[landpos.x, landpos.y] == grid[0,5])
                    {
                        inmainmap = true;
                        onland = false;
                        
                     
                    }
                }



               baseboard = new BaseBoard();


                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    gameload = false;
                }
            }
        }
    }
}
