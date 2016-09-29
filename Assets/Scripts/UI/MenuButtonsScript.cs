using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles Menu UI buttons. Connected to UI canvas objects.
/// </summary>
public class MenuButtonsScript : MonoBehaviour {

    private GameObject confirmationPopup;
    private delegate void actionToConfirm();
    private actionToConfirm _actionToConfirm; // Callback that will run when confirmation popup is accepted

    public void Awake()
    {
        // Other game objects are set active or inactive in the editor
        confirmationPopup = GameObject.Find(NameContainer.CONFIRMATION_POPUP_PANEL);
        if(null != confirmationPopup)
        {
            confirmationPopup.SetActive(false);
        }
    }

    #region These methods are connected with buttons in the Editor

    public void PlayButton()
    {
        SceneManager.LoadScene(LevelContainer.LEVELS_MENU);
    }

    public void BackToMainMenuButton(bool showPopup)
    {
        if(true == showPopup)
        {
            showConfirmationPopup(backToMainMenu);
        } else
        {
            backToMainMenu();
        }
        
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(LevelContainer.LEVEL[level]);
    }

    public void RestartLevelButton()
    {
        showConfirmationPopup(restartLevel);
    }

    public void IntroButton()
    {
        SceneManager.LoadScene(LevelContainer.INTRO);
    }

    /// <summary>
    /// Disables pause menu
    /// </summary>
    public void ResumeButton()
    {
        GameObject.Find(NameContainer.PAUSE_MENU_PANEL).SetActive(false);
    }

    public void CloseConfirmationPopup()
    {
        confirmationPopup.SetActive(false);

        _actionToConfirm = null;
    }

    public void AcceptConfirmationPopup()
    {
        if(null != _actionToConfirm)
        {
            // Run callback
            _actionToConfirm();
        }
        confirmationPopup.SetActive(false);
    }

    #endregion

    private void backToMainMenu()
    {
        if(LevelContainer.MAIN_MENU != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(LevelContainer.MAIN_MENU);
        }
    }

    private void restartLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int level = Array.FindIndex(LevelContainer.LEVEL, value => value.Equals(sceneName));
        SceneManager.LoadScene(LevelContainer.LEVEL[level]);
    }

    /// <summary>
    /// Shows confirmation popup and sets callback to run when popup is confirmed
    /// </summary>
    /// <param name="_actionToConfirm"></param>
    private void showConfirmationPopup(actionToConfirm _actionToConfirm) //TODO add message text as param?
    {
        confirmationPopup.SetActive(true);

        this._actionToConfirm = _actionToConfirm;
    }
}
