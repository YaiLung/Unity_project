using UnityEngine;
using PlayerNameSpace;

namespace EnemyNameSpace
{
    public class EnemyMovement
    {
        private float _speed;  
        private Transform enemyTransform;
        private Transform playerTransform;

        public EnemyMovement(Transform enemy, Transform player, float speed)
        {
            enemyTransform = enemy;
            playerTransform = player;
            _speed = speed;  
        }

        public void Move()
        {
            if (playerTransform == null) return;

            // Двигаем врага назад по оси Z 
            enemyTransform.position += Vector3.back * _speed * Time.deltaTime;

            // Если враг находится достаточно близко к игроку по оси Z
            if (Mathf.Abs(enemyTransform.position.z - playerTransform.position.z) < 0.1f)
            {
                // Наносим  урон игроку
                if (playerTransform.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.TakeDamage(10);
                }

               
                Object.Destroy(enemyTransform.gameObject);
            }
        }
    }
}




