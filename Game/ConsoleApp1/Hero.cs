using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Hero
    {
        public string Name;
        public int HpBar;
        public int Coins;
        public int Armor;
        public string Ship = "⛵";
        private string character = @"      ////^\\\\
      | ^   ^ |
     @ (o) (o) @
      |   <   |
      |  ___  |
       \_____/
     ____|  |____
    /    \__/    \
   /              \
  /\_/|        |\_/\
 / /  |        |  \ \
( <   |        |   > )
 \ \  |        |  / /
  \ \ |________| / /
   \ \|";

        public string Character
        {
            get { return character; }
        }

        public Hero() :
            this("")
        {

        }
        public Hero(string name)
        {
            this.Name = name;
            this.HpBar = 3;
            this.Coins = 100;
            this.Armor = 0;
        }

        public void ShowHeroOnShipOnBoard(Hero hero)
        {
            Position ship = new Position(5, 5);
            //ship.method(hero.Ship);
        }


        public Hero HeroBuy(int price, Hero hero)
        {
            int newCoins = hero.Coins;
            if (price > hero.Coins)
            {
                throw new Exception("You do not have coins for this");
            }

            else
            {
                newCoins -= price;
                hero.Coins = newCoins;
            }

            return hero;


        }

        public Hero GainArmor(Hero hero)
        {
            int armor = 1;
            hero.Armor += armor;
            return hero;
        }

        public Hero LoseArmor(Hero hero)
        {
            int armor = hero.Armor;
            armor = armor - 1;
            if (armor < 0)
            {
                throw new ArgumentNullException("Armor cannot go below 0");
            }
            hero.Armor = armor;
            return hero;
        }

        public Hero LoseHP(Hero hero)
        {
            int hp = hero.HpBar;
            hp = hp - 1;
            if (hp < 0)
            {
                throw new ArgumentNullException("Health cannot go below 0");
            }
            hero.HpBar = hp;
            return hero;

        }


        public override string ToString()
        {
            return $"Navn: {Name} HP: {HpBar} Coins: {Coins} Armor: {Armor}";
        }
    }
}
