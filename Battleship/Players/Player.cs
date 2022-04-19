using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;
using System.Collections;

namespace BattleshipApplication.Players
{
    public abstract class Player
    {
        protected Gameboard gameboard;
        protected Gameboard fireboard;
        private Queue<Ship> ships;
        private int shipsLeft;

        public Player()
        {
            gameboard = new Gameboard(10);
            fireboard = new Gameboard(10);
            ships = new();
            ShipsLeft = Ships.Count;
            BagOfShipsInit();
        }

        public Gameboard Gameboard { get => gameboard; set => gameboard = value; }
        public Gameboard Fireboard { get => fireboard; set => fireboard = value; }
        public int ShipsLeft { get => ships.Count; set => shipsLeft = value; }
        public Queue<Ship> Ships { get => ships; set => ships = value; }

        private void BagOfShipsInit()
        {
            Ships.Enqueue(new Battleship());
            Ships.Enqueue(new Carrier());
            Ships.Enqueue(new Cruiser());
            Ships.Enqueue(new Destroyer());
            Ships.Enqueue(new Submarine());
        }

        public abstract void PlaceShip(int x, int y, int shipLength, bool horizontal);
        public bool IsWithin(int x, int y, int shipLength)
        {
            bool withinHori = x + shipLength < gameboard.BoardSize && x >= 0 && y >= 0 && y < gameboard.BoardSize;
            bool withinVert = y + shipLength < gameboard.BoardSize && x >= 0 && y >= 0 && x < gameboard.BoardSize;

            if (withinHori && withinVert)
            {
                return true;
            }
            else
            {
                throw new IndexOutOfRangeException("Try placing your ship within the gameboard.");
            }
        }

        public bool AlreadyPlaced(int x, int y)
        {
            return gameboard.Board[y, x] == 0 ? true : throw new InvalidOperationException("Ship has already been placed here.");
        }
        public abstract void Fire();
        public abstract override string ToString();
    }
}
