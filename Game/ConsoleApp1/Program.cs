namespace ConsoleApp1
{
    internal class Program
    {
        public static Hero hero = new Hero();
        public static BaseBoard baseboard = new BaseBoard();
        public static LeifsIsland lieflandboard = new LeifsIsland();
        public static Petersisland peterlandboard = new Petersisland();
        static void Main(string[] args)
        {
            Console.ResetColor();
            bool gameload = false;
            TitleScreen titleScreen = new TitleScreen();
            int start = titleScreen.SelectOption();

            switch (start)
            {
                case 0:
                    Console.Clear();
                    gameload = true;
                    break;
                case 1:
                    return;
                default:
                    gameload = false;
                    Environment.Exit(0);
                    break;


            }
            Map map = new Map();
            DragonLeif dl = new DragonLeif();

            Position pos = new Position(0, 5, baseboard.board);

            string[,]? bound = null; // Fix CS0165: Initialize 'bound' to null
            pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");
            baseboard.DisplayBoard();

            // Persist this flag for the whole game session so the map unlock is not lost.
            bool canOpenPeterisland = false;

            while (gameload)
            {
                if (hero.HpBar <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You have died! Game Over.");
                    gameload = false;
                    break;
                }

                bool inmainmap = true;
                bool liefisland = false;
                bool peterland = false;

                // (canOpenPeterisland removed from here; it's declared outside the loop)

                while (inmainmap)
                {

                    pos.CanEnter = (px, py) =>
                    {
                        // Block specific tiles until the map is found.
                        if (!canOpenPeterisland && px == 8 && py == 5)
                            return false; // blocked
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
                        else
                            return true;
                    };

                    pos.MoveByKeyPress();

                    if (pos.y == 3 && pos.x == 2 || pos.y == 2 && pos.x == 2 || pos.y == 2 && pos.x == 3 || pos.y == 3 && pos.x == 3)
                    {
                        pos.RemoveFromBoard();
                        inmainmap = false;
                        peterland = false;
                        liefisland = true;

                    }
                    if (pos.y == 5 && pos.x == 8 || pos.y == 5 && pos.x == 7 || pos.y == 6 && pos.x == 6 || pos.y == 6 && pos.x == 7 || pos.y == 6 && pos.x == 8 || pos.y == 7 && pos.x == 6 || pos.y == 7 && pos.x ==7)
                    {
                        pos.RemoveFromBoard();
                        inmainmap = false;
                        peterland = true;
                        liefisland = false;
                    }

                }
                if (liefisland)
                {
                    Console.Clear();


                    // create island position and place hero on island
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
                        // move first, then check the *current* grid on the island (fresh snapshot)
                        landpos.MoveByKeyPress();
                        string[,] grid = lieflandboard.board.Boardgrid();

                        // Check the terrain under the hero (MoveByKeyPress updates previousTerrain).
                        if (landpos.GetUnderlyingTile() == "[⛵]")
                        {
                            inmainmap = true;
                            peterland = false;
                            liefisland = false;

                            int entryX = 0;
                            int entryY = 5;

                            // remove island hero and restore tile, then switch main Position back and place hero there
                            landpos.RemoveFromBoard();
                            pos.x = entryX;
                            pos.y = entryY;
                            pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");
                            Console.Clear();
                            baseboard.DisplayBoard();

                            break;
                        }

                        if (landpos.GetUnderlyingTile() == "[📜]")
                        {
                            Console.Clear();
                            Console.WriteLine("\x1b[3J");
                            // unlock Peter's island and return to main map
                            canOpenPeterisland = true;
                            lieflandboard.map.showPetersMap();

                            hero.Coins += 50;
                            // switch back to main map and place the main hero
                            landpos.boardreference.PlaceTerrian(5, 2, "land");
                            landpos.PlaceHeroOnBoard(lieflandboard.board, "[@]");


                        }

                        if (landpos.GetUnderlyingTile() == "[🐲]")
                        {
                            Console.ResetColor();
                            Console.Clear();
                            //Save random Question from Leif in a string
                            string question = dl.LeifAsks();
                            //Give Question to method that promps Encounter
                            dl.AnswerLeif(question, hero);
                            if (dl.leifdefeated())
                            {
                                landpos.boardreference.PlacePiece(5, 2, map.map);
                                landpos.boardreference.PlaceTerrian(7, 2, "land");
                                landpos.PlaceHeroOnBoard(lieflandboard.board, "[@]");

                            }

                        }
                    }
                }
                if (peterland)
                {
                    Console.Clear();
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


                        if (landpos.GetUnderlyingTile() == "[⛵]")
                        {
                            inmainmap = true;
                            peterland = false;
                            liefisland = false;

                            int entryX = 0;
                            int entryY = 5;

                            // remove island hero and restore tile, then switch main Position back and place hero there
                            landpos.RemoveFromBoard();
                            pos.x = entryX;
                            pos.y = entryY;
                            pos.PlaceHeroOnBoard(baseboard.board, "[⛵]");
                            Console.Clear();
                            baseboard.DisplayBoard();

                            break;
                        }
                        if (landpos.GetUnderlyingTile() == "[🏪]")
                        {
                            Console.Clear();
                            canOpenPeterisland = true;
                            Console.WriteLine("You enter the shop...");


                            peterlandboard.shop.ReCreateShopWithItems(peterlandboard.shop);

                            Position peterpanpos = new Position(3, 3, peterlandboard.board);
                            Peterpan peterpan = new Peterpan(peterpanpos);

                            peterlandboard.board.PlacePiece(landpos.x, landpos.y, "[@]");

                            continue;
                        }
                        if (landpos.GetUnderlyingTile() == "[📜]")
                        {
                            Console.Clear();
                            Console.WriteLine("\x1b[3J");
                            // unlock Peter's island and return to main map
                            canOpenPeterisland = true;
                            Console.WriteLine();
                            lieflandboard.map.showPetersMap2();

                            hero.Coins += 50;
                            // switch back to main map and place the main hero
                            landpos.boardreference.PlaceTerrian(5, 5, "land");
                            landpos.PlaceHeroOnBoard(peterlandboard.board, "[@]");
                        }
                    }
                    continue;
                }
                baseboard = new BaseBoard();
            }
        }
    }
}
