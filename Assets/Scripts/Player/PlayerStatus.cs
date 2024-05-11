using UnityEngine.Events;

namespace Player
{
    public class PlayerStatus
    {
        public int health;
        public int maxHealth = 3;

        public int score;
        
        public static UnityEvent<int> OnHealthChanged;
        
        private static PlayerStatus _instance;
        public static PlayerStatus Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerStatus();
                }
                return _instance;
            }
        }
        
        public void Init()
        {
            score = 0;
            health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
            }
            
            OnHealthChanged.Invoke(health);
        }

        public void Heal(int heal)
        {
            health += heal;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            
            OnHealthChanged.Invoke(health);
        }
    }
}