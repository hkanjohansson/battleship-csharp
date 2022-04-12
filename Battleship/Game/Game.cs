using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Players;

namespace BattleshipApplication.Game
{
    public class Game : IGameInterface
    {
        private int turn;
        private int p1Score;
        private int p2Score;
        private PlayerBase p1;
        private PlayerBase p2;
        private Gameboard gbP1;
        private Gameboard gbP2;
        public Game()
        {
            this.turn = 0;
            this.p1Score = 0;
            this.p2Score = 0;
            this.gbP1 = new Gameboard(10);
            this.gbP2 = new Gameboard(10);
            this.P1 = new PlayerHuman(gbP1, gbP2);
            this.P2 = new PlayerHuman(gbP2, gbP1);
        }

        public int Turn { get => turn; set => turn = value; }
        public int P1Score { get => p1Score; set => p1Score = value; }
        public int P2Score { get => p2Score; set => p2Score = value; }
        public PlayerBase P1 { get => p1; set => p1 = value; }
        public PlayerBase P2 { get => p2; set => p2 = value; }
        

        public void GameRunning()
        {
            /*
             * Keep track of game logic
             */
            throw new NotImplementedException();
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
