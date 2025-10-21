namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TitleScreen title = new TitleScreen();
            int result = title.SelectOption();

            if (result == 0)
            {
                Console.WriteLine("Du har startet spillet " + title.Name);
            }
            else if (result == 1 || result == -1)
            {
                Console.WriteLine("Du har forladt spillet");
            }
        }
    }
}
