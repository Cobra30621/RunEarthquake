using Map;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player
{
    public class PlayerController : SerializedMonoBehaviour
    {
        
        [SerializeField] private int currentRow = 1;

        [SerializeField] private GameObject player;

        [SerializeField] private MapHandler _mapHandler;
        
        void Update()
        {
            CheckMovement();
            CheckSkillInput();
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
                
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                
            }
        }
    }
}