namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Board board = new (10, 10);

            board.PlaceTerrian(2, 3,"land");
            board.PlaceTerrian(4, 5,"land");
            board.PlacePiece(2, 2, "⛵");
            board.Display();

        }
    }
}
