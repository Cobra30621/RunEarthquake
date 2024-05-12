using UnityEngine;

namespace Player
{
    public class SpeakingDisplay : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer leftSpeakingObject, rightSpeakingObject;
        
        public void Show(Sprite leftSprite, Sprite rightSprite)
        {
            if (PlayerController.CurrentRow == 2)
            {
                rightSpeakingObject.gameObject.SetActive(true);
                rightSpeakingObject.sprite = rightSprite;
            }
            else
            {
                leftSpeakingObject.gameObject.SetActive(true);
                leftSpeakingObject.sprite = leftSprite;
            }
        }

        public void Close()
        {
            rightSpeakingObject.gameObject.SetActive(false);
            leftSpeakingObject.gameObject.SetActive(false);
        }
    }
}