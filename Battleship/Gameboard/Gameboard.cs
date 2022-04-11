using System.Text;

namespace BattleshipApplication.GameboardInitilizer
{
    public class Gameboard
    {
        private int boardSize;
        private int[,] board;
        public Gameboard(int boardSize)
        {    
            this.BoardSize = boardSize;
            this.board = new int[boardSize, boardSize];
        }

        public int[,] Board { get => board; set => board = value; }
        public int BoardSize { get => boardSize; set => boardSize = value; }

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    sb.Append(board[i, j] + " ");
                }

                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
