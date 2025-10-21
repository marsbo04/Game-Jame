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

        private string mymap = @"   ______________________________
 / \                             \.
|   |                            |.
 \_ |     you now have unlock    |.
    |     unlocked peters island |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |                            |.
    |   _________________________|___
    |  /                            /.
    \_/dc__________________________/.";
        public string mytext (string text) 
        {
            return mymap;
        }




        public override string ToString()
        {
            Console.WriteLine();
            return map;
        }

       
    }

}
