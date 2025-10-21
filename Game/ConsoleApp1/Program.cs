namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseBoard baseboard = new BaseBoard();
            Position pos = new Position(0, 5, baseboard.board);
            bool gameload = true;
            while (gameload)
            {
                bool inmainmap = true;
                bool onland = false;
                pos.PlaceHeroOnBoard(baseboard.board);
                baseboard.DisplayBoard();

                while (inmainmap)
                {
                    pos.MoveByKeyPress();
                    string[,] grid = new BaseBoard().board.Boardgrid();
                    if (grid[pos.x, pos.y] == "[#]")
                    {
                        inmainmap = false;
                        onland = true;
                    }
                }
                Console.Clear();
                Petersisland landboard = new Petersisland();

                Position landpos = new Position(0, 5, landboard.board);
                landpos.PlaceHeroOnBoard(landboard.board);
                landboard.board.Display();
                while (onland)
                {
                    string[,] grid = landboard.board.Boardgrid();
                    landpos.MoveByKeyPress();

                    if (grid[landpos.x, landpos.y] == "[~]")
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
