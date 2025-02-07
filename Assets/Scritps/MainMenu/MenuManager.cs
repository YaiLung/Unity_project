using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        LoadingManager.LoadScene("Game"); // Загружаем через сцену загрузки
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player quit");
    }
}
