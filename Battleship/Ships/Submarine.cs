namespace BattleshipApplication.Ships
{
    public class Submarine
    {
        private const int SHIP_LENGTH = 3;
        private int health;

        public Submarine()
        {
            this.health = SHIP_LENGTH;
        }

        public int Health { get => health; set => health = value; }
    }
}
