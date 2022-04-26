using BattleshipApplication.GameboardInitilizer;

namespace BattleshipApplication.Players
{
    public class PlayerHuman : Player
    {
        public PlayerHuman(Gameboard gb, Gameboard ob, Gameboard fb) : base()
        {
            gameboard = gb;
            oppBoard = ob;
            fireboard = fb;
        }

        /*
         * TODO - Check whether or not this method method is necessary to have.
         */
        public override int[] ProvideCoordinates()
        {
            Console.WriteLine("Provide the x-coordinate: ");
            string? inX = Console.ReadLine();

            Console.WriteLine("Provide the y-coordinate: ");
            string? inY = Console.ReadLine();
            int[] coordinatesParsed = GameRules.ParseCoordinates(inX, inY);

            return coordinatesParsed;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
