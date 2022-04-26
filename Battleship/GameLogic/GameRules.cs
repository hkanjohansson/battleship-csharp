using BattleshipApplication.GameboardInitilizer;

namespace BattleshipApplication

{
    public static class GameRules
    {

        /*
         *  TODO - Place methods that has to do with checking rules here. Such as:
         *         * IsWithin
         *         * PlaceAble
         *         etc.
         */
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
    }
}
