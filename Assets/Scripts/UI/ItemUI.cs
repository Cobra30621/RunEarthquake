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
                if (itemInfo != null)
                {
                    images[i].sprite = itemInfo.sprite;
                }
                else
                {
                    images[i].sprite = null;
                }
            }
        }
    }
}