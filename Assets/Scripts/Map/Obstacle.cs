using Player;
using Sirenix.OdinInspector;

namespace Map
{
    public class Obstacle : MapObject
    {
        [Button("玩家進入")]
        protected override void OnPlayerEnter()
        {
            PlayerStatus.Instance.TakeDamage(1);
            
            Destroy(gameObject);
        }
    }
}