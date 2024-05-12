using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class CameraShake : MonoBehaviour
    {
        public float magnitude;

        public bool isShaking = false;


        private void Update()
        {
            if (!isShaking)
            {
                return;
            }
            
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
 

        }

        [Button("開始晃動")]
        public void SetShake(bool shake)
        {
            isShaking = shake;
            transform.position = new Vector3(0, 0, -10f);
        }
   
    }
}