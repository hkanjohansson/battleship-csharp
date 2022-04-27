using BattleshipApplication.GameboardInitilizer;

namespace BattleshipApplication.Players
{
    public class PlayerAI : Player
    {
        private int missesAfterSecondHit;
        private int[] firstHitCoordinate;
        private int[] recentHitCoordinate;

        public PlayerAI(Gameboard gb, Gameboard ob, Gameboard fb) : base()
        {
            gameboard = gb;
            oppBoard = ob;
            fireboard = fb;
            missesAfterSecondHit = 0;
            firstHitCoordinate = new int[2];
        }

        public int MissesAfterSecondHit { get => missesAfterSecondHit; set => missesAfterSecondHit = value; }
        public int[] FirstHitCoordinate { get => firstHitCoordinate; set => firstHitCoordinate = value; }
        public int[] RecentHitCoordinate { get => recentHitCoordinate; set => recentHitCoordinate = value; }

        public override int[] ProvideCoordinates()
        {
            Random random = new();
            int x = random.Next(0, gameboard.BoardSize);
            int y = random.Next(0, gameboard.BoardSize);

            int[] coordinates = { x, y };
            return coordinates;
        }
        //public int[] FireNext(int firstX, int firstY, int nHits)
        //{
        //    switch (nHits)
        //    {
        //        case 0:
        //            return ProvideCoordinates();
        //        case 1:
        //            return FireAfterFirstHit(firstX, firstY);
        //        case 2:
        //            return FireAfterSecondHit(firstX, firstY, nHits);
        //    }

        //    throw new NotImplementedException();
        //}
        public int[] FireAfterHit(int x, int y)
        {
            Random rand = new();

            int[,] nextCoordinates = { { x - 1, y }, { x + 1, y }, { x, y - 1 }, { x, y + 1 } };
            int nextPick = rand.Next(0, 4);
            int nextX = nextCoordinates[nextPick, 0];
            int nextY = nextCoordinates[nextPick, 1];
            int[] coordinate = { nextX, nextY };

            return coordinate;
        }

       
        public override string ToString()
        {
            throw new NotImplementedException();
        }


    }
}
