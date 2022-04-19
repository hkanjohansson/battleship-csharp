using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public class PlayerHuman : Player
    {
        public PlayerHuman(Gameboard gb, Gameboard fb) : base()
        {
            gameboard = gb;
            fireboard = fb;
        }

        /*
         * TODO - Try if code works, else catch exeption
         */
        public override void PlaceShip(int x, int y, int shipLength, bool horizontal)
        {
            try
            {
                bool validCoordinates = IsWithin(x, y, shipLength);

                if (horizontal && validCoordinates)
                {
                    for (int i = x; i < x + shipLength; i++)
                    {
                        if (!AlreadyPlaced(x + i, y))
                            gameboard.Board[y, x + i] = 1;
                    }
                }
                else if (!horizontal && validCoordinates)
                {
                    try
                    {
                        for (int i = y; i < y + shipLength; i++)
                        {
                            if (!AlreadyPlaced(x, y + i))
                            {
                                gameboard.Board[y + i, x] = 1;
                            }
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Place your ship within the gameboard and on valid coordinates.");
                    throw new InvalidOperationException("Place your ship within the gameboard and on valid coordinates.");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public override void Fire()
        {
            bool fired = false;
            Console.WriteLine("Provide coordinates on where to fire: ");
            while (!fired)
            {
                Console.WriteLine("Provide the x-coordinate: ");
                int x = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Provide the y-coordinate: ");
                int y = Convert.ToInt16(Console.ReadLine());

                if (x < 0 || y < 0 || x >= Gameboard.BoardSize || y >= Gameboard.BoardSize)
                {
                    throw new ArgumentOutOfRangeException("Provide valid coordinates.");
                }
                else
                {
                    this.fireboard.Board[y, x] = 2;
                    fired = true;
                }
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
