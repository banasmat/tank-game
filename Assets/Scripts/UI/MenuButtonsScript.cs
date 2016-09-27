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

    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(LevelContainer.MAIN_MENU);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(LevelContainer.LEVEL[level]);
    }

    #endregion
}
