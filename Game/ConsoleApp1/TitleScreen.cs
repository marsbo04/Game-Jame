using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public class TitleScreen
    {
        private List<string> menu = new List<string>();
        public List<string> Menu
        {
            get { return menu; }
        }

        private int menuSelect;
        public int MenuSelect
        {
            get { return menuSelect; }
        }
        public string Name { get; private set; }


        private string title = @"
   █████████                                        █████                       
  ███░░░░░███                                      ░░███                        
 ███     ░░░  ██████  █████████████    ██████       ░███ ██████  █████████████  
░███         ░░░░░███░░███░░███░░███  ███░░███      ░███░░░░░███░░███░░███░░███ 
░███    █████ ███████ ░███ ░███ ░███ ░███████       ░███ ███████ ░███ ░███ ░███ 
░░███  ░░███ ███░░███ ░███ ░███ ░███ ░███░░░  ███   ░██████░░███ ░███ ░███ ░███ 
 ░░█████████░░█████████████░███ █████░░██████░░████████░░█████████████░███ █████
  ░░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░  ░░░░░░  ░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░ ";

        private string art = @"   (  )   /\   _                 (     
    \ |  (  \ ( \.(               )                      _____
  \  \ \  `  `   ) \             (  ___                 / _   \
 (_`    \+   . x  ( .\            \/   \____-----------/ (o)   \_
- .-               \+  ;          (  O                           \____
                          )        \_____________  `              \  /
(__                +- .( -'.- <. - _  VVVVVVV VV V\                 \/
(_____            ._._: <_ - <- _  (--  _AAAAAAA__A_/                  |
  .    /./.+-  . .- /  +--  - .     \______________//_              \_______
  (__ ' /x  / x _/ (                                  \___'          \     /
 , x / ( '  . / .  /                                      |           \   /
    /  /  _/ /    +                                      /              \/
   '  (__/                                             /                  \";

        Hero hero = new Hero();

        public TitleScreen()
        {
            menu.Add("Start");
            menu.Add("Quit");
        }

        
        public int SelectOption()
        {
            bool selection = false;
            menuSelect = 0;

            // Gør cursor usynlig
            Console.CursorVisible = false;


            while (!selection)
            {
                Console.Clear();
                //Tilføjet eftersom Console.clear ikke fjerner alt i consolen fordi den ikke kan se det øverste (Det her virker idk why)
                Console.WriteLine("\x1b[3J");

                Console.WriteLine(title);
                Console.WriteLine("\n");


                for (int i = 0; i < menu.Count; i++)
                {
                    // Hvis menu item er valgt, vises en markering
                    Console.WriteLine((i == menuSelect ? "* " : "") + menu[i] + (i == menuSelect ? "<--" : ""));
                }

                Console.WriteLine("\n" + art);

                var keyPressed = Console.ReadKey();

                // Hvis brugeren trykker på pil ned, øges menuSelect med 1
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < menu.Count - 1)
                {
                    menuSelect++;
                }
                // Hvis brugeren trykker på pil op, mindskes menuSelect med 1
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect > 0)
                {
                    menuSelect--;
                }
                // Hvis brugeren trykker på Enter, returneres menuSelect
                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            StartGame(hero.Character);
                            return 0;

                        case 1:
                            return 1;
                    }
                }
                // Hvis brugeren trykker på Esc, returneres -1 for at afslutte menuen
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
            }
            return -1;
        }
        private string StartGame(string character)
        {
            Console.Clear();
            Console.WriteLine("This is you");
            Console.WriteLine(character);
            Console.Write("Type your name: ");
            Name = Console.ReadLine();
            Console.Clear();
            return Name;
        }
    }
}
