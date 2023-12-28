using System;
using System.IO;
using UnityEngine;

[Serializable] //kept for ease of file conversion
public class PlayerSaveData
{
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ; 
    public bool npc1Completed;//3 boolean variables for if we have spoken to npcs...might not be needed
    public bool npc2Completed;
    public bool npc3Completed;
    public int coins;//inventory items
    public int cement;
    public int paint;
    public int wood;
    public int metal;
    public int stone;
    public int house1Progress;//progress of the 3 houses
    public int house2Progress;
    public int house3Progress;
}

public class SaveGame : MonoBehaviour
{
    public void SavePlayerProgress(string playerName)
    {
        PlayerSaveData data = new PlayerSaveData();
        // Set data from your game variables
        data.playerPosX = GlobalVariables.player.position.x;
        data.playerPosY = GlobalVariables.player.position.y;
        data.npc1Completed = GlobalVariables.npcCompleted[0];
        data.npc2Completed = GlobalVariables.npcCompleted[1];
        data.npc3Completed = GlobalVariables.npcCompleted[2];
        data.coins = GlobalVariables.coins;
        data.wood = GlobalVariables.materials[0];
        data.metal = GlobalVariables.materials[1];
        data.stone = GlobalVariables.materials[2];
        data.paint = GlobalVariables.materials[3];
        data.cement = GlobalVariables.materials[4];
        data.house1Progress = GlobalVariables.houseProgress[0];
        data.house2Progress = GlobalVariables.houseProgress[1];
        data.house3Progress = GlobalVariables.houseProgress[2];

        // Convert data to JSON...we can do txt too but JSON IS BETTER
        string jsonData = JsonUtility.ToJson(data);

        // Save to file
        string filePath = Application.persistentDataPath + "/" + playerName + ".json";
        File.WriteAllText(filePath, jsonData);
    }

    // variables for player transform, inventory, and progression here..all other data to be added
}
