using System.Collections;
using Player;
using UnityEngine;

namespace Item
{
    public class WorkEffect : MonoBehaviour
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
            PlayerController.SetReserveMove(true);
            yield return new WaitForSeconds(10f);
            PlayerController.SetReserveMove(false);
            _speakingDisplay.Close();
        }
    }
}