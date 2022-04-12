using BattleshipApplication.Players;

namespace BattleshipApplication.Main
{
    public class Program
    {
        public static void Main(String[] args)
        {
            PlayerBase p1 = new PlayerHuman(new GameboardInitilizer.Gameboard(10), new GameboardInitilizer.Gameboard(10));

            //Console.WriteLine(p1.Gameboard.ToString());
            //Console.WriteLine("Provide coordinates x, y: ");
            //p1.PlaceShip(9, 9, 4, true);
            //Console.ReadLine();
        }

        
    }
    
}