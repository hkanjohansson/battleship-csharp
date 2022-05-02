namespace BattleshipApplication.Ships
{
    public class Destroyer : Ship
    {
        private const int SHIP_LENGTH = 2;
        private int health;

        public Destroyer() : base(SHIP_LENGTH)
        {
            this.health = SHIP_LENGTH;
        }
        public static int SHIP_LENGTH1 => SHIP_LENGTH;
        public int Health { get => health; set => health = value; }
        public override string Name()
        {
            return "Destroyer";
        }
    }
}
