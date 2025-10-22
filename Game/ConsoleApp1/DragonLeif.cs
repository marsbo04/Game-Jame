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
        string leifSur = @"                            /|               |\                              
                           / | ___-------___ | \                             
                          /  \/ ^ /\   /\ ^ \/  \                            
                         |   (  O-. \ / .-O  )   |                           
                      /-\/   ^-----^-V-^-----^   \/-\                        
                    /-      (~ 0O0 ~) (~ 000 ~)     -\                       
                   <        (~ OOO ~) (~ 000 ~)       >                      
                    \-      (____---===---____)     -/                       
                     \-   /\ \ \|         |/ / /\  -/                        
                     -/\-/  \ \ V         V / /  \-/\-                       
                        v    \ \           / /    v                          
                              \ \ A     A / /                                
                               \_\^-----^/_/                                 
                                \_/\___/\_/                                  
                                  \_____/";

        public string LeifAsks()
        {
            Random rand = new Random();
            string[] questions = ["Hvor underviser jeg henne? ", "Hvad underviser jeg i? "];

            int questionindex = rand.Next(questions.Length);
            return questions[questionindex];
        } 

        public void AnswerLeif(string leifquestion, Hero hero)
        {
            string rightanswer = "Nice! Tillykke du har svaret rigtigt!";
            Console.WriteLine(art);
            Console.WriteLine();
            Console.WriteLine("Leif:");
            Console.WriteLine(leifquestion);
            Console.WriteLine();
            

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "UCL":
                    Console.WriteLine(rightanswer);
                    leifdefeated();
                    return;

                case "Programmering":
                    Console.WriteLine(rightanswer);
                    return;
                default:
                    Console.WriteLine(leifSur);
                    Console.WriteLine("Dit svar var forkert! Det må du lige læse lidt mere på.. + " +
                        "Du mister 1 hp, og dit selvværd");
                    hero.LoseHP(hero);
                    return;
            } 

        }
        public bool leifdefeated()
        {
            Program.hero.Coins += 50;           
            return true;

        }
    }
}
