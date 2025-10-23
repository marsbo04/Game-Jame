namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            var mower = new LawnMower();

            Start(car);
            Start(mower);

        }

        static void Start(IMachine Machine)
        {
            Machine.Start();
        }
    }
}
