namespace Map
{
    using UnityEngine;

    public class MapObject : MonoBehaviour
    {
        private float moveSpeed = 1.0f; // MapObject 的移動速度

        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }
        
        void Update()
        {
            // 持續向下移動
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // 如果 MapObject 移出畫面下方，則刪除它
            if (transform.position.y < -10.0f) // 假設 -10 是畫面下方的位置
            {
                Destroy(gameObject);
            }
        }
    }

}