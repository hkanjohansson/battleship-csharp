using BattleshipApplication.GameLogic;

namespace BattleshipApplication.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.GameRunning();
            //Player p1 = new PlayerHuman(new GameboardInitilizer.Gameboard(10), new GameboardInitilizer.Gameboard(10));
            //p1.PlaceShip(1, 1, 5, true);
            //p1.Fire();
            ////Console.WriteLine(p1.Gameboard.ToString());
            //Console.WriteLine("Provide coordinates x, y: ");
            //p1.PlaceShip(9, 9, 4, true);
            //Console.ReadLine();
        }

        
    }
    
}