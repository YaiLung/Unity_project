using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerNameSpace
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement movementModule;
        private PlayerShooting shootingModule;
        private PlayerInput playerInput;

        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        private float fireRate = 1f;

        private void Awake()
        {
            playerInput = new PlayerInput();
            movementModule = new PlayerMovement(playerInput, 5f);
            shootingModule = new PlayerShooting(playerInput, firePoint, bulletPrefab, fireRate);
        }

        private void Update()
        {
            movementModule.Move(transform);
        }
    }
}
