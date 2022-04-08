namespace BattleshipApplication.Ships
{
    public class Battleship
    {
        private const int SHIP_LENGTH = 4;
        private int health;

        public Battleship()
        {
            this.health = SHIP_LENGTH;
        }
        public int Health { get => health; set => health = value; }
    }
}
