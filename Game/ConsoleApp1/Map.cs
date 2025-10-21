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
        public string text;

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
        private string MapOnPetersisland = @"   ______________________________
  /                              \
 |                               |
 |     Bring peter his White     |
 |            monster            |
 |           ________            |
 |         .'        '.          |
 |        |            |         |
 |        |    HVID    |         |
 |        |  MONSTER   |         |
 |        |            |         |
 |        |<__|<__|<__||         |
 |        | | | | | | ||         |
 |        | | | | | | ||         |
 |        | | | | | | ||         |
 |        | |/  |/  |/ |         |
 |        | |   |   |  |         |
 |        | |   |   |  |         |
 |        '------------'         |
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
        public void showPetersMap2()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MapOnPetersisland);
            Console.ResetColor();
        }

    }

}
