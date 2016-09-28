using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles Menu UI buttons
/// </summary>
public class MenuButtonsScript : MonoBehaviour {


    #region These methods are connected with buttons in the Editor

    public void PlayButton()
    {
        SceneManager.LoadScene(LevelContainer.LEVELS_MENU);
    }

    public void BackToMainMenuButton(bool showPopup)
    {
        if(true == showPopup)
        {
            //TODO are you sure? popup
        }
        SceneManager.LoadScene(LevelContainer.MAIN_MENU);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(LevelContainer.LEVEL[level]);
    }

    public void RestartLevelButton()
    {   
        //TODO are you sure? popup
        string sceneName = SceneManager.GetActiveScene().name;

        int level = Array.FindIndex(LevelContainer.LEVEL, value => value.Equals(sceneName));

        SceneManager.LoadScene(LevelContainer.LEVEL[level]);
    }

    /// <summary>
    /// Disables pause menu
    /// </summary>
    public void ResumeButton()
    {
        GameObject.Find(NameContainer.PAUSE_MENU_PANEL).SetActive(false);
    }

    #endregion
}
