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
        private Player? p1;
        private Player? p2;
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
        public Player? P1 { get => p1; set => p1 = value; }
        public Player? P2 { get => p2; set => p2 = value; }


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
            GameInitializer.ShipPlacement(p1);
            GameInitializer.ShipPlacement(p2);
            Console.WriteLine("Lets get started");

            while (true)
            {
                /*
                 * This is where the game runs:
                 * 
                 * TODO - 1) Check player turn
                 *        2) FireInput
                 *        3) Check if a ship has been hit
                 *        4) Increase turn field
                 */
                int[] coordinatesFiredAt;
                if (PlayerTurn(turn) == 0)
                {
                    coordinatesFiredAt = GameRunner.FireInput(p1);
                    if (ShipHit(p1, coordinatesFiredAt[0], coordinatesFiredAt[1]))
                    {
                        p1Score++;
                    }
                } else if (PlayerTurn(turn) == 1)
                {
                    coordinatesFiredAt = GameRunner.FireInput(p2);
                    if (ShipHit(p2, coordinatesFiredAt[0], coordinatesFiredAt[1]))
                    {
                        p2Score++;
                    }
                }

                turn++;
            }
            
            //GameRunner.PlayerUI(p1, p2, ShipHit(), turn);
        }
        public int PlayerTurn(int turn)
        {
            return turn % 2;
        }
        public bool ShipHit(Player p, int x, int y)
        {
            /*
             * Check whether or not a ship has been hit on the fireboard
             */
            return p.Gameboard.Board[y, x] == 2;
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
