using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator Anim;
    public void Clap(){
        Anim.SetBool("isClapping", true);
    }
    public void Hello(){
        Anim.SetBool("isGreeting", true);
    }
    public void GoodBye(){
        Anim.SetBool("isLeaving", true);
    }
    public void Sad(){
        Anim.SetBool("isSad", true);
    }
    public void Talk(){
        Anim.SetBool("isTalking", true);
    }public void NotClap(){
        Anim.SetBool("isClapping", false);
    }
    public void NotHello(){
        Anim.SetBool("isGreeting", false);
    }
    public void NotGoodBye(){
        Anim.SetBool("isLeaving", false);
    }
    public void NotSad(){
        Anim.SetBool("isSad", false);
    }

}