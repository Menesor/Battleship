// Script that manages pausing the game

using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    // declare and initialize variables
    public Animator anim;
    private bool isPaused = false;

    // function called every frame by unity. checks if player pressed escape key and either pauses or unpauses the game
    void Update()
    {
        if(anim.GetInteger("Stage") != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {
                Debug.Log("Escape Pressed");
                Pause();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
            {
                Debug.Log("Unpaused");
                Unpause();
            }
        }
        else if(anim.GetInteger("Stage") == 0)
        {
            isPaused = false;
        }    
    }
    // pauses game
    public void Pause()
    {
        anim.SetTrigger("Pause");
        isPaused = true;        
    }
    // unpauses game
    public void Unpause()
    {
        anim.SetTrigger("Unpause");
        isPaused = false;
    }
}
