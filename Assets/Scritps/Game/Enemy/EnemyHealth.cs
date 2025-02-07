using UnityEngine;
using ScoreNameSpace;

namespace EnemyNameSpace
{
    public class EnemyHealth : Health
    {
        [SerializeField] private int startHealth = 10; 
        [SerializeField] private int scoreValue = 10; // Очки за уничтожение врага

        private void Start()
        {
            maxHealth = startHealth;
            currentHealth = maxHealth;
        }

        
        protected override void Die()
        {
            Debug.Log($"{gameObject.name} уничтожен!");

            // Начисляем очки 
            ScoreManager.Instance.AddScore(scoreValue);

          
            Destroy(gameObject);
        }
    }
}

