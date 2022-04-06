namespace BattleshipApplication.Ships
{
    public class Carrier
    {
        private const int SHIP_LENGTH = 5;
        private int health;

        public Carrier()
        {
            this.health = SHIP_LENGTH;
        }

        public int Health { get => health; set => health = value; }
    }
}
