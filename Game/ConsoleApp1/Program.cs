namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Board board = new (10, 10);


            board.PlaceTerrian(2, 3,"land");
            board.PlaceTerrian(4, 5,"land");           
            board.Display();
            Position pos = new Position(5, 5);
            pos.MoveByKeyPress();


        }
    }
}
