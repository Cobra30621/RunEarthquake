using GameProgress;
using Map;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : SerializedMonoBehaviour
    {
       

        [SerializeField] private GameObject player;

        [SerializeField] private MapHandler _mapHandler;
        [SerializeField] private GameProgressHandler _gameProgressHandler;

        public static int currentRow = 1;
        public static int CurrentRow => currentRow;
        
        void Update()
        {
            CheckSpeedUp();
            CheckRestart();
            CheckPause();
            
            CheckMovement();
            CheckSkillInput();
        }


        private void CheckRestart()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Game");
            }
        }

        private void CheckSpeedUp()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                var speed = GameProgressHandler.Instance.RunningSpeed;
                MapHandler.Instance.SetSpeed(speed - 2f);
            }
            
            if (Input.GetKeyDown(KeyCode.O))
            {
                var speed = GameProgressHandler.Instance.RunningSpeed;
                MapHandler.Instance.SetSpeed(speed + 2f);
            }
        }
        
        private void CheckPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _gameProgressHandler.TriggerPause();
            }
        }


        private void CheckMovement()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                UpdatePlayerRow(-1);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                UpdatePlayerRow(1);
            }
        }

        private void UpdatePlayerRow(int move)
        {
            currentRow += move;

            if (currentRow < 0)
            {
                currentRow = 0;
            }
            if (currentRow >= _mapHandler.numRows)
            {
                currentRow = _mapHandler.numRows - 1;
            }
            
            float x = _mapHandler.GetSingleRow(currentRow).position.x;
            var position = player.transform.position;
            position = new Vector3(x, position.y, position.z);
            player.transform.position = position;
        }

        private void CheckSkillInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ItemHandler.Instance.UseItem(0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                ItemHandler.Instance.UseItem(1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                ItemHandler.Instance.UseItem(2);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ItemHandler.Instance.UseItem(3);
            }
        }
    }
}