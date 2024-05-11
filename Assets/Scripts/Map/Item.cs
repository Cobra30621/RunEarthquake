using Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Map
{
    public class Item : MapObject
    {
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
            ItemHandler.Instance.GainItem(ItemInfo);
            MapHelper.DestroyAllItems();
        }
    }
}

public enum ItemType
{
    None,
    Food,
    Knife,
    Light,
    Hand,
    SNS,
    DeadlineJob,
    BrokenLight,
    
}