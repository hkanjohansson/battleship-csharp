
namespace BattleshipApplication.GameLogic
{
    public interface IGameInterface
    {
        public int PlayerTurn(int turn);
        public void GameRunning();
        public bool ShipHit();
        public string ScoreBoard();
        public void ShutdownGame();

    }
}
