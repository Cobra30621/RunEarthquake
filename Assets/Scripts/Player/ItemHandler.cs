using System.Linq;
using Core;
using Map;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class ItemHandler : SingletonWithSerialized<ItemHandler>
    {
        public static UnityEvent<ItemInfo[]> OnItemChanged = new UnityEvent<ItemInfo[]>();
        
        public ItemInfo[] items = new ItemInfo[4];

        [SerializeField] private GainItemUI _gainItemUI;
        
        [Button("獲得道具")]
        public void GainItem(ItemInfo info)
        {
            var index = items.ToList().FindIndex(item => item.itemType == ItemType.None);
            
            if (index != -1)
            {
                items[index] = new ItemInfo(info);
            }
            
            _gainItemUI.ShowUI(info);
            OnItemChanged.Invoke(items);
        }

        [Button("使用道具")]
        public void UseItem(int index)
        {
            if (items[index] != null)
            {
                Debug.Log($"使用道具 {items[index]}");
                items[index].itemType = ItemType.None;
            }
            
            OnItemChanged.Invoke(items);
        }

        public void InitItems()
        {
            for (var index = 0; index < items.Length; index++)
            {
                 items[index].itemType = ItemType.None;
            }
        }
        
    }
}