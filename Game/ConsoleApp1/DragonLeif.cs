using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DragonLeif
    {
        public string symbol = "[🐲]";
        Position position;
        string art = @"    __                  __
            ( _)                ( _)
           / / \\              / /\_\_
          / /   \\            / / | \ \
         / /     \\          / /  |\ \ \
        /  /   ,  \ ,       / /   /|  \ \
       /  /    |\_ /|      / /   / \   \_\
      /  /  |\/ _ '_| \   / /   /   \    \\
     |  /   |/  0 \0\    / |    |    \    \\
     |    |\|      \_\_ /  /    |     \    \\
     |  | |/    \.\ o\o)  /      \     |    \\
     \    |     /\\`v-v  /        |    |     \\
      | \/    /_| \\_|  /         |    | \    \\
      | |    /__/_ `-` /   _____  |    |  \    \\
      \|    [__]  \_/  |_________  \   |   \    ()
       /    [___] (    \         \  |\ |   |   //
      |    [___]                  |\| \|   /  |/
     /|    [____]                  \  |/\ / / ||
    (  \   [____ /     ) _\      \  \    \| | ||
     \  \  [_____|    / /     __/    \   / / //
     |   \ [_____/   / /        \    |   \/ //
     |   /  '----|   /=\____   _/    |   / //
  __ /  /        |  /   ___/  _/\    \  | ||
 (/-(/-\)       /   \  (/\/\)/  |    /  | /
               (/\/\)           /   /   //
                      _________/   /    /
                     \____________/    (";

        public string LeifAsks()
        {
            Random rand = new Random();
            string[] questions = ["Hvor gammel er jeg? ", "Hvad underviser jeg i? "];

            int questionindex = rand.Next(questions.Length);
            return questions[questionindex];
        } 

        public void AnswerLeif(string leifquestion, Hero hero)
        {
            string rightanswer = "Nice tillykke du har svaret rigtigt!";
            Console.WriteLine(art);
            Console.WriteLine();
            Console.WriteLine(leifquestion);
            Console.WriteLine();
            

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "36":
                    Console.WriteLine(rightanswer);
                    return;

                case "Programmering":
                    Console.WriteLine(rightanswer);
                    return;
                default:
                    Console.WriteLine("Dit svar var forkert! + " +
                        "Du mister 1 hp");
                    hero.LoseHP(hero);
                    return;
            } 

        }
    }
}
