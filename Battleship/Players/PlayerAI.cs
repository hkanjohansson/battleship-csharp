using BattleshipApplication.GameboardInitilizer;
using System.Collections.Generic;

namespace BattleshipApplication.Players
{
    public class PlayerAI : Player
    {
        public PlayerAI(Gameboard gb, Gameboard ob, Gameboard fb) : base()
        {
            gameboard = gb;
            oppBoard = ob;
            fireboard = fb;

        }

        public override int[] ProvideCoordinates()
        {
            if (nHits == 1)
            {
                Console.WriteLine("Does it enter here when testing?");
                return FireAfterFirstHit();
            }
            else if (nHits >= 2)
            {
                Console.WriteLine("Does it enter here when testing??");
                return FireAfterSecondHit();
            }
            else
            {
                Console.WriteLine("Does it enter here when testing????");
                Random random = new();
                int x = random.Next(0, gameboard.BoardSize);
                int y = random.Next(0, gameboard.BoardSize);
                int[] coordinates = { x, y };
                return coordinates;
            }
        }

        public int[] FireAfterFirstHit()
        {
            /*
             * TODO - Add check for when coordinates are fireable
             */
            Random rand = new();
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

        public int[] FireAfterSecondHit()
        {
            /*
             * TODO - Refactor
             */

            // Direction is chosen by subtracting the latest hit coordinate from the first hit coordinate.
            int fireDirectionX = PickFireDirectionX();
            int fireDirectionY = PickFireDirectionY();

            if (fireDirectionX < 0 && fireDirectionY == 0)
            {
                int[] coordinate = { hitsCoordinates[nHits - 1][0] + 1, hitsCoordinates[nHits - 1][1] };
                return coordinate;
            }
            else if (fireDirectionX > 0 && fireDirectionY == 0)
            {
                int[] coordinate = { hitsCoordinates[nHits - 1][0] - 1, hitsCoordinates[nHits - 1][1] };
                return coordinate;
            }
            else if (fireDirectionX == 0 && fireDirectionY < 0)
            {
                int[] coordinate = { hitsCoordinates[nHits - 1][0], hitsCoordinates[nHits - 1][1] + 1 };
                return coordinate;
            }
            else if (fireDirectionX == 0 && fireDirectionY > 0)
            {
                int[] coordinate = { hitsCoordinates[nHits - 1][0], hitsCoordinates[nHits - 1][1] - 1 };
                return coordinate;
            }

            throw new NotImplementedException();
        }

        private int PickFireDirectionX()
        {
            return hitsCoordinates[0][0] - hitsCoordinates[nHits - 1][0];
        }

        public int PickFireDirectionY()
        {
            return hitsCoordinates[0][1] - hitsCoordinates[nHits - 1][1];
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }


    }
}
