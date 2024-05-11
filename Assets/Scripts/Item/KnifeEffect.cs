using System.Collections;
using UnityEngine;

namespace Item
{
    public class KnifeEffect : MonoBehaviour
    {
        [SerializeField] private GameObject knife;

        public void ShowKnife(float x)
        {
            var position = knife.transform.position;
            position = new Vector3(x, position.y, position.z);
            knife.transform.position = position;
            StartCoroutine(Show());
        }

        IEnumerator Show()
        {
            knife.SetActive(true);
            yield return new WaitForSeconds(1f);
            knife.SetActive(false);
        }
    }
}