using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Car : IMachine
    {
        public bool Start()
        {
            Console.WriteLine("Car started");
            return true;
        }
        public bool Stop() 
        {
            Console.WriteLine("Car stopped");
            return true; 
        }
    }
}
