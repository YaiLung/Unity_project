using UnityEngine;
using UnityEngine.UI;

public class PlayerSave : MonoBehaviour
{
    public int score; // Очки игрока
    public Text saveMessage; // UI текст 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        GameData data = new GameData
        {
            score = score,
            playerX = transform.position.x,
            playerY = transform.position.y,
            playerZ = transform.position.z
        };

        SaveSystem.SaveGame(data);

        if (saveMessage)
        {
            saveMessage.text = "Игра сохранена!";
            Invoke(nameof(ClearMessage), 2f);
        }
    }

    private void ClearMessage()
    {
        saveMessage.text = "";
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        if (data != null)
        {
            score = data.score;
            transform.position = new Vector3(data.playerX, data.playerY, data.playerZ);
        }
    }
}
