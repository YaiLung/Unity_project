using UnityEngine;
using UnityEngine.SceneManagement; 

namespace PlayerNameSpace
{
    public class PlayerHealth : Health
    {
        [SerializeField] private int startHealth = 100;

        private void Start()
        {
            maxHealth = startHealth;
            currentHealth = maxHealth;
        }

        protected override void Die()
        {
            Debug.Log("Игрок погиб! ");
            SceneManager.LoadScene("GameOver"); // Загружаем сцену GameOver
        }
    }
}
