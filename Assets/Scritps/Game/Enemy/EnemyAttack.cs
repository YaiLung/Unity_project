using UnityEngine;

namespace EnemyNamespace
{
    public class EnemyAttack
    {
        private Enemy enemy;
        private Transform shootPoint;
        private GameObject bulletPrefab;
        private float attackInterval;

        public EnemyAttack(Enemy enemy, Transform shootPoint, GameObject bulletPrefab, float attackInterval)
        {
            this.enemy = enemy;
            this.shootPoint = shootPoint;
            this.bulletPrefab = bulletPrefab;
            this.attackInterval = attackInterval;

            enemy.StartCoroutine(AttackRoutine());
        }

        private System.Collections.IEnumerator AttackRoutine()
        {
            while (enemy != null)
            {
                Attack();
                yield return new WaitForSeconds(attackInterval);
            }
        }

        public void Attack()
        {
            if (shootPoint == null || bulletPrefab == null)
            {
                Debug.LogWarning("EnemyAttack: Cannot attack, shootPoint or bulletPrefab is null!");
                return;
            }

            GameObject bullet = Object.Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<BulletNamespace.Bullet>().SetDirection(Vector3.back); // Летим назад
        }
    }
    
}
