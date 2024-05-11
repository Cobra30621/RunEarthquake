using UnityEngine.Events;

namespace Player
{
    public class PlayerStatus
    {
        public int health;
        public int maxHealth = 3;

        public int score;
        
        public static UnityEvent<int> OnHealthChanged = new UnityEvent<int>();
        public static UnityEvent OnGameOver = new UnityEvent();
        
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
            SetHealth(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            SetHealth(health - damage);
        }

        public void Heal(int heal)
        {
            SetHealth(health + heal);
        }

        private void SetHealth(int value)
        {
            health = value;
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            if (health <= 0)
            {
                health = 0;
                OnGameOver.Invoke();
            }
            
            OnHealthChanged.Invoke(health);
        }
    }
}