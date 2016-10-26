using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    private List<GameObject> sceneGameObjects;

    private GameObject activeScene;
    private int pointer = 0;
    private Text introTextContainer; // We're using one text container to avoid scaling issues

    // We need to keep the coroutine in variable to be able to stop it with StopCoroutine
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

    private static readonly int[] sceneDurations = new int[7]
    {
        3,
        3,
        5,
        5,
        5,
        6,
        6
    };

    // These should correspond sceneNames
    private static readonly string[] sceneTexts = new string[7]
    {
        "Evil popstars are getting more and more popular",
        "Their lame music is turning people into brainless creatures",
        "Clones of Justin Kiebel...",
        "...One Erection...",
        "...and Gayne West...",
        "... are swarming everywhere",
        "Now get into your tank and stop this madness!"
    };

    void Start()
    {
        introTextContainer = GameObject.Find(NameContainer.INTRO_TEXT_CONTAINER).GetComponent<Text>();

        sceneGameObjects = new List<GameObject>();

        GameObject sceneGameObject;

        //TODO if scenes get too big, might lazy load them from resources
        foreach(string sceneName in sceneNames)
        {
            sceneGameObject = GameObject.Find(sceneName);
            sceneGameObject.SetActive(false);

            sceneGameObjects.Add(sceneGameObject);
        }

        activeScene = sceneGameObjects[0];
        activeScene.SetActive(true);
        introTextContainer.text = sceneTexts[pointer];

        nextSceneCoroutine = waitAndShowNextScene(sceneDurations[0]);
        StartCoroutine(nextSceneCoroutine);
    }

    private IEnumerator waitAndShowNextScene(int wait)
    {
        yield return new WaitForSeconds(wait);

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

        Destroy(activeScene);

        nextScene.SetActive(true);

        introTextContainer.text = sceneTexts[pointer];

        activeScene = nextScene;

        nextSceneCoroutine = waitAndShowNextScene(sceneDurations[pointer]);
        StartCoroutine(nextSceneCoroutine);
    }
}
