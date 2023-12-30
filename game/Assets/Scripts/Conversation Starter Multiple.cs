using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class ConversationStarterMultiple : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation1;
    public NPCConversation myConversation2;
    public NPCConversation myConversation3;
    public int npcNumber;

    public static bool[] ConvoDoneBools;
    void Start(){
        ConvoDoneBools = new bool[4] {false,false,false,false};
    }
    private bool allHensCollected(){
        return GlobalVariables.hen_caught == 5;
    }
    public void ConvoDone(int index){
       ConvoDoneBools[index] = true;
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            if(Input.GetAxis("Interact") != 0){
                switch (npcNumber){
                    case 1:
                        if(!ConvoDoneBools[0]) ConversationManager.Instance.StartConversation(myConversation1);
                        else ConversationManager.Instance.StartConversation(myConversation2);
                        break;
                    case 2:
                        ConversationManager.Instance.StartConversation(myConversation1);
                        break;
                    case 3:
                        ConversationManager.Instance.StartConversation(myConversation1);
                        break;
                    case 4:
                        if(!ConvoDoneBools[0])ConversationManager.Instance.StartConversation(myConversation1);
                        else if(!allHensCollected()) ConversationManager.Instance.StartConversation(myConversation2);
                        else ConversationManager.Instance.StartConversation(myConversation3);
                        break;

                }
                
            }
        }
    }
}
