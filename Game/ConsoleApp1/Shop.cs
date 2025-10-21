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
            displayShopItems(shop);
            Console.WriteLine("What do you want to buy? (🍶/🚬)");
            string chosinginput = "";
            string input;
            Console.WriteLine("Use the up arrow to choose 🍶 and down arrow to choose 🚬");
            Console.WriteLine("Press Enter to confirm your choice");
            Console.WriteLine();
            var curserpo = Console.GetCursorPosition();
            bool choosing = true;
            while (choosing)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(curserpo.Left, curserpo.Top);
                        chosinginput = "🍶";
                        Console.WriteLine(chosinginput);
                        break;
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(curserpo.Left, curserpo.Top);
                        chosinginput = "🚬";
                        Console.WriteLine(chosinginput);
                        break;
                    case ConsoleKey.Enter:
                        choosing = false;
                        break;
                    default:
                        throw new Exception("You need to press enter to confirm your choice");
                
                }
            }
            input = chosinginput;
            if (input == "🍶")
            {
                Sell(shop, Program.hero);
            }
            else if (input == "🚬")
            {
                Sell(shop, Program.hero);
            }
            else
            {
                throw new Exception("Invalid input");
            }
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


        public void displayShopItems(Shop shop)
        {
            Console.WriteLine("Items available in the shop:");
            foreach (var item in shop.Shopitems)
            {
                Console.WriteLine($"{item.Name} - Price: {item.Value} Coins - Symbol: {item.Symbole}");
            }
            
        }

    }
}
