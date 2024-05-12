using System;
using Player;
using Sirenix.OdinInspector;

namespace Map
{
    using UnityEngine;

    public abstract class MapObject : MonoBehaviour
    {
        public int [] Rows;
        
        private float moveSpeed = 1.0f; // MapObject 的移動速度

        public void SetRow(int[] rows)
        {
            Rows = rows;
        }
     
        
        void Update()
        {
            // 持續向下移動
            moveSpeed = MapHandler.Instance.ScrollSpeed;
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // 如果 MapObject 移出畫面下方，則刪除它
            if (transform.position.y < -10.0f) // 假設 -10 是畫面下方的位置
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerEnter();
            }
        }
        
        protected abstract void OnPlayerEnter();
    }
}