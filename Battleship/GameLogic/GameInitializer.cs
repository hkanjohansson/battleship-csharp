using BattleshipApplication.Players;
using BattleshipApplication.Ships;

namespace BattleshipApplication.GameLogic
{
    public static class GameInitializer
    {

        public static void MainMenu()
        {
            throw new NotImplementedException();
        }
        /*
         * TODO - Extract messages to methods?
         */
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

                    Console.WriteLine("Do you want to place the ship horizontally? (y for yes and n for no)");
                    string place = Console.ReadLine();
                    while (!place.Equals("y") && !place.Equals("n"))
                    {
                        Console.WriteLine("Provide a valid choice:\n\n" +
                            "y for yes\n" +
                            "n for no");
                        place = Console.ReadLine();
                    }

                    bool horizontal = place.Equals("y");
                    bool validCoordinates = p.IsWithin(x, y, currentShip.ShipLength) && p.PlaceAble(x, y, currentShip.ShipLength);

                    while (!validCoordinates)
                    {
                        Console.WriteLine("Try again and place your ship on valid coordinates." +
                            "\n\nValid coordinates range are x: 0-9, y: 0-9 and where a ship " +
                            "has not already been placed.\n");
                        coordinates = p.ProvideCoordinates();
                        x = coordinates[0];
                        y = coordinates[1];

                        Console.WriteLine("Do you want to place the ship horizontally? (write true for horizontal and false for vertical)");
                        place = Console.ReadLine();
                        horizontal = place.Equals("y") ? true : false;
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
