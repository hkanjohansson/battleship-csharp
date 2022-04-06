namespace BattleshipApplication.Ships
{
    public class Destroyer
    {
        private const int SHIP_LENGTH = 4;
        private int health;

        public Destroyer()
        {
            this.health = SHIP_LENGTH;
        }

        public int Health { get => health; set => health = value; }
    }
}
