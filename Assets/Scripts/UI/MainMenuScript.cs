using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// These methods are connected with buttons in the Editor
/// </summary>
public class MainMenuScript : MonoBehaviour {



    public void PlayButton()
    {
        SceneManager.LoadScene(LevelContainer.TEST);
    }
}
