using System;
using System.Collections.Generic;
using GameProgress;
using Map;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class DeveloperTools : SerializedMonoBehaviour
    {
        [SerializeField] private GameProgressHandler _gameProgressHandler;
        [SerializeField] private MapHandler _mapHandler;

        [Title("參數")] [SerializeField] private bool useOnStart;
        [SerializeField] private ItemData _itemData;

        private void Start()
        {
            if (useOnStart)
            {
                GetFullItem();
            }
        }

        [Button("暫停")]
        public void Pause()
        {
            _gameProgressHandler.TriggerPause();
        }
        
        [Button("改變速度")]
        public void ChangeSpeed(float speed)
        {
            _mapHandler.SetSpeed(speed);
        }
        

        [Button("獲得全滿的道具")]
        public void GetFullItem()
        {
            for (int i = 0; i < 4; i++)
            {
                var randomItem = _itemData.GetRandomItem();
                ItemHandler.Instance.GainItem(randomItem);
            }
        }
    }
}