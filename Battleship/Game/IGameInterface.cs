
namespace BattleshipApplication.Game
{
    public interface IGameInterface
    {
        public void InitializeGame();
        public bool GameRunning();
        public int PlayerTurn(int turn);
        public bool ShipHit();
        public string ScoreBoard();
        public void ShutdownGame();

    }
}
