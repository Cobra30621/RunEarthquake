namespace Map
{
    using UnityEngine;

    public class MapScroller : MonoBehaviour
    {
        public float scrollSpeed; // 地圖滑動的速度
        public float mapHeight = 10.0f; // 地圖的高度，用於循環滑動

        [SerializeField] private SpriteRenderer mapSpriteRenderer; // 地圖的 SpriteRenderer
        [SerializeField] private Transform map1; // 第一張地圖
        [SerializeField] private Transform map2; // 第二張地圖

        void Start()
        {
            mapHeight = mapSpriteRenderer.bounds.size.y;
            // 設定初始位置
            map1.position = new Vector3(map1.position.x, 0, 0);
            map2.position = new Vector3(map2.position.x, mapHeight, 0);
        }

        void Update()
        {
            // 讓兩張地圖持續向下滑動
            map1.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
            map2.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

            // 檢查是否需要重新設定地圖位置
            CheckMapPosition();
        }

        void CheckMapPosition()
        {
            // 如果地圖1超出螢幕下方，將其移回螢幕上方
            if (map1.position.y < -mapHeight)
            {
                map1.position += new Vector3(0, mapHeight * 2, 0);
            }

            // 如果地圖2超出螢幕下方，將其移回螢幕上方
            if (map2.position.y < -mapHeight)
            {
                map2.position += new Vector3(0, mapHeight * 2, 0);
            }
        }
    }

}