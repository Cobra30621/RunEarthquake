using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Map
{
    using UnityEngine;
    using System.Collections.Generic;

    public class MapHandler : SingletonWithSerialized<MapHandler>
    {
        [InlineEditor]
        [SerializeField] private ObstacleData _obstacleData;

        [InlineEditor]
        [SerializeField] private ItemData _itemData;
        
        
        public int numRows = 3; // 地圖的行數

        private float scrollSpeed;
        
        [SerializeField] private MapScroller mapScroller;

        [SerializeField] private List<Transform> singleSpawns;
        [SerializeField] private List<Transform> twiceSpawns;
        
        public void StartGame()
        {
            mapScroller.scrollSpeed = scrollSpeed;
        }

        #region 產生物件

        [Button("隨機產生道具")]
        public void RandomSpawnItem()
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
            item.SetRow(new int[]{row});
            
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
            newObstacle.SetRow(new int[]{row, row + 1});
            
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
            newObstacle.SetRow(new int[]{row});
            
        }
        

        #endregion

        [Button("改變速度")]
        // 改變所有 MapObject 的速度
        public void SetSpeed(float newSpeed)
        {
            scrollSpeed = newSpeed;
            var mapObjects = MapHelper.FindAllMapObject();
            foreach (var mapObject in mapObjects)
            {
                mapObject.SetSpeed(newSpeed);
            }

            mapScroller.scrollSpeed = newSpeed;
        }

        [Button("刪除指定的行")]
        // 刪除指定行數的所有 MapObject
        public void RemoveObjectsInRow(int row)
        {
            var mapObjects = MapHelper.FindMapObjectWithRow(row);
            foreach (MapObject mapObject in mapObjects)
            {
                Destroy(mapObject.gameObject);
            }
        }

        [Button("刪除所有物件")]
        public void RemoveAllObject()
        {
            var mapObjects = MapHelper.FindAllMapObject();
            foreach (var mapObject in mapObjects)
            {
                Destroy(mapObject.gameObject);
            }
        }

        public Transform GetSingleRow(int row)
        {
            return singleSpawns[row];
        }
    }
    
}