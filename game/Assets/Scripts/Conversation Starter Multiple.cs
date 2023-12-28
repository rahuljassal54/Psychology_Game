using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class ConversationStarterMultiple : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation1;
    [SerializeField] private NPCConversation myConversation2;
    [SerializeField] private NPCConversation myConversation3;

    public static bool firstConvoDoneBool;
    void Start(){
        firstConvoDoneBool = false;
    }

    private bool allHensCollected(){
        Debug.Log("oops only : " + GlobalVariables.hen_caught);
        return GlobalVariables.hen_caught == 5;
    }
    public void firstConvoDone(){
        firstConvoDoneBool = true;
    }
    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            if(Input.GetAxis("Interact") != 0){
                if(firstConvoDoneBool){
                    if(!allHensCollected()) ConversationManager.Instance.StartConversation(myConversation2);
                    else ConversationManager.Instance.StartConversation(myConversation3);
                }
                else ConversationManager.Instance.StartConversation(myConversation1);
            }
        }
    }
}
