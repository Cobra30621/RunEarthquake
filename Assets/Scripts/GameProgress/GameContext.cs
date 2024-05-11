
using System.Collections;
using Map;

namespace GameProgress
{
    public interface GameContext
    {
        void SetGameState(GameState newState);

        void RunCoroutine(IEnumerator enumerator);
        
        StateType CurrentStateType { get; }
        
        void PauseGame(bool pause);
        
        MapHandler MapHandler { get;  }

        void SetNextPhaseCount();

    }
}