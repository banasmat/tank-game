using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour {

	//TODO singleton?

	private Dictionary<string, ObjectPool> dictionary;

	public ObjectPoolManager(){
		dictionary = new Dictionary<string, ObjectPool> ();
	}

	public void CreatePool (GameObject _gameObject, int capacity = 3) {
		if(false == dictionary.ContainsKey(_gameObject.name)){
			dictionary.Add (_gameObject.name, new ObjectPool(capacity));
		}
	}

	public void Add (GameObject _gameObject){
		ObjectPool objectPool;
		if (dictionary.TryGetValue (_gameObject.name, out objectPool)) {
			_gameObject.SetActive (false);
			try{
				objectPool.Add (_gameObject);
			} catch (UnityException){
				// Destroy game object if pool is already full.
				Destroy (_gameObject);
			}

		} else {
			throw new UnityException ("Object pool for " + _gameObject.name + " has not been initialized. Object can't be added.");	
		}
	}

	public GameObject Retrieve (GameObject _gameObject, Vector3 _position, Quaternion _rotation){
		ObjectPool objectPool;
		GameObject retrievedObject;
		if(dictionary.TryGetValue (_gameObject.name, out objectPool)){
			try{
				retrievedObject = objectPool.Retrieve();

				retrievedObject.transform.position = _position;
				retrievedObject.transform.rotation = _rotation;
				retrievedObject.SetActive(true);
				// Run Start like if object is new
				retrievedObject.BroadcastMessage("Start");
			} catch(UnityException) {
				//Debug.Log ("Object pool for " + _gameObject.name + " is empty. Object can't be retrieved. Instantiating new object");
				retrievedObject = Instantiate (_gameObject, _position, _rotation) as GameObject;
				// "(Clone)" in game object names would force creating new pools
				retrievedObject.name = retrievedObject.name.Replace ("(Clone)", "");
			}
		} else {
			throw new UnityException ("Object pool for " + _gameObject.name + " has not been initialized. Object can't be retrieved.");			
		}

		return retrievedObject;
	}



}
