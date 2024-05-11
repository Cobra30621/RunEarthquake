using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgress
{
    public class RunningState : GameState
    {
        public override StateType GetStateType()
        {
            return StateType.Running;
        }

        public override void EnterState()
        {
            Debug.Log("進入跑酷階段");
            _gameContext.RunCoroutine(SpawningCoroutine());
        }
        
        private IEnumerator SpawningCoroutine()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(1);
                Debug.Log("產生障礙物");
            }
            
            _gameContext.SetGameState(new PreparingState());
        }
        
        public override void Update()
        {
            
        }
    }
}