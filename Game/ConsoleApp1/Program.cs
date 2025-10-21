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
                bool liefisland = false;
                bool peterland = false;
                
                bool canOpenPeterisland = false;             

                while (inmainmap)
                {
                    baseboard.DisplayBoard();
                    pos.CanEnter = (px, py) =>
                    {

                        if (!canOpenPeterisland && px == 8 && py == 5)
                            return false; // blocked
                        else if (!canOpenPeterisland && px == 8 && py == 5)
                            return false;
                        else if (!canOpenPeterisland && px == 8 && py == 6)
                            return false;
                        else if (!canOpenPeterisland && px == 7 && py == 5)
                            return false;
                        else if (!canOpenPeterisland && px == 7 && py == 6)
                            return false;
                        else if (!canOpenPeterisland && px == 7 && py == 7)
                            return false;
                        else if (!canOpenPeterisland && px == 6 && py == 6)
                            return false;
                        else if (!canOpenPeterisland && px == 6 && py == 7)
                            return false;
                        return true;
                    };

                    pos.MoveByKeyPress();
                    
                    if (pos.y == 3 && pos.x == 2)
                    {
                        inmainmap = false;
                        liefisland = true;
                        peterland = false;

                    }
                    if (pos.y == 5 && pos.x == 8)
                    {
                        if (canOpenPeterisland)
                        {
                            inmainmap = false;
                            peterland = true;
                            liefisland = false;
                        }
                        continue;

                    }
                }
                if (liefisland)
                {
                    Console.Clear();
                    LeifsIsland lieflandboard = new LeifsIsland();
                    Position landpos = new Position(0, 5, lieflandboard.board);

                    for (int y = 0; y < lieflandboard.board.Height; y++)
                    {
                        for (int x = 0; x < lieflandboard.board.Width; x++)
                        {
                            if (y == 0 || y == lieflandboard.board.Height - 1 || x == 0 || x == lieflandboard.board.Width - 1)
                            {
                                string[,] landbound = lieflandboard.board.Boardgrid();
                                bound = landbound;
                                landpos.SetBound(landbound);
                            }
                        }
                    }
                    landpos.y = 5;
                    landpos.x = 0;

                    landpos.PlaceHeroOnBoard(lieflandboard.board, "[⛵]");

                    lieflandboard.board.Display();
                    landpos.PlaceHeroOnBoard(lieflandboard.board, "[@]");

                    while (liefisland)
                    {


                        string[,] grid = lieflandboard.board.Boardgrid();


                        



                        landpos.MoveByKeyPress();
                        if (grid[landpos.y, landpos.x] == "[⛵]")
                        {
                            inmainmap = true;
                            peterland = false;
                            liefisland = false;

                            // Return hero to the main/base board.
                            // Choose the target coordinates on the main map where the hero should appear.
                            // Adjust entryX/entryY to the desired arrival tile on the baseboard.
                            int entryX = 0; // example X on main map
                            int entryY = 5; // example Y on main map

                            // Ensure the main map Position (pos) references the baseboard and place the hero.
                            pos.BoardReference(baseboard.board);
                            pos.x = entryX;
                            pos.y = entryY;
                            pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");

                            break;
                        }

                        if (grid[landpos.y, landpos.x] == "[📜]")
                        {
                            canOpenPeterisland = true;
                        }

                    }
                }
                if (peterland)
                {
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


                        if (grid[landpos.y, landpos.x] == grid[0, 5])
                        {
                            inmainmap = true;
                            peterland = false;
                        }
                    }
                    continue;
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
