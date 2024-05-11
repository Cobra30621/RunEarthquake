using System.Collections;
using Map;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameProgress
{
    public class GameProgressHandler : SerializedMonoBehaviour, GameContext
    {
        [SerializeField] private GameState _gameState;

        public bool IsPaused => isPaused;
        [SerializeField] private bool isPaused;

        private Coroutine stateCoroutine;

        public void RunCoroutine(IEnumerator enumerator)
        {
            stateCoroutine = StartCoroutine(enumerator);
        }

        public StateType CurrentStateType => _gameState.GetStateType();
        
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

        public MapHandler MapHandler => _mapHandler;

        [SerializeField] private MapHandler _mapHandler;

        private void Start()
        {
            StartGame();
        }

        [Button("開始遊戲")]
        public void StartGame()
        {
            _mapHandler.StartGame();
            SetGameState(new PreparingState());
        }

        private void Update()
        {
            _gameState.Update();
        }


        public void SetGameState(GameState newState)
        {
            if(stateCoroutine != null)
                StopCoroutine(stateCoroutine);
            Debug.Log($"SetGameState: {newState.GetStateType()}");
            _gameState = newState;
            newState.Init(this);
            newState.EnterState();
        }
    
    }

    public enum StateType
    {
        Idle, Preparing, Running
    }
}