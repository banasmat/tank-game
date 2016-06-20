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
				break;
			}
		}
	}

	public GameObject Retrieve(){
		for (int i = 0; i < gameObjects.Length; i ++) {
			if (null != gameObjects[i]) {
				GameObject retrievedGameObject = gameObjects [i];
				//gameObjects [i] = null;
				return retrievedGameObject;
			}
		}
		//TODO specific exception type, insert GameObject name. or maybe even clone object here and set position in other class...
		throw new UnityException ("ObjectPool is empty.");
	}
	
}
