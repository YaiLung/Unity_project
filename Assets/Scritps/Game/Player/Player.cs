using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerNameSpace
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement movementModule;
        private PlayerHealth healthModule;
        private PlayerAttack attackModule;
        private PlayerInput playerInput;

        [SerializeField] private Transform shootPoint; // Точка выстрела
        [SerializeField] private GameObject bulletPrefab; // Префаб пули

        private void Awake()
        {
            playerInput = new PlayerInput();
            playerInput.GamePlay.Enable();

            movementModule = new PlayerMovement(playerInput, 5f);
            healthModule = new PlayerHealth(100f);
            attackModule = new PlayerAttack(shootPoint, bulletPrefab);
        }

        private void Update()
        {
            movementModule.Move(transform);

            if (playerInput.GamePlay.Attack.triggered)
            {
                attackModule.Attack();
            }
        }

        public void TakeDamage(float amount) // Добавили метод
        {
            healthModule.TakeDamage(amount);
        }
    }
}


