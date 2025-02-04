using UnityEngine;

namespace EnemyNamespace
{
    public class Enemy : MonoBehaviour
    {
        private EnemyMovement movementModule;
        private EnemyHealth healthModule;
        private EnemyAttack attackModule;

        [SerializeField] private Transform shootPoint; // Точка выстрела
        [SerializeField] private GameObject bulletPrefab; // Префаб пули

        private void Awake()
        {
            movementModule = new EnemyMovement(5f);
            healthModule = new EnemyHealth(100f, this);
            attackModule = new EnemyAttack(this, shootPoint, bulletPrefab, 1f); // Атака каждую 1 секунду
        }

        private void Update()
        {
            movementModule.Move(transform);
        }

        public void TakeDamage(float damage)
        {
            healthModule.TakeDamage(damage);
        }
    }
}


