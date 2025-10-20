namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Board board = new(10, 10);

            board.PlaceTerrian(2, 2, "land");
            board.PlaceTerrian(2, 3, "land");
            board.PlaceTerrian(3, 2, "land");
            board.PlaceTerrian(3, 3, "land");

            board.PlaceTerrian(7, 5, "land");
            board.PlaceTerrian(8, 5, "land");
            board.PlaceTerrian(8, 6, "land");
            board.PlaceTerrian(6, 6, "land");
            board.PlaceTerrian(6, 7, "land");
            board.PlaceTerrian(7, 6, "land");
            board.PlaceTerrian(7, 7, "land");
            board.Display();

        }
    }
}
