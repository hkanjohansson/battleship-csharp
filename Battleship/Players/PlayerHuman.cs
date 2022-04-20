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

        public override int[] ProvideCoordinates()
        {
            Console.WriteLine("Provide the x-coordinate: ");
            int x = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Provide the y-coordinate: ");
            int y = Convert.ToInt16(Console.ReadLine());

            int[] coordinates = { x, y };
            return coordinates;
        }
        public override void PlaceShip(int x, int y, int shipLength, bool horizontal)
        {
            /*
             * Checks for valid coordinates are done in the Game class. That is because a player 
             * should only follow the rules set by the game and not itself implement them.
             */
            if (horizontal)
            {
                for (int i = x; i < x + shipLength; i++)
                {
                    gameboard.Board[y, i] = 1;
                }
                Console.WriteLine($"Ship has been placed on ({x}-{x + shipLength - 1}, {y})");
            }
            else if (!horizontal)
            {
                for (int i = y; i < y + shipLength; i++)
                {
                    gameboard.Board[i, x] = 1;
                }
                Console.WriteLine($"\nShip has been placed on ({x}, {y} - {y + shipLength - 1})");
            }
        }

        public override int[] Fire(int optX = 4, int optY = 4, bool toTest = false)
        {
            /*
             * Returns coordinates where a shot has been fired. These
             * coordinates are then used in ShipHit and UserInterface 
             * methods.
             */

            /*
             * TODO - Rewrite method to look like PlaceShip ---> Then it is testable.
             *      - Move code that takes input to the GameRunner class.
             */
            int x = optX;
            int y = optY;
            bool fired = false;
            Console.WriteLine("Provide coordinates on where to fire: ");

            if (toTest && FireAble(x, y))
            {
                fireboard.Board[y, x] = 2;
                int[] testCoordinates = { x, y };
                return testCoordinates;
                
            }
            while (!fired)
            {
                try
                {
                    Console.WriteLine("Provide the x-coordinate: ");
                    x = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Provide the y-coordinate: ");
                    y = Convert.ToInt16(Console.ReadLine());

                    if (x < 0 || y < 0 || x >= Gameboard.BoardSize || y >= Gameboard.BoardSize)
                    {
                        Console.WriteLine("Provide valid coordinates.");
                    }
                    else
                    {
                        fireboard.Board[y, x] = 2;
                        fired = true;
                    }

                } catch {
                    Console.WriteLine("Input must be of type: Integer.");
                }   
            }

            int[] coordinates = { x, y };
            return coordinates;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
