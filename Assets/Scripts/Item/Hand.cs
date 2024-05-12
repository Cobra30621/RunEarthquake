using Map;
using UnityEngine;

namespace Item
{
    public class Hand : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                var obstacle = other.GetComponent<Obstacle>();
                obstacle.AddForce(transform.position.x, 10f);
            }
        }
    }
}