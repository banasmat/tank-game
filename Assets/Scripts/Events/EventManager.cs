﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//-----------------------------------
//Singleton EventManager to send events to listeners
//Works with IListener implementations

public class EventManager : ScriptableObject
{

	#region C# properties

	//-----------------------------------
	//Public access to instance
	public static EventManager Instance {
		get{ return instance; }
	}

	#endregion

	#region variables

	// Notifications Manager instance (singleton design pattern)
	private static readonly EventManager instance = ScriptableObject.CreateInstance(typeof(EventManager)) as EventManager;

	//Array of listeners (all objects registered for events)
	private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>> ();

	#endregion

	//-----------------------------------------------------------

	#region methods

	//-----------------------------------------------------------
	/// <summary>
	/// Function to add listener to array of listeners
	/// </summary>
	/// <param name="Event_Type">Event to Listen for</param>
	/// <param name="Listener">Object to listen for event</param>
	/// 
	public void AddListener (EVENT_TYPE Event_Type, IListener
		Listener)
	{
		//List of listeners for this event
		List<IListener> ListenList = null;

		// Check existing event type key. If exists, add to list
		if (Listeners.TryGetValue (Event_Type, out ListenList)) {
			//List exists, so add new item
			ListenList.Add (Listener);
			return;
		}

		//Otherwise create new list as dictionary key
		ListenList = new List<IListener> ();
		ListenList.Add (Listener);
		Listeners.Add (Event_Type, ListenList);
	}
	//-----------------------------------------------------------
	/// <summary>
	/// Function to post event to listeners
	/// </summary>
	/// <param name="Event_Type">Event to invoke</param>
	/// <param name="IEvent">Event object</param>
	public void PostNotification (GameEvent GameEvent)
	{
		//Notify all listeners of an event

		//List of listeners for this event only
		List<IListener> ListenList = null;

		//If no event exists, then exit
		if (!Listeners.TryGetValue (GameEvent.eventType, out ListenList))
			return;

		//Entry exists. Now notify appropriate listeners
		for (int i = 0; i < ListenList.Count; i++) {
			if (!ListenList [i].Equals (null))
				ListenList [i].OnEvent (GameEvent);
		}
	}
	//-----------------------------------------------------------
	//Remove event from dictionary, including all listeners
	public void RemoveEvent (EVENT_TYPE Event_Type)
	{
		//Remove entry from dictionary
		Listeners.Remove (Event_Type);
	}
	//-----------------------------------------------------------
	//Remove all redundant entries from the Dictionary
	public void RemoveRedundancies ()
	{
		//Create new dictionary
		Dictionary<EVENT_TYPE, List<IListener>>
		TmpListeners = new Dictionary<EVENT_TYPE, List<IListener>> ();

		//Cycle through all dictionary entries
		foreach (KeyValuePair<EVENT_TYPE, List<IListener>>
			Item in Listeners) {
			//Cycle all listeners, remove null objects
			for (int i = Item.Value.Count - 1; i >= 0; i--) {
				//If null, then remove item
				if (Item.Value [i].Equals (null))
					Item.Value.RemoveAt (i);
			}

			//If items remain in list, then add to tmp dictionary
			if (Item.Value.Count > 0)
				TmpListeners.Add (Item.Key, Item.Value);
		}

		//Replace listeners object with new dictionary
		Listeners = TmpListeners;
	}
    //-----------------------------------------------------------
    //Called on scene change. Clean up dictionary //TODO deprecated
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RemoveRedundancies();
    }
	//-----------------------------------------------------------

	#endregion

}
