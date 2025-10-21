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

        private Object monster = new Object("Hvid Monster:", 25, "🍶");
        public Object Monster { get { return monster; } }
        /*private string hvidMonner = @"     .------.
   .'        '.
  |            |
  |    HVID    |
  |  MONSTER   |
  |    ///     |
  |   ///      |
  |  ///       |
  |            |
  |            |
  '------------'"; */

        public Shop()
        {
            this.Shopitems = new List<Object>();
        }

        public void ReCreateShopWithItems(Shop shop)
        {

            shop = new Shop();
            Object Cigaret = new Object("Cigaret", 75, "🚬");
            shop.Shopitems.Add(monster);
            shop.Shopitems.Add(Cigaret);
        }

        public Shop Sell(Shop shop, Hero hero)
        {
            Object monster = new Object("Hvid Monster: ", 25, "🍶");
            Object Cigaret = new Object("Cigaret: ", 75, "🚬");
            if (shop.Shopitems.Contains(monster))
            {
                hero.HeroBuy(25, hero);
                hero.Inventory.Add(monster);
                shop.Shopitems.Remove(monster);
            }
            else if (shop.Shopitems.Contains(Cigaret))
            {
                hero.HeroBuy(75, hero);
                hero.Inventory.Add(Cigaret);
                shop.Shopitems.Remove(Cigaret);
            }
            else
            {
                throw new Exception("Item is not in shop");
            }

            return shop;
        }




    }
}
