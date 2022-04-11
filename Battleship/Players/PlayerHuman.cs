using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public class PlayerHuman : PlayerBase
    {
        /*
         * Each player gets two gameboards. Player1 will have access to Player2:s board and vice versa.
         */

        public override void PlaceShip(int x, int y, int shipLength, bool horizontal)
        {
            if (horizontal && x + shipLength < Gameboard.BoardSize && x >= 0 && y >= 0 && y < Gameboard.BoardSize)
            {
                for (int i = x; i < x + shipLength; i++)
                {
                    Gameboard.Board[y, x + i] = 1;
                }
            }
            else if (!horizontal && y + shipLength < Gameboard.BoardSize && x >= 0 && y >= 0 && y < Gameboard.BoardSize)
            {
                for (int i = y; i < y + shipLength; i++)
                {
                    Gameboard.Board[y + i, x] = 1;
                }
            }
            else
            {
                //Console.WriteLine("Place your ship within the gameboard.");
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
