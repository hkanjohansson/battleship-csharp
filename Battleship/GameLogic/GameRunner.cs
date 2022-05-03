using BattleshipApplication.Players;
using System.Text;

namespace BattleshipApplication.GameLogic
{
    public static class GameRunner
    {
        /*
         * TODO - Rename this  method into something more relevant.
         */
        public static void GameMechanics(Player p, int x, int y, bool shipHit)
        {
            if (shipHit)
            {
                Console.WriteLine("Ship hit!");
                p.Score++;
                p.Fireboard.Board[y, x] = 4;
            }
            else
            {
                Console.WriteLine("Miss!");
                p.Fireboard.Board[y, x] = 3;
            }
            Console.WriteLine(PlayerUI(p));
        }

        public static int[] FireInput(Player p)
        {
            bool fired = false;

            while (!fired)
            {
                int[] coordinates = p.ProvideCoordinates();
                int x = coordinates[0];
                int y = coordinates[1];
                if (!GameRules.FireAble(x, y, p.Fireboard.BoardSize, p.Fireboard))

                {
                    Console.WriteLine("Provide coordinates where you want to fire.\n\nThe coordinates must be of integer type" +
                    "and x: 0-9, y: 0-9. Also you can't fire at the same spot more than once.");
                }
                else
                {
                    return PlayersFiring(p, x, y);
                }
            }

            throw new InvalidOperationException("Something went wrong.");
        }

        /*
         * TODO - Either refactor the code so this method is removed, or reason why it is needed when writing the documentation. 
         */
        public static int[] PlayersFiring(Player p, int x, int y)
        {
            bool fireAble = GameRules.FireAble(x, y, p.Fireboard.BoardSize, p.Fireboard);
            return Player.Fire(x, y, fireAble, p.Fireboard);
        }

        public static int PlayerTurn(int turn)
        {
            return turn % 2;
        }
        public static bool ShipHit(Player p, int x, int y)
        {
            return p.OppBoard.Board[y, x] == 1 && p.Fireboard.Board[y, x] == 2;
        }


        public static string PlayerUI(Player p)
        {
            /*
             * Prints a User Interface at the beginning of every turn.
             */
            StringBuilder sb = new();
            for (int i = 0; i < p.Gameboard.BoardSize; i++)
            {
                sb.Append("{ ");
                for (int j = 0; j < p.Gameboard.BoardSize; j++)
                {
                    sb.Append(' ' + p.Gameboard.Board[i, j].ToString() + ' ');
                }
                sb.Append(" || ");

                for (int j = 0; j < p.Gameboard.BoardSize; j++)
                {
                    /*
                     * 3 and 4 are just values chosen to have something to compare with.
                     */
                    if (p.Fireboard.Board[i, j] == 4)
                    {
                        sb.Append(" H ");
                    }
                    else if (p.Fireboard.Board[i, j] == 3)
                    {
                        sb.Append(" X ");
                    }
                    else
                    {
                        sb.Append(" 0 ");
                    }
                }

                sb.Append("}\n");
            }

            return sb.ToString();
        }
    }
}
