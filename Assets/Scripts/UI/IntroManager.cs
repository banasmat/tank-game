using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class IntroManager : MonoBehaviour {

    private List<GameObject> sceneGameObjects;

    private GameObject activeScene;
    private int pointer = 0;

    private IEnumerator nextSceneCoroutine;

    private static readonly string[] sceneNames = new string[7]
    {
        "Scene1",
        "Scene2",
        "Scene3",
        "Scene4",
        "Scene5",
        "Scene6",
        "Scene7"
    };

    void Start()
    {
        sceneGameObjects = new List<GameObject>();

        GameObject sceneGameObject;

        foreach(string sceneName in sceneNames)
        {
            sceneGameObject = GameObject.Find(sceneName);
            sceneGameObject.SetActive(false);

            sceneGameObjects.Add(sceneGameObject);
        }

        activeScene = sceneGameObjects[0];
        activeScene.SetActive(true);

        nextSceneCoroutine = waitAndShowNextScene();
        StartCoroutine(nextSceneCoroutine);
    }

    private IEnumerator waitAndShowNextScene()
    {
        yield return new WaitForSeconds(5);

        ShowNextScene();
    }

    public void ShowNextScene()
    {
        StopCoroutine(nextSceneCoroutine);

        pointer++;

        // If no more scenes, go to main menu
        if(pointer >= sceneNames.Length)
        {
            SceneManager.LoadScene(LevelContainer.MAIN_MENU);
            return;
        }

        GameObject nextScene = sceneGameObjects[pointer];

        activeScene.SetActive(false);
        nextScene.SetActive(true);
        activeScene = nextScene;

        nextSceneCoroutine = waitAndShowNextScene();
        StartCoroutine(nextSceneCoroutine);
    }
}
