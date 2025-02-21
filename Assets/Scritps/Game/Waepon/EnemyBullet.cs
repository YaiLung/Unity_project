using UnityEngine;
using PlayerNameSpace;

namespace EnemyNameSpace
{
    public class EnemyBullet : MonoBehaviour
    {
        public float speed = 10f;
        public int damage = 10;
        public float destroyAfter = 5f;

        private void Start()
        {
            Destroy(gameObject, destroyAfter);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent<IDamageable>(out var player))
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
