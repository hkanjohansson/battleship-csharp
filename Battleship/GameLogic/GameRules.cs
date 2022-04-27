using BattleshipApplication.GameboardInitilizer;

namespace BattleshipApplication

{
    public static class GameRules
    {
        static readonly Gameboard gb = new(10);
        public static bool ParseableInput(string inX, string inY)
        {
            return int.TryParse(inX, out _) && int.TryParse(inY, out _);
        }

        public static int[] ParseCoordinates(string inX, string inY)
        {
            while (!ParseableInput(inX, inY))
            {
                Console.WriteLine("\nCoordinates must be of integer type!\n");
                Console.WriteLine("\nProvide the x-coordinate: ");
                inX = Console.ReadLine();

                Console.WriteLine("\nProvide the y-coordinate: ");
                inY = Console.ReadLine();
            }

            int x = Convert.ToInt16(inX);
            int y = Convert.ToInt16(inY);
            int[] coordinates = { x, y };

            return coordinates;
        }
        public static bool FireAble(int x, int y, int boardSize, Gameboard fireBoard)
        {

            bool validX = x >= 0 && x < boardSize;
            bool validY = y >= 0 && y < boardSize;
            if (!validX || !validY)
            {
                return false;
            }

            bool alreadyFired = fireBoard.Board[y, x] == 2;
            if (alreadyFired)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsWithin(int x, int y, int shipLength)
        {
            bool withinHori = x + shipLength < gb.BoardSize && x >= 0 && y >= 0;
            bool withinVert = y + shipLength < gb.BoardSize && x >= 0 && y >= 0;

            if (withinHori && withinVert)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool PlaceAble(int x, int y, int shipLength, bool horizontal)
        {
            bool within = IsWithin(x, y, shipLength);
            if (within)
            {
                if (horizontal)
                {
                    for (int i = x; i < x + shipLength; i++)
                    {
                        if (gb.Board[y, i] != 0)
                        {
                            return false;
                        }
                    }
                }

                if (!horizontal)
                {
                    for (int i = y; i < y + shipLength; i++)
                    {
                        if (gb.Board[i, x] != 0)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            throw new InvalidOperationException("Ship is not placeable.");
        }
    }
}
