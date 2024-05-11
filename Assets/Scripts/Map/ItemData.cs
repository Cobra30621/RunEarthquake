using System;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Item Data")]
    public class ItemData : ScriptableObject
    {
        public List<ItemInfo> ItemInfos;

        public ItemInfo GetRandomItem()
        {
            return ItemInfos[UnityEngine.Random.Range(0, ItemInfos.Count)];
        }
    }

    [Serializable]
    public class ItemInfo
    {
        public string title;
        public string description;

        public Item prefab;
    }
}