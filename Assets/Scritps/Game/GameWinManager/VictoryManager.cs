using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private float winTime = 30f; // Время до победы

    private void Start()
    {
        Invoke(nameof(WinGame), winTime); // Запускаем таймер
    }

    private void WinGame()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
            int highScore = PlayerPrefs.GetInt("HighScore", 0);

            if (currentScore > highScore)
            {
                PlayerPrefs.SetInt("HighScore", currentScore);
            }

            PlayerPrefs.Save();
            SceneManager.LoadScene("GameWin");
        }
    }
}

