using BattleshipApplication.Players;
using System.Text;

namespace BattleshipApplication.GameLogic
{
    public static class GameRunner
    {
        public static int[] FireInput(Player p)
        {
            bool fired = false;

            while (!fired)
            {

                Console.WriteLine("Provide the x-coordinate: ");
                int x = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Provide the y-coordinate: ");
                int y = Convert.ToInt16(Console.ReadLine());

                if (!GameRules.FireAble(x, y, p.Fireboard.BoardSize, p.Fireboard))
                {
                    Console.WriteLine("Provide valid coordinates.");
                }
                else
                {
                    fired = true;
                    return PlayersFiring(p, x, y);
                }
            }

            throw new InvalidOperationException("Something went wrong.");
        }
        public static int[] PlayersFiring(Player p, int x, int y)
        {
                bool fireAble = GameRules.FireAble(x, y, p.Fireboard.BoardSize, p.Fireboard);
                return p.Fire(x, y, fireAble, p.Fireboard);
        
                throw new ArgumentException("Something has gone wrong with the PlayerTurn method.");
        }


        public static void PlayerUI(Player pGameboard, Player pFireboard, bool shipHit, int turn)
        {
            /*
             * Prints a User Interface at the beginning of everyturn.
             */
            StringBuilder sb = new();
            sb.Append("Your ships:\n\n");
            sb.Append(pGameboard.Gameboard.ToString());
            sb.Append("Your area to fire at:\n\n");

            if (turn <= 1)
            {
                for (int i = 0; i < pFireboard.Gameboard.BoardSize; i++)
                {
                    for (int j = 0; j < pFireboard.Gameboard.BoardSize; j++)
                    {
                        sb.Append(pFireboard.Gameboard.Board[j, i] + ' ');
                    }

                    sb.Append('\n');
                }
            }
            else
            {
                /* 
                 * This should only care about if a ship has been hit
                 */
                if (shipHit)
                {
                    sb.Append("H ");
                }
                else
                {
                    sb.Append("M ");
                }

                sb.Append('\n');
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
