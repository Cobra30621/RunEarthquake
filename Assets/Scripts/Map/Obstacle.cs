using System;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Map
{
    public class Obstacle : MapObject
    {
        [Required]
        [SerializeField] private Rigidbody2D rd;

        private void Awake()
        {
            rd = GetComponent<Rigidbody2D>();
        }

        [Button("玩家進入")]
        protected override void OnPlayerEnter()
        {
            PlayerStatus.Instance.TakeDamage(1);
            
            DestroyObject();
        }

        public void AddForce(float x, float power)
        {
            var xForce = x - transform.position.x > 0 ? -1 : 1;
            rd.AddForce(new Vector2( xForce * power, 0), ForceMode2D.Impulse);
        }
        

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}