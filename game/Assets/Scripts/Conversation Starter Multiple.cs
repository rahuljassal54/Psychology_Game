using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class ConversationStarteMultiple : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation1;
    [SerializeField] private NPCConversation myConversation2;

    private bool allHensCollected(){
        return GlobalVariables.hen_caught == 5;
    }
    private void OnTriggerStay(Collider other){
        
        if(other.CompareTag("Player")){
            if(Input.GetAxis("Interact") != 0){
                if(!allHensCollected()) ConversationManager.Instance.StartConversation(myConversation1);
                else ConversationManager.Instance.StartConversation(myConversation2);
            }
        }
    }
}
