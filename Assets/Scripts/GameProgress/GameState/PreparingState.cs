using System.Collections;
using Map;
using UI;
using UnityEngine;

namespace GameProgress
{
    public class PreparingState : GameState
    {
        private int START_SPAWN_COUNT = 3;
        private int SPAWN_COUNT = 1;

        private bool _isFirstPhase;


        public PreparingState(bool isFirstPhase = false)
        {
            _isFirstPhase = isFirstPhase;
        }
        
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
            _gameContext.MapHandler.SetSpeed(_gameContext.BaseSpeed);
            yield return TextDisplay.Instance.ShowText("準備階段", 1f);
            
            
            var spawnCount = _isFirstPhase ? START_SPAWN_COUNT:SPAWN_COUNT;
            for (int i = 0; i < spawnCount; i++)
            {
                _gameContext.MapHandler.SpawnItem(0);
                _gameContext.MapHandler.SpawnItem(2);
                yield return new WaitForSeconds(3);
                Debug.Log("產生道具");
            }

            yield return new WaitForSeconds(2f);
            
            _gameContext.SetGameState(new RunningState());
        }
        

        public override void Update()
        {
           
        }
    }
}