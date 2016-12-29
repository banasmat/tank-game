using UnityEngine;

using System.Collections.Generic;
using System;

//TODO might rename to GroundPerformanceManager/ GroundCleaner...
public class GroundManager : MonoBehaviour {

    private List<GameObject> groundElements;
    private Transform player;
    private int activeElementPointer = 0;

    private int margin = 8;
    private int groundElementsCount;
	
	void Start () {

        player = GameObject.Find(NameContainer.PLAYER).GetComponentInChildren<PlayerMovement>().transform;

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

        InvokeRepeating("manageGroundElements", 0, 1f);

    }

    private void manageGroundElements()
    {
        
        for (int i = activeElementPointer; i < groundElementsCount; i++)
        {
            if(groundElements[i].transform.position.x >= player.position.x)
            {
                activeElementPointer = i;

                // Activate ground elements few steps ahead
                try
                {
                    for(int j = activeElementPointer; j< activeElementPointer + margin; j++)
                    {
                        groundElements[j].SetActive(true);
                    }
                    
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Do nothing
                }
                
                // Destroy ground element few steps behind
                try
                {
                    for (int k = activeElementPointer - margin; k >= 0; k--)
                    {
                        Destroy(groundElements[k].gameObject);
                    }
                    
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Do nothing
                }

                break;
            }
        }

    }
}
