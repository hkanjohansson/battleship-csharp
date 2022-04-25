using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    /*
     * TODO - Move methods that has to do with rules to GameLogic.GameRules
     */
    public abstract class Player
    {
        protected Gameboard gameboard;
        protected Gameboard oppBoard;
        protected Gameboard fireboard;
        private Queue<Ship> ships;

        public Player()
        {
            gameboard = new Gameboard(10);
            OppBoard = new Gameboard(10);
            fireboard = new Gameboard(10);
            ships = new();
            BagOfShipsInit();
        }

        public Gameboard Gameboard { get => gameboard; set => gameboard = value; }
        public Gameboard OppBoard { get => oppBoard; set => oppBoard = value; }
        public Gameboard Fireboard { get => fireboard; set => fireboard = value; }
        public Queue<Ship> Ships { get => ships; set => ships = value; }
        

        private void BagOfShipsInit()
        {
            Ships.Enqueue(new Battleship());
            Ships.Enqueue(new Carrier());
            Ships.Enqueue(new Cruiser());
            Ships.Enqueue(new Destroyer());
            Ships.Enqueue(new Submarine());
        }

        public abstract int[] ProvideCoordinates();
        public abstract void PlaceShip(int x, int y, int shipLength, bool horizontal);
        public bool IsWithin(int x, int y, int shipLength)
        {
            bool withinHori = x + shipLength < gameboard.BoardSize && x >= 0 && y >= 0;
            bool withinVert = y + shipLength < gameboard.BoardSize && x >= 0 && y >= 0;

            if (withinHori && withinVert)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PlaceAble(int x, int y, int shipLength)
        {
            bool within = IsWithin(x, y, shipLength);
            if (within)
            {
                for (int i = x; i < x - 1 + shipLength; i++)
                {
                    if (gameboard.Board[y, i] != 0)
                    {
                        return false;
                    }
                }

                for (int i = y; i < y + shipLength; i++)
                {
                    if (gameboard.Board[i, x] != 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            throw new InvalidOperationException("Ship is not placeable.");
        }


        public abstract int[] Fire(int x, int y, bool fireAble, Gameboard fb);
        public abstract override string ToString();
    }
}
