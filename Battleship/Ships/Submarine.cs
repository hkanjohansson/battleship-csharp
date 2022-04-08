namespace BattleshipApplication.Ships
{
    public class Submarine : Ship
    {
        private const int SHIP_LENGTH = 3;
        private int health;

        public Submarine() : base(SHIP_LENGTH)
        {
            this.health = SHIP_LENGTH;
        }
        public static int SHIP_LENGTH1 => SHIP_LENGTH;
        public int Health { get => health; set => health = value; }
    }
}
