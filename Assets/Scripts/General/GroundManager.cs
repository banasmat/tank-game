using UnityEngine;

using System.Collections.Generic;
using System;

//TODO might rename to GroundPerformanceManager/ GroundCleaner...
public class GroundManager : MonoBehaviour, IListener {

    private List<GameObject> groundElements;
    private GameObject player;
    private int activeElementPointer = 0;

    private int margin = 5;
    private int groundElementsCount;

	
	void Start () {

        EventManager.Instance.AddListener(EVENT_TYPE.PLAYER_TOUCHES_NEW_GROUND_ELEMENT, this);

        player = GameObject.Find(NameContainer.PLAYER);

        // Get references to all terrain elements
        GameObject[] _groundElements = GameObject.FindGameObjectsWithTag(TagContainer.GROUND);
        groundElements = new List<GameObject>(_groundElements);

        // Sort them by x position
        groundElements.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));

        groundElementsCount = groundElements.Count;

        // Disable all all game objects except two first
        for (int i = margin; i < groundElementsCount; i++)
        {
            groundElements[i].gameObject.SetActive(false);
        }


	}

    public void OnEvent(GameEvent gameEvent)
    {
        switch (gameEvent.eventType)
        {
            case EVENT_TYPE.PLAYER_TOUCHES_NEW_GROUND_ELEMENT:
                manageGroundElements((Transform)gameEvent.component);
                break;
        }
    }

    private void manageGroundElements(Transform _groundElement)
    {
        
        for (int i = activeElementPointer; i < groundElementsCount; i++)
        {
            if(groundElements[i].transform.position.x == _groundElement.transform.position.x)
            {
                activeElementPointer = i;
                break;
            }
        }

        // Activate ground element few steps ahead
        try { 
            groundElements[activeElementPointer + margin].SetActive(true);
        } catch (ArgumentOutOfRangeException)
        {
            // Do nothing
        }

        // Destroy ground element few steps behind
        try
        {
            Destroy(groundElements[activeElementPointer - margin].gameObject);
        }
        catch (ArgumentOutOfRangeException)
        {
            // Do nothing
        }
    }
}
