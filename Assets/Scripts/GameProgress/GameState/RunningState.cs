using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace GameProgress
{
    public class RunningState : GameState
    {
        [SerializeField] private CountdownTimer _timer = new CountdownTimer();

        private const float TOTAL_TIME = 10f;

        [SerializeField] private float baseSpeed = 5;
        [SerializeField] private float addSpeed = 1f;

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
            yield return TextDisplay.Instance.ShowText(
                $"第 {_gameContext.CurrentPhase} 波地震來了", 1f);
            
            _gameContext.MapHandler.ChangeSpeed(baseSpeed + addSpeed * _gameContext.CurrentPhase);
            
            _timer.StartCountdown(TOTAL_TIME);
            while (!_timer.Finished)
            {
                yield return new WaitForSeconds(1);
                Debug.Log("產生障礙物");
                _gameContext.MapHandler.RandomSpawnObstacle();
            }

            yield return new WaitForSeconds(3f);
            
            _gameContext.SetNextPhaseCount();
            _gameContext.SetGameState(new PreparingState());
        }
        
        public override void Update()
        {
            _timer.Update();
        }
    }
}