using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgress
{
    public class RunningState : GameState
    {
        [SerializeField] private CountdownTimer _timer = new CountdownTimer();

        public float TOTAL_TIME = 10f;
        
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
            _timer.StartCountdown(TOTAL_TIME);
            while (true)
            {
                yield return new WaitForSeconds(1);
                Debug.Log("產生障礙物");
                _gameContext.MapHandler.RandomSpawnObstacle();
            }
            
            
        }
        
        public override void Update()
        {
            _timer.Update();

            if (_timer.Finished)
            {
                _gameContext.SetGameState(new PreparingState());
            }
        }
    }
}