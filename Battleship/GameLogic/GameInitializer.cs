﻿using BattleshipApplication.Players;
using BattleshipApplication.Ships;

namespace BattleshipApplication.GameLogic
{
    public static class GameInitializer
    {


        public static void ShipPlacement(Player p)
        {
            try
            {
                while (p.Ships.Count > 0)
                {
                    Ship currentShip = p.Ships.Dequeue();
                    int[] coordinates = p.ProvideCoordinates();
                    int x = coordinates[0];
                    int y = coordinates[1];

                    Console.WriteLine("Do you want to place the ship horizontally? (write true for horizontal and false for vertical)");
                    bool horizontal = Convert.ToBoolean(Console.ReadLine());
                    bool validCoordinates = p.IsWithin(x, y, currentShip.ShipLength) && p.PlaceAble(x, y, currentShip.ShipLength);

                    while (!validCoordinates)
                    {
                        Console.WriteLine("Try again and place your ship on valid coordinates.\n\nValid coordinates range are x: 0-9, y: 0-9 and where a ship has not already been placed.\n");
                        coordinates = p.ProvideCoordinates();
                        x = coordinates[0];
                        y = coordinates[1];

                        Console.WriteLine("Do you want to place the ship horizontally? (write true for horizontal and false for vertical)");
                        horizontal = Convert.ToBoolean(Console.ReadLine());
                        validCoordinates = p.IsWithin(x, y, currentShip.ShipLength) && p.PlaceAble(x, y, currentShip.ShipLength);

                    }

                    p.PlaceShip(x, y, currentShip.ShipLength, horizontal);
                    Console.WriteLine(p.Gameboard.ToString());
                }
            } catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}