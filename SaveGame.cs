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
    public int steel;
    public int rocks;
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
        data.playerPosX = playerTransform.position.x;
        data.playerPosY = playerTransform.position.y;
        data.npc1Completed = npc1Completed;
        data.npc2Completed = npc2Completed;
        data.npc3Completed = npc3Completed;
        data.coins = playerInventory.coins;
        data.cement = playerInventory.cement;
        data.paint = playerInventory.paint;
        data.wood = playerInventory.wood;
        data.steel = playerInventory.steel;
        data.rocks = playerInventory.rocks;
        data.house1Progress = house1Progress;
        data.house2Progress = house2Progress;
        data.house3Progress = house3Progress;

        // Convert data to JSON...we can do txt too but JSON IS BETTER
        string jsonData = JsonUtility.ToJson(data);

        // Save to file
        string filePath = Application.persistentDataPath + "/" + playerName + ".json";
        File.WriteAllText(filePath, jsonData);
    }

    // variables for player transform, inventory, and progression here..all other data to be added
}
