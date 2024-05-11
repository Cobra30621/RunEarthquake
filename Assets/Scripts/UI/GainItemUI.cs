using Core;
using GameProgress;
using Map;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GainItemUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI ItemTitle, ItemDiscription;
        [SerializeField]
        private Image Icon;
        public ItemInfo test;
        [Button("測試 UI")]
        public void ShowUI()
        {
            ShowUI(test);
        }




        [Button("顯示 UI")]
        public void ShowUI(ItemInfo info)
        {
            ItemTitle.text = info.title;
            ItemDiscription.text = info.description;
            Icon.sprite = info.sprite;
        }
        
    }
}