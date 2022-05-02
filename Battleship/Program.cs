using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.GameLogic;
using BattleshipApplication.Players;

namespace BattleshipApplication.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new();
            game.GameRunning();

        }

        
    }
    
}