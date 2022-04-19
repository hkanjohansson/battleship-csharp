using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Players;
using BattleshipApplication.Ships;

namespace BattleshipApplication.GameLogic
{
    public class Game : IGameInterface
    {
        private int turn;
        private int p1Score;
        private int p2Score;
        private Player p1;
        private Player p2;
        private Gameboard gbP1;
        private Gameboard gbP2;
        public Game()
        {
            turn = 0;
            p1Score = 0;
            p2Score = 0;
            gbP1 = new Gameboard(10);
            gbP2 = new Gameboard(10);
            P1 = new PlayerHuman(gbP1, gbP2);
            P2 = new PlayerHuman(gbP2, gbP1);
        }

        public int Turn { get => turn; set => turn = value; }
        public int P1Score { get => p1Score; set => p1Score = value; }
        public int P2Score { get => p2Score; set => p2Score = value; }
        public Player P1 { get => p1; set => p1 = value; }
        public Player P2 { get => p2; set => p2 = value; }


        public void GameRunning()
        {
            /*
             * Keep track of game logic:
             * 
             * Init case: Initialize the game and let both players place their ships.
             * 
             * Running case: - Call PlayerTurn to see whose turn it is to fire
             *               - Call ShipHit to see if the opponents ship has been hit
             *               - Increase the turn field
             * 
             * End case: - If any of the players has no ships left, the game ends and a scoreboard is printed. 
             *           - Call ShutdownGame
             *         
             */

            /*
             * TODO - Refactor duplicated code into a separate method. 
             */
            while (P1.Ships.Count > 0)
            {
                Ship currentShip = P1.Ships.Dequeue();
                int[] coordinates = P1.ProvideCoordinates();
                int x = coordinates[0];
                int y = coordinates[1];

                Console.WriteLine("Do you want to place the ship horizontally? (write true for horizontal and false for vertical)");
                bool horizontal = Convert.ToBoolean(Console.ReadLine());
                bool validCoordinates = P1.IsWithin(x, y, currentShip.ShipLength) && P1.PlaceAble(x, y, currentShip.ShipLength);

                while (!validCoordinates)
                {
                    coordinates = P1.ProvideCoordinates();
                    x = coordinates[0];
                    y = coordinates[1];

                    Console.WriteLine("Do you want to place the ship horizontally? (write true for horizontal and false for vertical)");
                    horizontal = Convert.ToBoolean(Console.ReadLine());
                    validCoordinates = P1.IsWithin(x, y, currentShip.ShipLength) && P1.PlaceAble(x, y, currentShip.ShipLength);

                }

                P1.PlaceShip(x, y, currentShip.ShipLength, horizontal);
                Console.WriteLine(P1.Gameboard.ToString());
            }
        }
        public int PlayerTurn(int turn)
        {
            /*
             * (Argument % 2) to keep track of which players turn it is
             */
            throw new NotImplementedException();
        }

        public bool ShipHit()
        {
            /*
             * Check whether or not a ship has been hit on the fireboard --> If hit: mark with 1 else: mark with -1
             */
            throw new NotImplementedException();
        }

        public string ScoreBoard()
        {
            /*
             * Create a scoreboard that will be printed at the beginning of each turn.
             */
            throw new NotImplementedException();
        }

        public void ShutdownGame()
        {
            /*
             * If any of the player has no ships left or one of the player wants to quit --> end the game and print a last scoreboard.
             */
            throw new NotImplementedException();
        }
    }
}
