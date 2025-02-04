using UnityEngine;

namespace PlayerNameSpace
{
    public class PlayerHealth
    {
        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public PlayerHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log($"Player took {amount} damage. Current health: {CurrentHealth}");

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + amount, MaxHealth);
        }

        private void Die()
        {
            Debug.Log("Player died!");
            // Уничтожаем объект игрока
            // Важно! PlayerHealth сам по себе не MonoBehaviour, так что нужно передавать объект в Player
        }
    }
}
