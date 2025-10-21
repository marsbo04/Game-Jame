using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Map
    {
        public string map = "[📜]";

        private string petersMap = @"   ______________________________
  /                              \
 |                               |
 |    You have now unlocked      |
 |        Peter's Island!        |
 |                               |
 |      _ _         _ _          |
 |    /\\/%\     . /%\/%\        |
 |  __.<\\%#//\,_  <%%#/%%\,__   |
 |<%#/|\\%%%#///\ /^%#%%\///%#\\ |
 | """"/%/""""\ \""""//      | |       |
 |   /'`   \ \  `   ""  / /       |
 |          \ \       / /        |
 |           \ \     / /   .     |
 |           ..:\ \:::/ /:.      |
 |       ___________________     |
 |                               |
 |                               |
 |   ____________________________|
 |  /                            /
 \_/____________________________/ ";
        public void showPetersMap()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(petersMap);
            Console.ResetColor();
        }

       
    }

}
