// Class used for the main menu button during gameplay

using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuButton : MonoBehaviour
{
    // Reloads the level to main menu
    public void MainMenu()
    {
#if UNIT_EDITOR
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene(0);
#else
        Application.LoadLevel(0);
#endif
    }
}