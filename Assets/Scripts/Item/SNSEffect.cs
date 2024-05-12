using System.Collections;
using Player;
using UnityEngine;

namespace Item
{
    public class SNSEffect : MonoBehaviour
    {
        [SerializeField] private SpeakingDisplay _speakingDisplay;
        [SerializeField] private Sprite [] leftSprites, rightSprites;

        public void Use()
        {
            StartCoroutine(ShowCoroutine());
        }

        IEnumerator ShowCoroutine()
        {
            var index = Random.Range(0, leftSprites.Length);
            
            _speakingDisplay.Show(leftSprites[index], rightSprites[index]);
            PlayerController.SetCanMove(false);
            yield return new WaitForSeconds(3f);
            PlayerController.SetCanMove(true);
            _speakingDisplay.Close();
        }
    }
}