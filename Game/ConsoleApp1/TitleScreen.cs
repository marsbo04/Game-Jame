using System;

namespace ConsoleApp1
{
    public class TitleScreen
    {
        private List<string> menu = new List<string>();
        public List<string> Menu
        {
            get { return menu; }
        }
        public TitleScreen()
        {
            string title = @"
   █████████                                        █████                       
  ███░░░░░███                                      ░░███                        
 ███     ░░░  ██████  █████████████    ██████       ░███ ██████  █████████████  
░███         ░░░░░███░░███░░███░░███  ███░░███      ░███░░░░░███░░███░░███░░███ 
░███    █████ ███████ ░███ ░███ ░███ ░███████       ░███ ███████ ░███ ░███ ░███ 
░░███  ░░███ ███░░███ ░███ ░███ ░███ ░███░░░  ███   ░██████░░███ ░███ ░███ ░███ 
 ░░█████████░░█████████████░███ █████░░██████░░████████░░█████████████░███ █████
  ░░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░  ░░░░░░  ░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░ ";
            menu.Add(title);
            menu.Add("");
            menu.Add("");
            menu.Add("Start");
            menu.Add("Quit");
        }
        public int SelectOption()
        {
            bool selection = true;
            int menuSelect = 4;
            while (selection)
            {
                Console.Clear();

                // Gør cursor usynlig
                Console.CursorVisible = false;

                for (int i = 0; i < menu.Count; i++)
                {
                    // Hvis menu item er valgt, vises en markering
                    Console.WriteLine((i + 1 == menuSelect ? "* " : "") + menu[i] + (i + 1 == menuSelect ? "<--" : ""));
                }
                var keyPressed = Console.ReadKey();

                // Hvis brugeren trykker på pil ned, øges menuSelect med 1
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menu.Count)
                {
                    menuSelect++;
                }
                // Hvis brugeren trykker på pil op, mindskes menuSelect med 1
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 5)
                {
                    menuSelect--;
                }
                // Hvis brugeren trykker på Enter, returneres menuSelect
                else if (keyPressed.Key == ConsoleKey.Enter)
                {

                    return menuSelect;
                    selection = false;
                }
                // Hvis brugeren trykker på Esc, returneres -1 for at afslutte menuen
                else if (keyPressed.Key == ConsoleKey.Escape)
                {
                    return -1;
                    selection = false;
                }
            }
            return 0;
        }
    }
}
