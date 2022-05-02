
using BattleshipApplication.Players;

namespace BattleshipApplication.GameLogic
{
    public interface IGameInterface
    {
        
        public void GameRunning();
        
        public string ScoreBoard();
        public void ShutdownGame();

    }
}
