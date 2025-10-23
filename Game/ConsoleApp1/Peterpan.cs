using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Peterpan
    {
        public string peter = "[🧚‍]";
        Position position;
        Hero hero = new Hero();
        Shop shop = new Shop();

        public Peterpan(Position pos)
        {
            this.position = pos;
        }

        public void FightWithPeterPan(Hero hero)
        {
            if (hero.Inventory.Contains(shop.Monster))
            {
                Console.WriteLine("Du har Hvid Monster i din inventar, Peter Pan bliver interesseret og lander forand dig");
                Console.WriteLine("Peter Pan udfordrer dig til kamp!");
                Console.WriteLine("Vælg dit våben: ");
                
                Console.WriteLine("1. Sværd (🗡️)");
                Console.WriteLine("2. Bue og pil (🏹)");
                Console.WriteLine("3. Magisk tryllestav (✨)");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Du har valgt sværdet! Du kæmper tappert og vinder kampen mod Peter Pan!");
                        return;
                    case "2":
                        Console.WriteLine("Du har valgt bue og pil! Du skyder præcist og besejrer Peter Pan!");
                        return;
                    case "3":
                        Console.WriteLine("Du har valgt den magiske tryllestav! Med dine magiske evner overvinder du Peter Pan!");
                        return;
                    default:
                        Console.WriteLine("Ugyldigt valg! Peter Pan udnytter din tøven og vinder kampen.");
                        hero.LoseHP(hero);
                        return;
                }
            }
            else
            {
                Console.WriteLine("Peter Pan griner af dig, og flyver videre");
                return;

            }


        }
    }
}

