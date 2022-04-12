using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public class PlayerHuman : PlayerBase
    {

        public PlayerHuman(Gameboard gb, Gameboard fb) : base(gb, fb)
        {
            Console.WriteLine("Player human is created.");
        }

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
                Console.WriteLine("Place your ship within the gameboard.");
                throw new ArgumentOutOfRangeException();
            }
        }

        public override void Fire(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
