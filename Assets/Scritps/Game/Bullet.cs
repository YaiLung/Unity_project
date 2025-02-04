using UnityEngine;

namespace BulletNamespace
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public float damage = 10f;
        public float lifetime = 3f;

        private Vector3 direction = Vector3.forward; // По умолчанию пуля летит вперёд

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }

        private void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        public void SetDirection(Vector3 newDirection)
        {
            direction = newDirection.normalized; // Нормализация вектора
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<EnemyNamespace.Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                Destroy(gameObject);
            }

            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<PlayerNameSpace.Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
