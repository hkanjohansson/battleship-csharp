namespace BattleshipApplication.Ships
{
    public class Cruiser : Ship
    {
        private const int SHIP_LENGTH = 3;
        private int health;
        
        public Cruiser() : base(SHIP_LENGTH)
        {
            this.health = SHIP_LENGTH;
        }
        public static int SHIP_LENGTH1 => SHIP_LENGTH;
        public int Health { get => health; set => health = value; }
        public override string Name()
        {
            return "Cruiser";
        }
    }
}
