using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public Slider progressBar; // Слайдер для отображения прогреса
    private static string sceneToLoad; // Название сцены которую загружае

    public static void LoadScene(string sceneName)
    {
        sceneToLoad = sceneName;
        SceneManager.LoadScene("Loading"); // Загружаем сцену загрузки
    }

    private void Start()
    {
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("Scene to load is not set!");
            yield break;
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false; // Ждём пока загрузка завершится

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Прогресс загрузки 
            progressBar.value = progress; // Обновляем слайдер

            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f); // Короткая пауза перед переходом
                operation.allowSceneActivation = true; // Загружаем сцену
            }

            yield return null;
        }
    }
}
