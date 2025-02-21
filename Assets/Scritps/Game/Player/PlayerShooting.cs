using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerNameSpace
{
    public class PlayerShooting
    {
        private PlayerInput playerInput;
        private Transform firePoint;
        private GameObject bulletPrefab;
        private float fireRate;
        private float nextFireTime = 0f;

        public PlayerShooting(PlayerInput input, Transform firePoint, GameObject bulletPrefab, float fireRate)
        {
            playerInput = input;
            this.firePoint = firePoint;
            this.bulletPrefab = bulletPrefab;
            this.fireRate = fireRate;

            playerInput.GamePlay.Attack.performed += _ => Shoot();
        }

        private void Shoot()
        {
            if (Time.time < nextFireTime) return;

            Object.Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }
}
