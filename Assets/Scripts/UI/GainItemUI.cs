using System.Collections;
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
        private GameObject mainPanel;
        [SerializeField]
        private TextMeshProUGUI ItemTitle, ItemDiscription;
        [SerializeField]
        private Image Icon;

        [LabelText("顯示時間")]
        public float displayInterval = 2f;

        [Button("顯示 UI")]
        public void ShowUI(ItemInfo info)
        {
            ItemTitle.text = info.title;
            ItemDiscription.text = info.description;
            Icon.sprite = info.sprite;

            StartCoroutine(ShowCoroutine());
        }

        IEnumerator ShowCoroutine()
        {
            mainPanel.SetActive(true);
            yield return new WaitForSeconds(displayInterval);
            mainPanel.SetActive(false);
        }
        
    }
}