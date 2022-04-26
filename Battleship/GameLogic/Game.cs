using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Players;
using System.Text;

namespace BattleshipApplication.GameLogic
{
    public class Game : IGameInterface
    {
        private int turn;
        private int p1Score;
        private int p2Score;
        private Player? p1;
        private Player? p2;
        private readonly Gameboard gbP1;
        private readonly Gameboard gbP2;
        private readonly Gameboard fbP1;
        private readonly Gameboard fbP2;
        private bool gameRunning;
        public Game()
        {
            turn = 0;
            p1Score = 0;
            p2Score = 0;
            gbP1 = new Gameboard(10);
            gbP2 = new Gameboard(10);
            fbP1 = new Gameboard(10);
            fbP2 = new Gameboard(10);
            P1 = new PlayerHuman(gbP1, gbP2, fbP1);
            P2 = new PlayerHuman(gbP2, gbP1, fbP2);
            gameRunning = true;
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

            /*
             * TODO - Create a Main menu that gives the player a choice to play against another human player or an AI.
             *      - Print a summary of the rules of the game in the MainMenu.
             */


            Console.WriteLine("Welcome to Battleships! First, place your ships within the area that is x: 0-9 and y: 0-9. " +
                "The given coordinates must be of integer type.\n");

            Console.WriteLine("Player 1 placing:\n");
            GameInitializer.ShipPlacement(p1);

            Console.WriteLine("Player 2 placing:\n");
            GameInitializer.ShipPlacement(p2);

            Console.WriteLine("Lets get started");

            while (gameRunning)
            {
                Console.WriteLine("Provide coordinates where you want to fire.\n\nThe coordinates must be of integer type" +
                    "and x: 0-9, y: 0-9. Also you can't fire at the same spot more than once.");

                /*
                 * This is where the game runs:
                 * 
                 * TODO - Refactor the following code that is repetetive.
                 */
                int[] coordinatesFiredAt;
                Console.WriteLine($"Player {PlayerTurn(turn) + 1}:s turn to fire:\n");
                if (PlayerTurn(turn) == 0)
                {
                    coordinatesFiredAt = GameRunner.FireInput(p1);
                    if (ShipHit(p1, coordinatesFiredAt[0], coordinatesFiredAt[1]))
                    {
                        Console.WriteLine("Ship hit!");
                        p2.Health--;
                        p1Score++;
                        p1.Fireboard.Board[coordinatesFiredAt[1], coordinatesFiredAt[0]] = 4;
                    }
                    else
                    {
                        Console.WriteLine("Miss!");
                        p1.Fireboard.Board[coordinatesFiredAt[1], coordinatesFiredAt[0]] = 3;
                    }
                    Console.WriteLine(GameRunner.PlayerUI(p1));
                }
                else if (PlayerTurn(turn) == 1)
                {
                    coordinatesFiredAt = GameRunner.FireInput(p2);
                    if (ShipHit(p2, coordinatesFiredAt[0], coordinatesFiredAt[1]))
                    {
                        Console.WriteLine("Ship hit!");
                        p1.Health--;
                        p2Score++;
                        p2.Fireboard.Board[coordinatesFiredAt[1], coordinatesFiredAt[0]] = 4;
                    }
                    else
                    {
                        Console.WriteLine("Miss!");
                        p2.Fireboard.Board[coordinatesFiredAt[1], coordinatesFiredAt[0]] = 3;
                    }

                    Console.WriteLine(GameRunner.PlayerUI(p2));
                }

                Console.WriteLine(ScoreBoard());
                turn++;

                if (p1.Health <= 0 || p2.Health <= 0)
                {
                    ShutdownGame();
                }
            }


        }
        public int PlayerTurn(int turn)
        {
            return turn % 2;
        }
        public bool ShipHit(Player p, int x, int y)
        {
            return p.OppBoard.Board[y, x] == 1 && p.Fireboard.Board[y, x] == 2;
        }

        public string ScoreBoard()
        {
            StringBuilder sb = new();
            sb.AppendLine("Player 1: " + p1Score + " points");
            sb.AppendLine("Player 2: " + p2Score + " points");
            return sb.ToString();
        }

        public void ShutdownGame()
        {
            /*
             * If any of the player has no ships left or one of the player wants to quit --> end the game and print a last scoreboard.
             */
            gameRunning = false;
            Console.WriteLine("The game has come to an end. This is the final score:\n" + ScoreBoard());
        }
    }
}
