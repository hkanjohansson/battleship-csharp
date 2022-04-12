using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public abstract class PlayerBase
    {
        protected Gameboard gameboard;
        protected Gameboard fireboard;
        protected Ship[] ships;
        private int shipsLeft;
        public PlayerBase(Gameboard gb, Gameboard fb)
        {
            Gameboard = gb;
            Fireboard = fb;
            Ships = new Ship[5];
            ShipsLeft = Ships.Length;
            BagOfShipsInit();
        }

        public Ship[] Ships { get => ships; set => ships = value; }
        public Gameboard Gameboard { get => gameboard; set => gameboard = value; }
        public Gameboard Fireboard { get => fireboard; set => fireboard = value; }
        public int ShipsLeft { get => shipsLeft; set => shipsLeft = value; }

        private void BagOfShipsInit()
        {
            Ships[0] = new Battleship();
            Ships[1] = new Carrier();
            Ships[2] = new Cruiser();
            Ships[3] = new Destroyer();
            Ships[4] = new Submarine();
        }

        public abstract void PlaceShip(int x, int y, int shipLength, bool horizontal);
        public abstract void Fire(int x, int y);
        public abstract override string ToString();
    }
}
