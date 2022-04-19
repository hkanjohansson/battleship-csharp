﻿using BattleshipApplication.GameboardInitilizer;
using BattleshipApplication.Ships;

namespace BattleshipApplication.Players
{
    public class PlayerHuman : Player
    {
        public PlayerHuman(Gameboard gb, Gameboard fb) : base()
        {
            gameboard = gb;
            fireboard = fb;
        }

        public override int[] ProvideCoordinates()
        {
            Console.WriteLine("Provide the x-coordinate: ");
            int x = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Provide the y-coordinate: ");
            int y = Convert.ToInt16(Console.ReadLine());
            

            int[] coordinates = { x, y };
            return coordinates;
        }
        public override void PlaceShip(int x, int y, int shipLength, bool horizontal)
        {
            /*
             * Checks for valid coordinates are done in the Game class. That is because a player 
             * should only follow the rules set by the game and not itself implement them.
             */
            if (horizontal)
            {
                for (int i = x; i < x + shipLength; i++)
                {
                    gameboard.Board[y, i] = 1;
                }
            }
            else if (!horizontal)
            {
                for (int i = y; i < y + shipLength; i++)
                {
                    gameboard.Board[i, x] = 1;
                }
            }
        }

        public override void Fire()
        {
            bool fired = false;
            Console.WriteLine("Provide coordinates on where to fire: ");
            while (!fired)
            {
                Console.WriteLine("Provide the x-coordinate: ");
                int x = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Provide the y-coordinate: ");
                int y = Convert.ToInt16(Console.ReadLine());

                if (x < 0 || y < 0 || x >= Gameboard.BoardSize || y >= Gameboard.BoardSize)
                {
                    throw new ArgumentOutOfRangeException("Provide valid coordinates.");
                }
                else
                {
                    fireboard.Board[y, x] = 2;
                    fired = true;
                }
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

      
    }
}
