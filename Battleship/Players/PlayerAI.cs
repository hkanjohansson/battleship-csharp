using BattleshipApplication.GameboardInitilizer;
using System.Collections.Generic;

namespace BattleshipApplication.Players
{
    public class PlayerAI : Player
    {
        private int nHits;
        private int missesAfterSecondHit;
        private List<int[]> hitsCoordinates;
        private List<int[]> missAfterHitCoordinates;
        public PlayerAI(Gameboard gb, Gameboard ob, Gameboard fb) : base()
        {
            gameboard = gb;
            oppBoard = ob;
            fireboard = fb;
            missesAfterSecondHit = 0;
            hitsCoordinates = new List<int[]>();
            missAfterHitCoordinates = new List<int[]>();
        }

        public int MissesAfterSecondHit { get => missesAfterSecondHit; set => missesAfterSecondHit = value; }
        public List<int[]> HitsCoordinates { get => hitsCoordinates; set => hitsCoordinates = value; }
        public int NHits { get => nHits; set => nHits = value; }
        public List<int[]> MissAfterHitCoordinates { get => missAfterHitCoordinates; set => missAfterHitCoordinates = value; }

        public override int[] ProvideCoordinates()
        {
            Random random = new();
            if (nHits == 0)
            {
                int x = random.Next(0, gameboard.BoardSize);
                int y = random.Next(0, gameboard.BoardSize);
                int[] coordinates = { x, y };
                return coordinates;
            }
            else
            {
                return FireAfterHit();
            }
        }
        
        public int[] FireAfterHit()
        {
            Random rand = new();

            if (nHits == 1)
            {
                int[,] nextCoordinates = {
                { hitsCoordinates[0][0] - 1, hitsCoordinates[0][1] },
                { hitsCoordinates[0][0] + 1, hitsCoordinates[0][1] },
                { hitsCoordinates[0][0], hitsCoordinates[0][1] - 1 },
                { hitsCoordinates[0][0], hitsCoordinates[0][1] + 1 }
            };
                int nextPick = rand.Next(0, 4);
                int nextX = nextCoordinates[nextPick, 0];
                int nextY = nextCoordinates[nextPick, 1];
                int[] coordinate = { nextX, nextY };

                return coordinate;
            }
            else
            {

                int[,] nextCoordinates = {
                { hitsCoordinates[nHits][0] - 1, hitsCoordinates[nHits][1] },
                { hitsCoordinates[nHits][0] + 1, hitsCoordinates[nHits][1] },
                { hitsCoordinates[nHits][0], hitsCoordinates[nHits][1] - 1 },
                { hitsCoordinates[nHits][0], hitsCoordinates[nHits][1] + 1 }
                };
                int nextPick = rand.Next(0, 4);
                int nextX = nextCoordinates[nextPick, 0];
                int nextY = nextCoordinates[nextPick, 1];
                int[] coordinate = { nextX, nextY };

                return coordinate;
            }


        }


        public override string ToString()
        {
            throw new NotImplementedException();
        }


    }
}
