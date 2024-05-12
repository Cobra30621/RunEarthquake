using System.Collections;
using System.Collections.Generic;
using Player;
using UI;
using UnityEngine;

namespace GameProgress
{
    public class RunningState : GameState
    {
        [SerializeField] private CountdownTimer _timer = new CountdownTimer();

        private const float TOTAL_TIME = 10f;

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
            AudioManager.Instance.PlaySE(SE.Earthquake);
            _gameContext.CameraShake.SetShake(true);
            yield return TextDisplay.Instance.ShowText(
                $"第 {GameProgressHandler.CurrentPhase} 波地震來了", 1f);
            
            float speed = _gameContext.RunningSpeed;
            _gameContext.MapHandler.SetSpeed(speed);
            
            _timer.StartCountdown(TOTAL_TIME);
            while (!_timer.Finished)
            {
                var interval = _gameContext.SpawnInterval / speed;
                yield return new WaitForSeconds( interval);
                Debug.Log("產生障礙物");
                _gameContext.MapHandler.RandomSpawnObstacle();
            }

            _gameContext.CameraShake.SetShake(false);
            
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