namespace BattleshipApplication.Ships
{
    public class Cruiser
    {
        private const int SHIP_LENGTH = 3;
        private int health;
        
        public Cruiser()
        {
            this.health = SHIP_LENGTH;
        }

        public int Health { get => health; set => health = value; }
    }
}
