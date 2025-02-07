using UnityEngine;
using UnityEngine.UI;

public class GameWinUI : MonoBehaviour
{
    public Text currentScoreText;
    public Text highScoreText;

    private void Start()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Обновляем текст на UI
        currentScoreText.text = "Current Score: " + currentScore;
        highScoreText.text = "High Score: " + highScore;
    }
}

