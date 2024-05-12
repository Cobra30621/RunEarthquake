using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLightEffect : MonoBehaviour
{
    [SerializeField] private GameObject blackPanel;

    [SerializeField] private float blackInterval;
    
    public void Use()
    {
        StartCoroutine(UseCoroutine());
    }

    private IEnumerator UseCoroutine()
    {
        blackPanel.SetActive(true);
        yield return new WaitForSeconds(blackInterval);
        blackPanel.SetActive(false);
    }
}
