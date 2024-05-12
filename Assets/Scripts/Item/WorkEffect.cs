using System.Collections;
using Player;
using UnityEngine;

namespace Item
{
    public class WorkEffect : MonoBehaviour
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
            PlayerController.SetReserveMove(false);
            yield return new WaitForSeconds(10f);
            PlayerController.SetReserveMove(true);
            _speakingDisplay.Close();
        }
    }
}