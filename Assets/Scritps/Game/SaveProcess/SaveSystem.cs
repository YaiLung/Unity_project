using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Игра сохранена: {savePath}");
    }

    public static GameData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        Debug.LogWarning("Сейв не найден!");
        return null;
    }
}
