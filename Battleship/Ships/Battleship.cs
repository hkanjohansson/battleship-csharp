namespace BattleshipApplication.Ships
{
    public class Battleship : Ship
    {
        private const int SHIP_LENGTH = 4;
        private int health;

        public Battleship() : base(SHIP_LENGTH)
        {
            this.health = SHIP_LENGTH;
        }
        
        public int Health { get => health; set => health = value; }

        public override string Name()
        {
            return "Battleship";
        }
    }
}
