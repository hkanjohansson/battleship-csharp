using BattleshipApplication.Players;
using System.Text;

namespace BattleshipApplication.GameLogic
{
    public static class GameRunner
    {

        public static void PlayerUI(Player pGameboard, Player pFireboard, bool shipHit, int turn)
        {
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
                        sb.Append(0 + ' ');
                    }

                    sb.Append('\n');
                }
                
            }
            else
            {
                /*
                 * TODO - How to keep track of coordinates??
                 * 
                 * This should only care about if a ship has been hit
                 */ 
                if (pFireboard.Gameboard.Board[i, j] != 0)
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
