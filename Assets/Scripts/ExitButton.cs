// Script attached to exit button

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitButton : MonoBehaviour {

    // function to close the game
	public void ExitGame()
    {
        Debug.Log("Game Exited");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
