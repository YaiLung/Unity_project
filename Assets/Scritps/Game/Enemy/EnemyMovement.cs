using UnityEngine;

namespace EnemyNamespace
{
    public class EnemyMovement
    {
        private float speed;

        public EnemyMovement(float speed)
        {
            this.speed = speed;
        }

        public void Move(Transform transform)
        {
            transform.position += Vector3.back * speed * Time.deltaTime; // Двигаем врага назад по Z
        }
    }
}

