using System.Collections;
using Player;
using UnityEngine;

namespace Item
{
    public class SNSEffect : MonoBehaviour
    {
        [SerializeField] private SpeakingDisplay _speakingDisplay;
        [SerializeField] private Sprite leftSprite, rightSprite;

        public void Show()
        {
            StartCoroutine(ShowCoroutine());
        }

        IEnumerator ShowCoroutine()
        {
            _speakingDisplay.Show(leftSprite, rightSprite);
            PlayerController.SetCanMove(false);
            yield return new WaitForSeconds(3f);
            PlayerController.SetCanMove(true);
            _speakingDisplay.Close();
        }
    }
}