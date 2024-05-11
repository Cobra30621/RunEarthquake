using System.Collections;
using Map;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameProgress
{
    public class GameProgressHandler : SerializedMonoBehaviour, GameContext
    {
        [SerializeField] private GameState _gameState;

        public bool IsPaused => isPaused;
        [SerializeField] private bool isPaused;

        private Coroutine _stateCoroutine;

        private int _phase;

        public StateType CurrentStateType => _gameState.GetStateType();

        public MapHandler MapHandler => _mapHandler;

        [SerializeField] private MapHandler _mapHandler;

        public void RunCoroutine(IEnumerator enumerator)
        {
            _stateCoroutine = StartCoroutine(enumerator);
        }

        [Button("暫停遊戲")]
        public void PauseGame(bool pause)
        {
            isPaused = pause;
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void Start()
        {
            StartGame();
        }

        [Button("開始遊戲")]
        public void StartGame()
        {
            _mapHandler.StartGame();
            _phase = 1;
            PlayerStatus.Instance.Init();
            
            SetGameState(new PreparingState(true));
        }

        private void Update()
        {
            _gameState.Update();
        }


        public void SetNextPhaseCount()
        {
            _phase++;
        }

        public int CurrentPhase => _phase;

        public void SetGameState(GameState newState)
        {
            if(_stateCoroutine != null)
                StopCoroutine(_stateCoroutine);
            
            Debug.Log($"SetGameState: {newState.GetStateType()}");
            _gameState = newState;
            newState.Init(this);
            newState.EnterState();
        }
    
    }

    public enum StateType
    {
        Preparing, Running
    }
}