using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadGame : MonoBehaviour
{
    public Transform contentPanel;
    public Transform player;
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

        player.position = new Vector3(data.playerPosX, data.playerPosY, data.playerPosZ);
        GlobalVariables.npcCompleted[0] = data.npc1Completed;
        GlobalVariables.npcCompleted[1] = data.npc2Completed;
        GlobalVariables.npcCompleted[2] = data.npc3Completed;
        GlobalVariables.npcCompleted[3] = data.npc4Completed;
        GlobalVariables.npcCompleted[4] = data.npc5Completed;
        GlobalVariables.materials[0] = data.wood;
        GlobalVariables.materials[1] = data.metal;
        GlobalVariables.materials[2] = data.stone;
        GlobalVariables.materials[3] = data.paint;
        GlobalVariables.materials[4] = data.cement;
        GlobalVariables.houseProgress[0] = data.house1Progress;
        GlobalVariables.houseProgress[1] = data.house2Progress;
        GlobalVariables.houseProgress[2] = data.house3Progress;
        GlobalVariables.tictac = data.tictac;

        // Use the loaded data to set the game state(we need to do this later...)
    }
}
