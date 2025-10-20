using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TitleScreen
    {
        private List<string> menu = new List<string>();

        public List<string> Menu
        {
            get { return menu; }
        }
        public void Titlescreen()
        {
            string grapichs = @"
   █████████                                        █████                       
  ███░░░░░███                                      ░░███                        
 ███     ░░░  ██████  █████████████    ██████       ░███ ██████  █████████████  
░███         ░░░░░███░░███░░███░░███  ███░░███      ░███░░░░░███░░███░░███░░███ 
░███    █████ ███████ ░███ ░███ ░███ ░███████       ░███ ███████ ░███ ░███ ░███ 
░░███  ░░███ ███░░███ ░███ ░███ ░███ ░███░░░  ███   ░██████░░███ ░███ ░███ ░███ 
 ░░█████████░░█████████████░███ █████░░██████░░████████░░█████████████░███ █████
  ░░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░  ░░░░░░  ░░░░░░░░  ░░░░░░░░░░░░░ ░░░ ░░░░░ ";

            
            menu.Add(grapichs);
            menu.Add("\n\nStart");
            menu.Add("Quit");
        }
        public void ShowTitleScreen()
        {
            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public void SelectOption()
        {
            int[] titleScreenOption = new int[menu.Count];

        }
    }
}
