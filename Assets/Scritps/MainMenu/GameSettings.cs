using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    private const string DifficultyKey = "GameDifficulty"; // Ключ для сохранения сложности

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при смене сцен
        }
        else
        {
            Destroy(gameObject); // Удаляем дубликаты
        }
    }

    public void SetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString(DifficultyKey, difficulty);
        PlayerPrefs.Save();
    }

    public void LoadDifficulty()
    {
        string difficulty = PlayerPrefs.GetString(DifficultyKey, "Easy"); // По умолчанию "Easy"

        if (difficulty == "Easy")
        {
            Time.timeScale = 1f;
        }
        else if (difficulty == "Hard")
        {
            Time.timeScale = 1.5f;
        }

        Debug.Log("Текущая сложность: " + difficulty);
    }
}

