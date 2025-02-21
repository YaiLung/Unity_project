using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        if (data != null)
        {
            SceneManager.LoadScene("Game"); // Загружаем игру, если есть сохранение
        }
        else
        {
            Debug.LogWarning("Нет сохраненной игры!");
        }
    }

   
}
