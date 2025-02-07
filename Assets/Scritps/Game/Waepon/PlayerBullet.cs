using UnityEngine;
using EnemyNameSpace;  

namespace PlayerNameSpace
{
    public class PlayerBullet : MonoBehaviour
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
           
            if (other.CompareTag("Enemy") && other.TryGetComponent<IDamageable>(out var enemy))
            {
                enemy.TakeDamage(damage);  // Наносим урон 
                Destroy(gameObject);  
            }
        }
    }
}

