using BattleshipApplication.GameboardInitilizer;

namespace BattleshipApplication

{
    public static class GameRules
    {
        private static Gameboard gb = new(10);
        /*
         *  TODO - Place methods that has to do with checking rules here. Such as:
         *         * IsWithin
         *         * PlaceAble
         *         etc.
         */

        public static bool FireInside(int x, int y)
        {
            bool validX = x >= 0 && x < gb.BoardSize;
            bool validY = y >= 0 && y < gb.BoardSize;
            return validX && validY;

        }
    }
}
