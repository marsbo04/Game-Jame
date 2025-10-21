using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DragonLeif
    {
        string symbol;
        Position position;



        public DragonLeif(Position pos)
        {
            this.symbol = "🐲";
            this.position = pos;
        } 

        public string LeifAsks()
        {
            Random rand = new Random();
            string[] questions = ["Hvor gammel er jeg? ", "Hvad underviser jeg i? "];

            int questionindex = rand.Next(questions.Length);
            return questions[questionindex];
        } 

        public void AnswerLeif(string leifquestion)
        {
            string rightanswer = "Nice tillykke du har svaret rigtigt!";
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
                    throw new Exception("Dit svar var forkert!");
            } 

        }
    }
}
