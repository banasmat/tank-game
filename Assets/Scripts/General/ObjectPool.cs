using UnityEngine;
using System.Collections;

public class ObjectPool {

	private GameObject[] gameObjects;

	public ObjectPool (int capacity) {
		gameObjects = new GameObject[capacity];
	}

	public void add (GameObject gameObject){

		gameObject.SetActive (false);

		for (int i = 0; i < gameObjects.Length; i ++) {
			if (null == gameObjects[i]) {
				gameObjects[i] = gameObject;
				break;
			}
		}
	}

	public GameObject retrieve(){
		for (int i = 0; i < gameObjects.Length; i ++) {
			if (null != gameObjects[i]) {
				gameObjects[i].SetActive(true);
				return gameObjects [i];
			}
		}
		//TODO specific exception type, insert GameObject name. or maybe even clone object here and set position in other class...
		throw new UnityException ("ObjectPool is empty.");
	}
	
}
