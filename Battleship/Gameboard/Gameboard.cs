namespace Battleship.Gameboard
{
    public class Gameboard
    {
        private int boardSize;
        private char[][] ?board;

        public int BoardSize { get => boardSize; set => boardSize = value; }
        public char[][] Board { get => board; set => board = value; }
    }
}
