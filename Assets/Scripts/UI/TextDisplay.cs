using System.Collections;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextDisplay : SingletonWithSerialized<TextDisplay>
    {
        [SerializeField] private GameObject box;
        [SerializeField] private TextMeshProUGUI text;
        
        public IEnumerator ShowText(string info, float interval)
        {
            box.SetActive(true);
            text.text = info;
            
            yield return new WaitForSeconds(interval);
            
            box.SetActive(false);
        }
    }
}