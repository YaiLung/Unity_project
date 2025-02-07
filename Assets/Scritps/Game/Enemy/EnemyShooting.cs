using UnityEngine;

namespace EnemyNameSpace
{
    public class EnemyShooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float minFireRate = 1f;
        public float maxFireRate = 5f;

        private float nextFireTime;

        private void Start()
        {
            nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
        }

        private void Update()
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
            }
        }

        private void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
