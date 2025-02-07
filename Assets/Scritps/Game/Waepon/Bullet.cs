using UnityEngine;

namespace GameNameSpace
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public int damage = 1;

        private void Update()
        {
            // Перемещаем пулю по оси Z
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

