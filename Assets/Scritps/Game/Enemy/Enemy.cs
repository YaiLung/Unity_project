using UnityEngine;
using System;

namespace EnemyNameSpace
{
    public class Enemy : MonoBehaviour
    {
        public static event Action<Enemy> OnEnemyDestroyed; //  Событие уничтожения

        private EnemyMovement movementModule;

        [SerializeField] private float moveSpeed = 2f;

        private void Awake()
        {
            Transform player = GameObject.FindWithTag("Player")?.transform;

            if (player != null)
            {
                movementModule = new EnemyMovement(transform, player, moveSpeed);
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }

        private void Update()
        {
            movementModule?.Move();
        }

        private void OnDestroy()
        {
            OnEnemyDestroyed?.Invoke(this); //    враг уничтожен
        }
    }
}

