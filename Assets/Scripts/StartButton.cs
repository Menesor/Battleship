// Class used for the start button on main screen

using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
    // declare and initialize variables
    public Animator anim;
    // sets stage integer to 1, and sets trigger to start
    public void StartGame()
    {
        Debug.Log("Game Started");
        anim.SetTrigger("Start");
        anim.SetInteger("Stage", 1);
    }
}
