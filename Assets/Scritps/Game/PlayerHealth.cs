using System.Collections;
using System.Collections.Generic;
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
            if (CurrentHealth <= 0)
            {
                // Игрок умирает
            }
        }

        public void Heal(float amount)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + amount, MaxHealth);
        }
    }
}
