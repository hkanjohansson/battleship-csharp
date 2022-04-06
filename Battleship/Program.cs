using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Main
{
    public class Program
    {
        

        public static void Main(String[] args)
        {
            Gameboard board = new Gameboard(10);
            //board.PlaceShip(1, 1, 4);
            Carrier carrier = new Carrier();
            Cruiser cruiser = new Cruiser();
            Battleship battleship = new Battleship();
            
            Console.WriteLine(battleship.Health);
            Console.WriteLine(cruiser.Health);
            Console.WriteLine(carrier.Health);

            string game = board.ToString();
            Console.WriteLine(game);

            Console.ReadLine();
        }

        
    }
    
}