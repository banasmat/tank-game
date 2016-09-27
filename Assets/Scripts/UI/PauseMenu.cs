using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	void Awake () {
        gameObject.SetActive(false);
	}

    public void ToggleActive()
    {
        if(true == gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }

    void OnEnable()
    {
        // Pause
        Time.timeScale = 0;
        GamePlayManager.Instance.Paused = true;
    }

    void OnDisable()
    {
        // Unpause
        Time.timeScale = 1;
        GamePlayManager.Instance.Paused = false;
    }
}
