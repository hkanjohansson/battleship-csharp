using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public abstract class Player
    {
        protected Gameboard gameboard;
        protected Gameboard oppBoard;
        protected Gameboard fireboard;
        private Queue<Ship> ships;
        protected int health;
        protected int nHits;
        private int score;
        protected int missesAfterSecondHit;
        protected List<int[]> hitsCoordinates;
        protected List<int[]> missAfterHitCoordinates;

        public Player()
        {
            gameboard = new Gameboard(10);
            OppBoard = new Gameboard(10);
            fireboard = new Gameboard(10);
            ships = new();
            BagOfShipsInit();
            HealthInit();
            
            missesAfterSecondHit = 0;
            hitsCoordinates = new List<int[]>();
            missAfterHitCoordinates = new List<int[]>();
            score = 0;
        }

        

        public Gameboard Gameboard { get => gameboard; set => gameboard = value; }
        public Gameboard OppBoard { get => oppBoard; set => oppBoard = value; }
        public Gameboard Fireboard { get => fireboard; set => fireboard = value; }
        public Queue<Ship> Ships { get => ships; set => ships = value; }
        public int Health { get => health; set => health = value; }
        public int Score { get => score; set => score = value; }
        public int NHits { get => nHits; set => nHits = value; }
        public int MissesAfterSecondHit { get => missesAfterSecondHit; set => missesAfterSecondHit = value; }
        public List<int[]> HitsCoordinates { get => hitsCoordinates; set => hitsCoordinates = value; }
        public List<int[]> MissAfterHitCoordinates { get => missAfterHitCoordinates; set => missAfterHitCoordinates = value; }
        
        /*
         * TODO - Refactor methods that has to do with initialization into another class
         */
        private void BagOfShipsInit()
        {
            Ships.Enqueue(new Battleship());
            Ships.Enqueue(new Carrier());
            Ships.Enqueue(new Cruiser());
            Ships.Enqueue(new Destroyer());
            Ships.Enqueue(new Submarine());
        }

        private void HealthInit()
        {
            health = 0;
            foreach (Ship s in ships)
            {
                health += s.ShipLength;
            }
        }
        public abstract int[] ProvideCoordinates();
        public void PlaceShip(int x, int y, int shipLength, bool horizontal)
        {
            /*
             * Checks for valid coordinates are done in the Game class. That is because a player 
             * should only follow the rules set by the game and not itself implement them.
             */
            if (horizontal)
            {
                for (int i = x; i < x + shipLength; i++)
                {
                    gameboard.Board[y, i] = 1;
                }
                Console.WriteLine($"Ship has been placed on ({x}-{x + shipLength - 1}, {y})");
            }
            else if (!horizontal)
            {
                for (int i = y; i < y + shipLength; i++)
                {
                    gameboard.Board[i, x] = 1;
                }
                Console.WriteLine($"\nShip has been placed on ({x}, {y} - {y + shipLength - 1})");
            }
        }
        

        public static int[] Fire(int x, int y, bool fireAble, Gameboard fb)
        {
            Console.WriteLine("Provide coordinates on where to fire: ");

            if (fireAble)
            {
                fb.Board[y, x] = 2;
            }
            else
            {
                throw new InvalidOperationException("You have to fire inside the valid area (0-9, 0-9)");
            }

            int[] coordinates = { x, y };
            return coordinates;
        }
        public abstract string ToString();
    }
}
