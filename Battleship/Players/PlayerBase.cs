using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public abstract class PlayerBase
    {
        protected Gameboard gameboard;
        protected Ship[] ships;

        public PlayerBase()
        {
            this.Gameboard = new Gameboard(10);
            this.Ships = new Ship[5];
            BagOfShipsInit();
        }

        public Gameboard Gameboard { get; set; }
        public Ship[] Ships { get; set; }

        private void BagOfShipsInit()
        {
            Ships[0] = new Battleship();
            Ships[1] = new Carrier();
            Ships[2] = new Cruiser();
            Ships[3] = new Destroyer();
            Ships[4] = new Submarine();
        }

        public abstract void PlaceShip(int x, int y, int shipLength, bool horizontal);
        public abstract override string ToString();
    }
}
