using System.Collections;
using UnityEngine;

namespace Item
{
    public class KnifeEffect : MonoBehaviour
    {
        [SerializeField] private GameObject knifeCollider;
        [SerializeField] private Animator _animator;

        public void ShowKnife(float x)
        {
            var position = knifeCollider.transform.position;
            position = new Vector3(x, position.y, position.z);
            knifeCollider.transform.position = position;
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