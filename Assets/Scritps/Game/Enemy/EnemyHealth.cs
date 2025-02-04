using UnityEngine;

namespace EnemyNamespace
{
    public class EnemyHealth
    {
        private float currentHealth;
        private Enemy enemy;

        public EnemyHealth(float maxHealth, Enemy enemy)
        {
            currentHealth = maxHealth;
            this.enemy = enemy;
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
            GameObject.Destroy(enemy.gameObject); // Удаляем объект врага
        }
    }
}

