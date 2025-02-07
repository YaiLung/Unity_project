using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (GameSettings.Instance != null)
        {
            GameSettings.Instance.LoadDifficulty(); // Загружаем сохраненную сложность
            Debug.Log("Сложность загружена: " + Time.timeScale);
        }
        else
        {
            Debug.LogWarning("GameSettings.Instance не найден! Установлена сложность по умолчанию.");
        }
    }
}
