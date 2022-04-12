using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Players;
using BattleshipApplication.Ships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipTests.HelperMethods
{
    public class HelperMethodsForTests
    {
        public TestContext TestContext { get; set; }
        public int[] ShipLengths { get => shipLengths; set => shipLengths = value; }
        public Ship[] Ships { get => ships; set => ships = value; }
        public PlayerBase P1 = new PlayerHuman(new Gameboard(10), new Gameboard(10));
       

        int[] shipLengths = { 4, 5, 3, 2, 3 };

        Ship[] ships = { new Battleship(), new Carrier(), new Cruiser(), new Destroyer(), new Submarine() };
        
        
    }
}
