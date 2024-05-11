using Sirenix.OdinInspector;
using UnityEngine;

namespace Map
{
    using UnityEngine;
    using System.Collections.Generic;

    public class MapHandler : SerializedMonoBehaviour
    {
        [InlineEditor]
        [SerializeField] private ObstacleData _obstacleData;

        [InlineEditor]
        [SerializeField] private ItemData _itemData;
        
        public GameObject mapObjectPrefab; // MapObject 的預置物
        public int numRows = 3; // 地圖的行數
        public float spawnInterval = 2.0f; // 產生 MapObject 的間隔時間

        public float scrollSpeed;
        
        
        
        [SerializeField] private List<List<MapObject>> mapObjects; // 二維 List 用於管理 MapObject

        [SerializeField] private MapScroller mapScroller;

        [SerializeField] private List<Transform> singleSpawns;
        [SerializeField] private List<Transform> twiceSpawns;

        void Start()
        {
            StartGame();
            
        }

        public void StartGame()
        {
            // 初始化 mapObjects
            mapObjects = new List<List<MapObject>>();

            for (int i = 0; i < numRows; i++)
            {
                mapObjects.Add(new List<MapObject>());
            }

            mapScroller.scrollSpeed = scrollSpeed;
            
            // 開始定期產生 MapObject
            InvokeRepeating("RandomSpawnItem", spawnInterval, spawnInterval);
        }

        #region 產生物件

        [Button("隨機產生道具")]
        void RandomSpawnItem()
        {
            // 隨機選擇一個行數產生 MapObject
            int randomRow = Random.Range(0, numRows);

            SpawnItem(randomRow);
        }

        public void SpawnItem(int row)
        {
            var itemInfo = _itemData.GetRandomItem();

            // 產生 MapObject
            var spawnPosition = singleSpawns[row];
            Item item = Instantiate(itemInfo.prefab, spawnPosition);
            item.SetSpeed(scrollSpeed);
            item.SetItemInfo(itemInfo);
            
            // 將 MapObject 加入到對應的 List 中
            mapObjects[row].Add(item);
        }


        [Button("隨機產生障礙物")]
        public void RandomSpawnObstacle()
        {
            int spawnTwice = Random.Range(0, 2);

            if (spawnTwice == 0)
            {
                SpawnTwiceObstacle(Random.Range(0, numRows - 1));
            }
            else
            {
                SpawnObstacle(Random.Range(0, numRows));
            }
        }

        /// <summary>
        /// 產生佔兩格的障礙物
        /// </summary>
        /// <param name="row"></param>
        public void SpawnTwiceObstacle(int row)
        {
            var spawnPosition = twiceSpawns[row];
            var prefab = _obstacleData.GetRandomTwiceObstacle();
            
            var newObstacle = Instantiate(prefab, spawnPosition);
            newObstacle.SetSpeed(scrollSpeed);
            
            mapObjects[row].Add(newObstacle);
            mapObjects[row + 1].Add(newObstacle);
        }
        
        /// <summary>
        /// 產生佔一格的障礙物
        /// </summary>
        /// <param name="row"></param>
        private void SpawnObstacle(int row)
        {
            var spawnPosition = singleSpawns[row];
            var prefab = _obstacleData.GetRandomObstacle();
            
            var newObstacle = Instantiate(prefab, spawnPosition);
            newObstacle.SetSpeed(scrollSpeed);
            
            mapObjects[row].Add(newObstacle);
        }
        

        #endregion

        [Button("改變速度")]
        // 改變所有 MapObject 的速度
        public void ChangeSpeed(float newSpeed)
        {
            foreach (List<MapObject> rowObjects in mapObjects)
            {
                foreach (MapObject mapObject in rowObjects)
                {
                    mapObject.SetSpeed(newSpeed);
                }
            }

            mapScroller.scrollSpeed = newSpeed;
        }

        // 刪除指定行數的所有 MapObject
        public void RemoveObjectsInRow(int row)
        {
            foreach (MapObject mapObject in mapObjects[row])
            {
                Destroy(mapObject.gameObject);
            }

            mapObjects[row].Clear();
        }
    }
    
}