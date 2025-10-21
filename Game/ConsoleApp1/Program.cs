namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.showPetersMap();
            Console.ReadKey();
            BaseBoard baseboard = new BaseBoard();
            Position pos = new Position(0, 5, baseboard.board);
            bool gameload = true;
            string[,]? bound = null; // Fix CS0165: Initialize 'bound' to null
            pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");
            baseboard.DisplayBoard();
            while (gameload)
            {
                bool inmainmap = true;
                bool peterland = false;
                

                while (inmainmap)
                {
                    pos.MoveByKeyPress();
                    string[,] grid = new BaseBoard().board.Boardgrid();
                    if (pos.y == 5 && pos.x == 8)
                    {
                        inmainmap = false;
                        peterland = true;
                    }
                }
                
                Console.Clear();
                Petersisland peterlandboard = new Petersisland();

                Position landpos = new Position(0, 5, peterlandboard.board);
                landpos.PlaceHeroOnBoard(peterlandboard.board, "[⛵]");
                peterlandboard.board.Display();
                landpos.PlaceHeroOnBoard(peterlandboard.board, "[@]");

                while (peterland)
                {

                    string[,] grid = peterlandboard.board.Boardgrid();
                    for (int y = 0; y < peterlandboard.board.Height; y++)
                    {
                        for (int x = 0; x < peterlandboard.board.Width; x++)
                        {
                            if (y == 0 || y == peterlandboard.board.Height - 1 || x == 0 || x == peterlandboard.board.Width - 1)
                            {
                                string[,] landbound = peterlandboard.board.Boardgrid();
                                bound = landbound;
                                landpos.SetBound(landbound);
                            }
                        }
                    }
                    

                        landpos.MoveByKeyPress();

                    if (grid[landpos.x, landpos.y] == grid[0,5])
                    {
                        inmainmap = true;
                        peterland = false;
                        
                     
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
