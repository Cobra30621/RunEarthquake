using System.Collections;
using Map;
using UnityEngine;

namespace GameProgress
{
    public class PreparingState : GameState
    {
        public override StateType GetStateType()
        {
            return StateType.Preparing;
        }

        public override void EnterState()
        {
            Debug.Log("進入準備階段");
            _gameContext.RunCoroutine(PrepareCoroutine());
        }

        private IEnumerator PrepareCoroutine()
        {

            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(1);
                _gameContext.MapHandler.RandomSpawnItem();
                Debug.Log("產生道具");
            }
            
            _gameContext.SetGameState(new RunningState());
        }
        

        public override void Update()
        {
           
        }
    }
}