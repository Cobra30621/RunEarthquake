using UnityEngine;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] healthObjects;

        public void UpdateHealth(int health)
        {
            foreach (var healthObject in healthObjects)
            {
                healthObject.SetActive(false);
            }

            for (int i = 0; i < health; i++)
            {
                healthObjects[i].SetActive(true);
            }
        }
    }
}