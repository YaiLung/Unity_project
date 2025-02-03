using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f; // Урон пули
    public float lifetime = 3f; // Время жизни пули

    private void Start()
    {
        Destroy(gameObject, lifetime); // Удаляем пулю через несколько секунд
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Проверяем, если пуля попала во врага
        {
            EnemyNamespace.Enemy enemy = other.GetComponent<EnemyNamespace.Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject); // Уничтожаем пулю при попадании
        }
    }
}
