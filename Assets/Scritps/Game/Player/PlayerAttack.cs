using UnityEngine;

namespace PlayerNameSpace
{
    public class PlayerAttack
    {
        private Transform shootPoint;
        private GameObject bulletPrefab;

        public PlayerAttack(Transform shootPoint, GameObject bulletPrefab)
        {
            this.shootPoint = shootPoint;
            this.bulletPrefab = bulletPrefab;

            if (shootPoint == null)
            {
                Debug.LogError("PlayerAttack: ShootPoint is NULL! Assign it in the Inspector.");
            }
            if (bulletPrefab == null)
            {
                Debug.LogError("PlayerAttack: BulletPrefab is NULL! Assign it in the Inspector.");
            }
        }

        public void Attack()
        {
            if (shootPoint == null || bulletPrefab == null)
            {
                Debug.LogWarning("PlayerAttack: Cannot attack, shootPoint or bulletPrefab is null!");
                return;
            }

            GameObject bullet = Object.Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<BulletNamespace.Bullet>().SetDirection(Vector3.forward); // Летим вперёд
        }
    }
}
