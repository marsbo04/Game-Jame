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
        private string title = @"
   █████████                                        █████                       
  ███░░░░░███                                      ░░███                        
 ███     ░░░  ██████  █████████████    ██████       ░███ ██████  █████████████  
░███         ░░░░░███░░███░░███░░███  ███░░███      ░███░░░░░███░░███░░███░░███ 
░███    █████ ███████ ░███ ░███ ░███ ░███████       ░███ ███████ ░███ ░███ ░███ 
░░███  ░░███ ███░░███ ░███ ░███ ░███ ░███░░░  ███   ░██████░░███ ░███ ░███ ░███ 
 ░░█████████░░█████████████░███ █████░░██████░░████████░░█████████████░███ █████
  ░░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░  ░░░░░░  ░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░ ";

        private string art = @"             __                  __
            ( _)                ( _)
           / / \\              / /\_\_
          / /   \\            / / | \ \
         / /     \\          / /  |\ \ \
        /  /   ,  \ ,       / /   /|  \ \
       /  /    |\_ /|      / /   / \   \_\
      /  /  |\/ _ '_| \   / /   /   \    \\
     |  /   |/  0 \0\    / |    |    \    \\
     |    |\|      \_\_ /  /    |     \    \\
     |  | |/    \.\ o\o)  /      \     |    \\
     \    |     /\\`v-v  /        |    |     \\
      | \/    /_| \\_|  /         |    | \    \\
      | |    /__/_ `-` /   _____  |    |  \    \\
      \|    [__]  \_/  |_________  \   |   \    ()
       /    [___] (    \         \  |\ |   |   //
      |    [___]                  |\| \|   /  |/
     /|    [____]                  \  |/\ / / ||
    (  \   [____ /     ) _\      \  \    \| | ||
     \  \  [_____|    / /     __/    \   / / //
     |   \ [_____/   / /        \    |   \/ //
     |   /  '----|   /=\____   _/    |   / //
  __ /  /        |  /   ___/  _/\    \  | ||
 (/-(/-\)       /   \  (/\/\)/  |    /  | /
               (/\/\)           /   /   //
                      _________/   /    /
                     \____________/    (";
        public TitleScreen()
        {
            menu.Add("Start");
            menu.Add("Quit");
        }
        public int SelectOption()
        {
            bool selection = true;
            int menuSelect = 0;

            // Gør cursor usynlig
            Console.CursorVisible = false;

            while (selection)
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
                    return menuSelect;
                }
                // Hvis brugeren trykker på Esc, returneres -1 for at afslutte menuen
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
                Console.WriteLine(menuSelect);
            }
            return 0;
        }
        public void StartGame()
        {
            string name;

            Console.WriteLine("This is you");
            Console.WriteLine();
            Console.Write("Type your name: ");
            name = Console.ReadLine();
        }
    }
}
