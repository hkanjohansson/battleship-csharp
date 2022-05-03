using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Players;
using System.Text;

namespace BattleshipApplication.GameLogic
{
    public class Game : IGameInterface
    {
        private int turn;
        private readonly Gameboard gbP1;
        private readonly Gameboard gbP2;
        private readonly Gameboard fbP1;
        private readonly Gameboard fbP2;
        private readonly string options;
        private readonly int validOption;
        private Player? p1;
        private Player? p2;
        private bool gameRunning;

        /*
         * TODO - Refactor the constructor?
         */
        public Game()
        {
            turn = 0;
            gbP1 = new Gameboard(10);
            gbP2 = new Gameboard(10);
            fbP1 = new Gameboard(10);
            fbP2 = new Gameboard(10);

            GameInitializer.MainMenu();
            options = Console.ReadLine();
            while (!int.TryParse(options, out validOption))
            {
                Console.WriteLine("Please provide a valid option");
                options = Console.ReadLine();
            }

            if (validOption == 1)
            {
                p1 = new PlayerHuman(gbP1, gbP2, fbP1);
                p2 = new PlayerHuman(gbP2, gbP1, fbP2);
            }
            else if (validOption == 2)
            {
                p1 = new PlayerHuman(gbP1, gbP2, fbP1);
                p2 = new PlayerAI(gbP2, gbP1, fbP2);
            }
            else if (validOption == 3)
            {
                p1 = new PlayerAI(gbP1, gbP2, fbP1);
                p2 = new PlayerAI(gbP2, gbP1, fbP2);

            }

            gameRunning = true;
        }

        public int Turn { get => turn; set => turn = value; }
        public Player? P1 { get => p1; set => p1 = value; }
        public Player? P2 { get => p2; set => p2 = value; }


        public void GameRunning()
        {
            /*
             * Keep track of game logic:
             * 
             * Init case: - Initialize the game and let both players place their ships.
             * 
             * Running case: - Call PlayerTurn to see whose turn it is to fire
             *               - Call ShipHit to see if the opponents ship has been hit
             *               - Increase the turn field
             * 
             * End case: - If any of the players has no ships left, the game ends and a scoreboard is printed.      
             */

            Console.WriteLine("Player 1 placing:\n");
            GameInitializer.ShipPlacement(p1, validOption == 3);

            Console.WriteLine("Player 2 placing:\n");
            GameInitializer.ShipPlacement(p2, validOption == 2 || validOption == 3);

            Console.WriteLine("Lets get started!");

            while (gameRunning)
            {
                Console.WriteLine("Provide coordinates where you want to fire.\n\nThe coordinates must be of integer type" +
                    " and x: 0-9, y: 0-9. Also you can't fire at the same spot more than once.");

                /*
                 * 
                 * TODO - Refactor the following code that is repetetive.
                 */
                int playerToFire = GameRunner.PlayerTurn(turn);
                if (playerToFire == 0)
                {
                    Console.WriteLine($"Player {playerToFire + 1}:s turn to fire:\n");
                    int[] coordinatesFiredAt;
                    coordinatesFiredAt = GameRunner.FireInput(p1);

                    bool oppShipHit = GameRules.OpponentShipHit(p1, coordinatesFiredAt);
                    GameRunner.
                        GameMechanics(
                        p1,
                        coordinatesFiredAt[0],
                        coordinatesFiredAt[1],
                        oppShipHit);

                    if (oppShipHit)
                    {
                        GameHitMechanics(p1, p2, coordinatesFiredAt, oppShipHit);
                    }
                    //else if (!oppShipHit && validOption == 3)
                    //{
                    //    AIMissMechanics(p1, coordinatesFiredAt, oppShipHit);
                    //}
                }
                else if (GameRunner.PlayerTurn(turn) == 1)
                {
                    Console.WriteLine($"Player {GameRunner.PlayerTurn(turn) + 1}:s turn to fire:\n");

                    int[] coordinatesFiredAt;
                    coordinatesFiredAt = GameRunner.FireInput(p2);
                    bool oppShipHit = GameRules.OpponentShipHit(p2, coordinatesFiredAt);
                    /*
                     * TODO - Rename GameMechanics into something more descriptive.
                     */
                    GameRunner.
                        GameMechanics(
                        p2,
                        coordinatesFiredAt[0],
                        coordinatesFiredAt[1],
                        GameRunner.ShipHit(p2,
                        coordinatesFiredAt[0],
                        coordinatesFiredAt[1]));

                    if (oppShipHit)
                    {
                        GameHitMechanics(p2, p1, coordinatesFiredAt, oppShipHit);
                    }
                    //else if (!oppShipHit && validOption == 2 || validOption == 3)
                    //{
                    //    AIMissMechanics(p2, coordinatesFiredAt, oppShipHit);
                    //}

                }

                turn++;

                if (p1.Health <= 0 || p2.Health <= 0)
                {
                    ShutdownGame();
                }
            }
        }

        private static void GameHitMechanics(Player player, Player oppPlayer, int[] coordinatesFiredAt, bool oppShipHit)
        {
            if (oppShipHit)
            {
                oppPlayer.Health--;
                player.NHits++;
                player.HitsCoordinates.Add(coordinatesFiredAt);
            }

        }

        public static void AIMissMechanics(Player player, int[] coordinatesFiredAt, bool oppShipHit)
        {
            if (!oppShipHit && player.NHits >= 2)
            {
                player.MissesAfterSecondHit++;
                player.MissAfterHitCoordinates.Add(coordinatesFiredAt);
            }
            if (player.NHits >= 2 && !oppShipHit && player.MissesAfterSecondHit >= 2)
            {
                player.NHits = 0;
                player.MissesAfterSecondHit = 0;
                player.HitsCoordinates.Clear();
                player.MissAfterHitCoordinates.Clear();
            }
        }

        public string ScoreBoard()
        {
            StringBuilder sb = new();
            sb.AppendLine("Player 1: " + p1.Score + " points");
            sb.AppendLine("Player 2: " + p2.Score + " points");
            return sb.ToString();
        }

        public void ShutdownGame()
        {
            /*
             * If any of the player has no ships left: - End the game and print a last scoreboard.
             */
            gameRunning = false;
            Console.WriteLine("The game has come to an end. This is the final score:\n" + ScoreBoard());
        }
    }
}
