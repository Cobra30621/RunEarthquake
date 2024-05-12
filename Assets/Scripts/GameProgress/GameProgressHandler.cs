using System.Collections;
using Core;
using Map;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameProgress
{
    public class GameProgressHandler : SingletonWithSerialized<GameProgressHandler>, GameContext
    {
        [SerializeField] private GameState _gameState;

        public bool IsPaused => isPaused;
        [SerializeField] private bool isPaused;

        private Coroutine _stateCoroutine;

        private static int _phase;

        public StateType CurrentStateType => _gameState.GetStateType();

        public MapHandler MapHandler => _mapHandler;
        public CameraShake CameraShake => cameraShake;

        [SerializeField] private MapHandler _mapHandler;
        
        [Required]
        [SerializeField]
        private CameraShake cameraShake;

        public static int CurrentPhase => _phase;
        public float BaseSpeed => _baseSpeed;
        public float RunningSpeed => _baseSpeed + _addSpeed * (CurrentPhase - 1);
        public float SpawnInterval => _spawnInterval;

        [SerializeField] private GameObject pausePanel;
        
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
            pausePanel.SetActive(pause);
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
            StartCoroutine(GameOverCoroutine());
        }

        private IEnumerator GameOverCoroutine()
        {
            AudioManager.Instance.PlaySE(SE.BuildingDown);
            MapHandler.Instance.SetSpeed(0);
            PlayerController.SetCanMove(false);
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