using System.Collections;
using UnityEngine;

namespace Item
{
    public class HandEffect : MonoBehaviour
    {
        [SerializeField] private GameObject knifeCollider;
        [SerializeField] private Animator _animator;

        public void Use()
        {
            StartCoroutine(Show());
        }

        IEnumerator Show()
        {
            _animator.SetTrigger("Show");
            knifeCollider.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            knifeCollider.SetActive(false);
        }
    }
}