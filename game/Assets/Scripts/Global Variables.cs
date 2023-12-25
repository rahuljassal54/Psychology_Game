using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int hen_caught;
    public static int[] materials; 
    /*  0 - wood, 1 - metal, 2 - stone, 3 - paintbuckets, 4 - cement */
    void Start()
    {
        hen_caught = 0;
        materials = new int[5] {0,0,0,0,0};
    }
    
    public void IncreaseAsset(int itemIndex, int quantity){
        materials[itemIndex] += quantity;
    }

}
