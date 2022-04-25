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

        public static bool FireAble(int x, int y, int boardSize, Gameboard fireBoard)
        {
            bool validX = x >= 0 && x < boardSize;
            bool validY = y >= 0 && y < boardSize;
            bool alreadyFired = fireBoard.Board[y, x] == 2;
            return validX && validY && !alreadyFired;
        }
    }
}
