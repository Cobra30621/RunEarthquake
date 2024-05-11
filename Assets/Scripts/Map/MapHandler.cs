using Sirenix.OdinInspector;
using UnityEngine;

namespace Map
{
    using UnityEngine;
    using System.Collections.Generic;

    public class MapHandler : SerializedMonoBehaviour
    {
        public GameObject mapObjectPrefab; // MapObject 的預置物
        public int numRows = 3; // 地圖的行數
        public float spawnInterval = 2.0f; // 產生 MapObject 的間隔時間

        public float scrollSpeed;
        
        
        
        [SerializeField] private List<List<MapObject>> mapObjects; // 二維 List 用於管理 MapObject

        [SerializeField] private MapScroller mapScroller;

        [SerializeField] private List<Transform> spawns;

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
            InvokeRepeating("SpawnMapObject", spawnInterval, spawnInterval);
        }

        [Button("隨機產生物體")]
        void SpawnMapObject()
        {
            // 隨機選擇一個行數產生 MapObject
            int randomRow = Random.Range(0, numRows);

            SpawnMapObject(randomRow);
        }

        public void SpawnMapObject(int row)
        {
            // 產生 MapObject
            var spawnPosition = spawns[row];
            GameObject newMapObject = Instantiate(mapObjectPrefab, spawnPosition);
            MapObject mapObjectScript = newMapObject.GetComponent<MapObject>();
            mapObjectScript.SetSpeed(scrollSpeed);
            
            // 將 MapObject 加入到對應的 List 中
            mapObjects[row].Add(mapObjectScript);
        }

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