using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenBehaviour : MonoBehaviour
{
    public GameObject hen;
    public bool isHen;
    public Animator anim;
    private void OnTriggerStay(Collider other){
        if(isHen){
            if(other.CompareTag("Player")){
                if(Input.GetAxis("Pet") != 0){
                    GlobalVariables.hen_caught++;
                    Invoke("SetInactive", 7);
                }
            }
        }
        else{
            if(other.CompareTag("Hen")){
               if(Input.GetAxis("Pet") != 0){
                    anim.Play("Pet");
                } 
            }
        } 
    }
    private void SetInactive(){
        hen.SetActive(false);
    }
}
