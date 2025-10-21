namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Console.WriteLine(map);
            Console.ReadKey();
            BaseBoard baseboard = new BaseBoard();
            Position pos = new Position(0, 5, baseboard.board);
            bool gameload = true;
            string[,]? bound = null; // Fix CS0165: Initialize 'bound' to null
            while (gameload)
            {
                bool inmainmap = true;
                bool onland = false;
                pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");
                baseboard.DisplayBoard();

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
                            }
                        }
                    }
                    if (bound != null && grid[landpos.y, landpos.x] != bound[landpos.y+1, landpos.x+1] && grid[landpos.y, landpos.x] == bound[0,5]) // Fix CS8602: Null check for 'bound'
                    {
                        continue;
                    }

                    landpos.MoveByKeyPress();

                    if (grid[landpos.x, landpos.y] == "[⛵]")
                    {
                        inmainmap = true;
                        onland = false;
                    }
                }
                Console.Clear();
                baseboard = new BaseBoard();

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    gameload = false;
                }
            }
        }
    }
}
