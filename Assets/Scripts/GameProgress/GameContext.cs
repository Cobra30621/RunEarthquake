
using System.Collections;
using Map;
using Player;

namespace GameProgress
{
    public interface GameContext
    {
        void SetGameState(GameState newState);

        void RunCoroutine(IEnumerator enumerator);
        
        StateType CurrentStateType { get; }
        
        void PauseGame(bool pause);
        
        MapHandler MapHandler { get;  }
        CameraShake CameraShake { get; }

        void SetNextPhaseCount();
        
        
        float BaseSpeed { get; }
        
        float RunningSpeed { get; }
        
        float SpawnInterval { get; }

    }
}