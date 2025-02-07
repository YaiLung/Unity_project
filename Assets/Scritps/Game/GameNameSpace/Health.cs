using UnityEngine;
using PlayerNameSpace;
public abstract class Health : MonoBehaviour, IDamageable
{
    protected int maxHealth;
    protected int currentHealth;

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Выводим сообщение только если это игрок
        if (this is PlayerHealth)
        {
            Debug.Log($"[Игрок] Получен урон: {damage}. Текущее здоровье: {currentHealth}");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

