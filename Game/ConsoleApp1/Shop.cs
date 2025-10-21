using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Shop
    {
        public string symbol = "[🏪]";
        private List<Object> Shopitems;

        private Object monster = new Object("Hvid Monster:", 25, "🍶");
        public Object Monster { get { return monster; } }

        public Shop()
        {
            this.Shopitems = new List<Object>();
        }

        public void ReCreateShopWithItems(Shop shop)
        {

            
            Object Cigaret = new Object("Cigaret", 75, "🚬");
            monster = new Object("Hvid Monster:", 25, "🍶");
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
                        continue;


                }
            }
            input = chosinginput;
            if (input == "🍶")
            {
                Sell(shop, Program.hero,monster);
            }
            else if (input == "🚬")
            {
                Sell(shop, Program.hero,Cigaret);
            }
            else
            {
                throw new Exception("Invalid input");
            }
        }

        public Shop Sell(Shop shop, Hero hero, Object sellingobject)
        {
            
            if (shop.Shopitems.Contains(sellingobject))
            {
                hero.HeroBuy(sellingobject.Value, hero);
                hero.Inventory.Add(sellingobject);
                shop.Shopitems.Remove(sellingobject);
            }
           
            else
            {
               Console.WriteLine("Item is no longer available in the shop.");
                return shop;
            }
            Console.WriteLine($"You have bought {sellingobject.Name} for {sellingobject.Value} coins.");
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
