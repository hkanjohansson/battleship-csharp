
namespace BattleshipApplication.Ships
{
    public abstract class Ship
    {
        private int shipLength;

        public Ship(int shipLength)
        {
            this.ShipLength = shipLength;
        }

        public int ShipLength { get => shipLength; set => shipLength = value; }
    }
}
