using UnityEngine;
using UnityEngine.UI;
using TMPro; //  TextMeshPro
namespace ScoreNameSpace
{
    public class ScoreUI : MonoBehaviour
    {
  [SerializeField] private TextMeshProUGUI currentScoreText; 
        [SerializeField] private TextMeshProUGUI highScoreText; 

        private void OnEnable()
        {
            if (ScoreManager.Instance != null) // Проверяем, что Instance не null
            {
                ScoreManager.Instance.OnScoreChanged += UpdateScoreUI;
                ScoreManager.Instance.OnHighScoreChanged += UpdateHighScoreUI;

                // Обновляем HighScore при старте
                UpdateHighScoreUI(ScoreManager.Instance.GetHighScore());
            }
            else
            {
                Debug.LogError("ScoreManager.Instance is null! ScoreUI подписывается слишком рано.");
            }
        }

        private void OnDisable()
        {
            // Отписка при деактивации объекта
            ScoreManager.Instance.OnScoreChanged -= UpdateScoreUI;
            ScoreManager.Instance.OnHighScoreChanged -= UpdateHighScoreUI;
        }

        private void UpdateScoreUI(int score)
        {
            currentScoreText.text = "Score: " + score;
        }

        private void UpdateHighScoreUI(int highScore)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }
}
