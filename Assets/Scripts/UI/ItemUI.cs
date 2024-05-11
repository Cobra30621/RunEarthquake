using System;
using System.Collections.Generic;
using Map;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemUI : MonoBehaviour
    {
        [SerializeField] private Image[] images = new Image [4];


        private void Start()
        {
            ItemHandler.OnItemChanged.AddListener(UpdateUI);
        }

        private void UpdateUI(ItemInfo[] itemInfos)
        {
            for (int i = 0; i < itemInfos.Length; i++)
            {
                var itemInfo = itemInfos[i];
                if (itemInfo.itemType != ItemType.None)
                {
                    images[i].gameObject.SetActive(true);
                    images[i].sprite = itemInfo.sprite;
                }
                else
                {
                    images[i].gameObject.SetActive(false);
                }
            }
        }
    }
}