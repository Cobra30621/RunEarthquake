using System.Linq;
using Core;
using Item;
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
        
        [SerializeField] private MapHandler _mapHandler;
        
        [Title("道具效果")]
        [SerializeField] private KnifeEffect _knifeEffect;

        [SerializeField] private SNSEffect _snsEffect;
        [SerializeField] private WorkEffect _deadlineJobEffect;
        
        
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

        public void UseItem(int index)
        {
            var itemType = items[index].itemType;
            if (itemType == ItemType.None)
            {
                return;
            }
            
            AudioManager.Instance.PlaySE(items[index].useSE);
            UseItem(itemType);
            items[index] = new ItemInfo();
            
            OnItemChanged.Invoke(items);
        }
        
        [Button("使用道具")]
        
        public void UseItem(ItemType itemType)
        {
            Debug.Log($"使用道具 {itemType}");
            
            switch (itemType)
            {
                case ItemType.Food:
                    PlayerStatus.Instance.Heal(1);
                    break;
                case ItemType.Hand:
                    break;
                case ItemType.Knife:
                    var currentRow = PlayerController.CurrentRow;
                    var x = _mapHandler.GetSingleRow(currentRow).position.x;
                    _knifeEffect.ShowKnife(x);
                    break;
                case ItemType.Light:
                    break;
                case ItemType.SNS:
                    _snsEffect.Show();
                    break;
                case ItemType.DeadlineJob:
                    _deadlineJobEffect.Show();
                    break;
            }
            
            OnItemChanged.Invoke(items);
        }

        public void InitItems()
        {
            for (var index = 0; index < items.Length; index++)
            {
                 items[index].itemType = ItemType.None;
            }
            
            OnItemChanged.Invoke(items);
        }
        
    }
}