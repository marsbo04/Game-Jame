using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class LawnMower : IMachine
    {
        public bool Start()
        {
            Console.WriteLine("Lawn Mower Started");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Lawn Mower stopped");
            return true;
        }
    }
}
