using Sirenix.OdinInspector;
using UnityEngine;

namespace Map
{
    public class Item : MapObject
    {
        public ItemType ItemType;

        public ItemInfo ItemInfo;

        public void SetItemInfo(ItemInfo itemInfo)
        {
            ItemInfo = itemInfo;
        }
        
        [Button("玩家進入")]
        protected override void OnPlayerEnter()
        {
            Debug.Log("獲得道具");
            
            // Destroy(gameObject);
            MapHelper.DestroyAllItems();
        }
    }
}

public enum ItemType
{
    Food,
    Knife,
    Light,
    Hand
}