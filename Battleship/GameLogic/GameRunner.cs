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

                //Console.WriteLine("Provide the x-coordinate: ");
                string inX = Console.ReadLine();
                //if (int.TryParse(inX, out int x))
                //{
                //    x = Convert.ToInt16(inX);
                //}


                //Console.WriteLine("Provide the y-coordinate: ");
                string inY = Console.ReadLine();
                //if (int.TryParse(inY, out int y))
                //{
                //    y = Convert.ToInt16(inY);
                //}

                //fired = true;

                int[] coordinates = GameRules.ParseCoordinates(inX, inY);
                int x = coordinates[0];
                int y = coordinates[1];
                if (!GameRules.FireAble(x, y, p.Fireboard.BoardSize, p.Fireboard))
                {
                    Console.WriteLine("Provide coordinates where you want to fire. The coordinates must be of integer type" +
                    "and x: 0-9, y: 0-9. Also you can't fire at the same spot more than once.");
                }
                else
                {

                    return PlayersFiring(p, x, y);
                }
            }

            throw new InvalidOperationException("Something went wrong.");
        }
        public static int[] PlayersFiring(Player p, int x, int y)
        {
            bool fireAble = GameRules.FireAble(x, y, p.Fireboard.BoardSize, p.Fireboard);
            return p.Fire(x, y, fireAble, p.Fireboard);
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
