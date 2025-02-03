using UnityEngine;

namespace EnemyNamespace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f; // Максимальное здоровье
        private float currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth; // Устанавливаем стартовое здоровье
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Enemy took {damage} damage. Current health: {currentHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Enemy died!");
            Destroy(gameObject); // Удаляем объект
        }
    }
}

