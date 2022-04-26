using BattleshipApplication.GameboardInitilizer;

namespace BattleshipApplication.Players
{
    public class PlayerAI : Player
    {
        private int missesAfterHit;

        public PlayerAI(Gameboard gb, Gameboard ob, Gameboard fb) : base()
        {
            gameboard = gb;
            oppBoard = ob;
            fireboard = fb;
        }

        public int MissesAfterHit { get => missesAfterHit; set => missesAfterHit = value; }
        public override int[] ProvideCoordinates()
        {
            Random random = new();
            int x = random.Next(0, gameboard.BoardSize);
            int y = random.Next(0, gameboard.BoardSize);

            int[] coordinates = { x, y };
            return coordinates;
        }

        public int[] FireInit()
        {

            return new int[2];
        }
        
        public int[] FireNext()
        {
            int[] coordinates = new int[2];
            return coordinates;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        
    }
}
