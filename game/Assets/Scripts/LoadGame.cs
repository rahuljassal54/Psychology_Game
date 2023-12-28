using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadGame : MonoBehaviour
{
    public Transform contentPanel;
    public Button loadButtonPrefab;//so that we can directly interface with the main and pause menus

    void Start()
    {
        LoadSavedGames();
    }

    void LoadSavedGames()
    {
        // Get all save files in the persistent data path(the save folder where we store our stuff)
        string[] saveFiles = Directory.GetFiles(Application.persistentDataPath, "*.json");

        foreach (string filePath in saveFiles)
        {
            // Extract player name from file name
            string playerName = Path.GetFileNameWithoutExtension(filePath);

            // Create a load button for each save file
            CreateLoadButton(playerName);
        }
    }//above code will help to read the stuff from our save folder and show all....we then have buttons for every name in the save directory

    void CreateLoadButton(string playerName)
    {
        Button loadButton = Instantiate(loadButtonPrefab, contentPanel);
        loadButton.GetComponentInChildren<Text>().text = playerName;

        // Add a listener to the load button to handle loading the selected save
        loadButton.onClick.AddListener(() => LoadSelectedGame(playerName));
    }

    void LoadSelectedGame(string playerName)
    {
        // Load the selected player's save data
        string filePath = Application.persistentDataPath + "/" + playerName + ".json";
        string jsonData = File.ReadAllText(filePath);

        // Deserialize JSON data
        PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(jsonData);

        // Use the loaded data to set the game state(we need to do this later...)
    }
}
