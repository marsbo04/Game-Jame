using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Object
    {
        public string Name;        
        public int Value;
        public string Symbole;
        public Object(string name, int value, string symbole)
        {
            this.Name = name;
           this.Symbole = symbole;
            this.Value = value;
        }
    }
}
