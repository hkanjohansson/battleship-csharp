
using BattleshipApplication.Players;

namespace BattleshipApplication.GameLogic
{
    public interface IGameInterface
    {
        public int PlayerTurn(int turn);
        public void GameRunning();
        public bool ShipHit(Player p, int x, int y);
        public string ScoreBoard();
        public void ShutdownGame();

    }
}
