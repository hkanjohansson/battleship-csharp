using System.Text;

namespace BattleshipApplication.GameboardInitilizer
{
    public class Gameboard
    {
        private int[,] board;
        public Gameboard(int boardSize)
        {    
            this.board = new int[boardSize, boardSize];
        }

        public int[,] Board { get => board; set => board = value; }

        public void PlaceShip(int x, int y, int shipLength)
        {   
            for (int i = x; i < shipLength + x; i++)
            {
                board[y, i] = 1;
            }
        }

        public string ToString()
        {

            StringBuilder sb = new StringBuilder();
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
