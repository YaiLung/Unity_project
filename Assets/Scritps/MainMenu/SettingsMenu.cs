using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button easyButton;
    [SerializeField] private Button hardButton;

    private void Start()
    {
        easyButton.onClick.AddListener(() => SetDifficulty("Easy"));
        hardButton.onClick.AddListener(() => SetDifficulty("Hard"));
    }

    private void SetDifficulty(string difficulty)
    {
        if (GameSettings.Instance != null)
        {
            GameSettings.Instance.SetDifficulty(difficulty);
            Debug.Log("Выбрана сложность: " + difficulty);
        }
    }
}
