using UnityEngine;

namespace PlayerNameSpace
{
    public class PlayerAttack
    {
        private Transform shootPoint; // Точка выстрела (например, перед игроком)
        private GameObject bulletPrefab; // Префаб пули
        private float bulletSpeed = 10f; // Скорость пули

        public PlayerAttack(Transform shootPoint, GameObject bulletPrefab)
        {
            this.shootPoint = shootPoint;
            this.bulletPrefab = bulletPrefab;
        }

        public void Attack()
        {
            if (bulletPrefab == null || shootPoint == null)
            {
                Debug.LogWarning("Bullet prefab or shoot point is not assigned!");
                return;
            }

            // Создаем пулю
            GameObject bullet = GameObject.Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            // Добавляем движение пули
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootPoint.forward * bulletSpeed; // Двигаем пулю вперед
            }

            Debug.Log("Player attacks!");
        }
    }
}
