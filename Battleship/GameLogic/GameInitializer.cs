using BattleshipApplication.Players;
using BattleshipApplication.Ships;
using System.Text;

namespace BattleshipApplication.GameLogic
{
    public static class GameInitializer
    {

        public static void MainMenu()
        {
            StringBuilder sb = new();
            sb.AppendLine("|--------------------------------------------------------------------------------|");
            sb.AppendLine("| Welcome to Battleships! First, place your ships within the area that is x: 0-9 |");
            sb.AppendLine("| and y: 0-9. The given coordinates must be of integer type. The same goes for   |");
            sb.AppendLine("| when it is time to fire.                                                       |");
            sb.AppendLine("|                                                                                |");
            sb.AppendLine("| You have three options to play the game. Provide of the following options:     |");
            sb.AppendLine("| 1: To play against another human                                               |");
            sb.AppendLine("| 2: To play against an AI                                                       |");
            sb.AppendLine("| 3: Sit back and relax and let the AI:s do the playing                          |");
            sb.AppendLine("|                                                                                |");
            sb.AppendLine("|--------------------------------------------------------------------------------|");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("So what will it be: ");
        }


        public static void ShipPlacement(Player p)
        {
            /*
             * TODO - Rewrite to take an addtional argument that is a boolean asking 
             *        for what type of player. 
             *        
             *      - When finished, check if the method should be splitted into 
             *        two or more methods. 
             */
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
                    bool validCoordinates = GameRules.IsWithin(x, y, currentShip.ShipLength) && GameRules.PlaceAble(x, y, currentShip.ShipLength);

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
                        horizontal = place.Equals("y");
                        validCoordinates = GameRules.IsWithin(x, y, currentShip.ShipLength) && GameRules.PlaceAble(x, y, currentShip.ShipLength);

                    }

                    p.PlaceShip(x, y, currentShip.ShipLength, horizontal);
                    Console.WriteLine(p.Gameboard.ToString());
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
