using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int hen_caught;
    public static bool tic_tac_toe_wun;
    public static Vector3 playerPosition;
    public static bool[] npcCompleted;
    public static int coins;
    public static int[] houseProgress;
    public static int[] materials; 
    public static LinkedList<Emotion> EmotionTracker;
    public static Transform playerObj; // assign the chosen player here, load script will give position to this
    public static Transform player; // original coordinates

    // todo : define the initial spawning place of the person
    /*  0 - wood, 1 - metal, 2 - stone, 3 - paintbuckets, 4 - cement */
    void Start()
    {
        hen_caught = 0;
        tic_tac_toe_wun = false;
        materials = new int[5] {15,18,13,12,14};
        houseProgress = new int[3] {0,0,0};
        coins = 0;
        EmotionTracker = new LinkedList<Emotion>();
        npcCompleted = new bool[4] {false, false, false, false};
    }
    
    public void IncreaseAsset(int itemIndex, int quantity){
        materials[itemIndex] += quantity;
    }
    public void AddEmotion(string e){
        Emotion emotion = new Emotion(e, System.DateTime.Now);
        EmotionTracker.AddLast(emotion);
    }
}
[System.Serializable]
public class Emotion{
    public string emotion;
    public System.DateTime dateTime;

    public Emotion(string e, System.DateTime d){
        emotion = e;
        dateTime = d;
    }

}
