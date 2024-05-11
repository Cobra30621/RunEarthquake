using System.Collections;
using Map;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public int CurrentPhase => _phase;
        public float BaseSpeed => _baseSpeed;
        public float RunningSpeed => _baseSpeed + _addSpeed * (CurrentPhase - 1);
        public float SpawnInterval => _spawnInterval;
        
        [Title("參數")]
        [LabelText("基礎移動速度")]
        [SerializeField] private float _baseSpeed = 4f;
        [LabelText("每階段後加乘的速度")]
        [SerializeField] private float _addSpeed = 2f;
        
        [LabelText("物品生成頻率")]
        [SerializeField] private float _spawnInterval = 8f;
        
        

        private void Start()
        {
            PlayerStatus.OnGameOver.AddListener(EndGame);
            
            StartGame();
        }

        [Button("開始遊戲")]
        public void StartGame()
        {
            _mapHandler.StartGame();
            _phase = 1;
            PlayerStatus.Instance.Init();
            ItemHandler.Instance.InitItems();
            
            SetGameState(new PreparingState(true));
        }

        public void RunCoroutine(IEnumerator enumerator)
        {
            _stateCoroutine = StartCoroutine(enumerator);
        }

        public void TriggerPause()
        {
            PauseGame(!isPaused);
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
        
        private void EndGame()
        {
            PauseGame(true);
            StartCoroutine(GameOverCoroutine());
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("end");
        }

        private void Update()
        {
            _gameState.Update();
        }


        public void SetNextPhaseCount()
        {
            _phase++;
        }

        
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