using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public void Use()
    {
        StartCoroutine(UseCoroutine());
    }

    private IEnumerator UseCoroutine()
    {
        MapHandler.Instance.SetSlowDown(true);
        yield return new WaitForSeconds(5f);
        MapHandler.Instance.SetSlowDown(false);
    }
}
