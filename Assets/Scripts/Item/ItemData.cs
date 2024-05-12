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
        public ItemType itemType;
        public string title;
        public string description;

        public Sprite sprite;
        public Item prefab;

        public SE useSE;

        public ItemInfo()
        {
            
        }
        
        public ItemInfo(ItemInfo info)
        {
            itemType = info.itemType;
            title = info.title;
            description = info.description;
            sprite = info.sprite;
        }
    }
}