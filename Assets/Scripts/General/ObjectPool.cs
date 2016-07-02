using UnityEngine;
using System.Collections;

public class ObjectPool {

	private GameObject[] gameObjects;

	public ObjectPool (int capacity) {
		gameObjects = new GameObject[capacity];
	}

	public void Add (GameObject gameObject){
		
		for (int i = 0; i < gameObjects.Length; i ++) {
			if (null == gameObjects[i]) {
				gameObjects[i] = gameObject;
				return;
			}
		}

		throw new UnityException ("ObjectPool is full for " + gameObject.name + " is full.");
	}

	public GameObject Retrieve(){
		for (int i = 0; i < gameObjects.Length; i ++) {
			if (null != gameObjects[i] && false == gameObjects[i].activeInHierarchy) {
				GameObject retrievedGameObject = gameObjects [i];
				return retrievedGameObject;
			}
		}
		//TODO specific exception type? insert GameObject name?
		throw new UnityException ("ObjectPool is empty or all objects are in use.");
	}
	
}
