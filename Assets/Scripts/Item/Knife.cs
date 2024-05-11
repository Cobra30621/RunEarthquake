using System;
using Map;
using UnityEngine;

namespace Item
{
    public class Knife : MonoBehaviour
    {      
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                var obstacle = other.GetComponent<Obstacle>();
                obstacle.DestroyObject();
            }
        }
    }
}