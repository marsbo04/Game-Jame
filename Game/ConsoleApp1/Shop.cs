using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Shop
    {
        public string symbol = "[🏪]";
        List<Object> Shopitems;
        

        public Shop()
        {
            this.Shopitems = new List<Object>();
        } 

        public void ReCreateShopWithItems()
        {

            Shop shop = new Shop();
            Object monster = new Object("Hvid Monster:", 25, "🍶");
            Object Cigaret = new Object("Cigaret", 75, "🚬");
            shop.Shopitems.Add(monster);
            shop.Shopitems.Add(Cigaret);
        } 

        
        
    }
}
