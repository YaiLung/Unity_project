using UnityEngine;
using System;

namespace ScoreNameSpace
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public event Action<int> OnScoreChanged; // Событие изменения очков
        public event Action<int> OnHighScoreChanged; // Событие для HighScore

        private int currentScore;
        private int highScore;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            highScore = PlayerPrefs.GetInt("HighScore", 0); // Загружаем рекорд
        }


        public void AddScore(int amount)
        {
            currentScore += amount;

            
            Debug.Log($"Очки начислены. Текущий счет: {currentScore}");

            OnScoreChanged?.Invoke(currentScore); // Вызываем событие для обновления UI

            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
                OnHighScoreChanged?.Invoke(highScore);
            }
        }

        public int GetHighScore() => highScore;
    }
}
