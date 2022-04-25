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


        public static string PlayerUI(Player p)
        {
            /*
             * Prints a User Interface at the beginning of every turn.
             */
            StringBuilder sb = new();
            for (int i = 0; i < 10; i++)
            {
                sb.Append("{ ");
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(' ' + p.Gameboard.Board[i, j].ToString() + ' ');
                }
                sb.Append(" || ");

                for (int j = 0; j < 10; j++)
                {
                    /*
                     * TODO - Integrate ShipHit
                     */
                    if (p.Fireboard.Board[i, j] == 4)
                    {
                        sb.Append(" H ");
                    } else if (p.Fireboard.Board[i, j] == 3)
                    {
                        sb.Append(" X ");
                    } else
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
