using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour {

	//TODO singleton?

	private Dictionary<string, ObjectPool> dictionary;

	void Awake(){
		dictionary = new Dictionary<string, ObjectPool> ();
	}

	public void CreatePool (GameObject _gameObject, int capacity = 3) {
		if(false == dictionary.ContainsKey(_gameObject.name)){
			dictionary.Add (_gameObject.name, new ObjectPool(capacity));
		}
	}

	public void Add (GameObject _gameObject){
		ObjectPool objectPool;
		try{
			dictionary.TryGetValue (_gameObject.name, out objectPool);

			_gameObject.SetActive (false);
			objectPool.Add(_gameObject);

		}catch(ArgumentNullException e){
			throw new UnityException ("Object pool for " + _gameObject.name + " has not been initialized. Object can't be added.");			
		}
	}

	public GameObject Retrieve (GameObject _gameObject, Vector3 _position, Quaternion _rotation){
		ObjectPool objectPool;
		GameObject retrievedObject;
		try{
			dictionary.TryGetValue (_gameObject.name, out objectPool);
			try{
				retrievedObject = objectPool.Retrieve();

				retrievedObject.transform.position = _position;
				retrievedObject.transform.rotation = _rotation;
				retrievedObject.SetActive(true);
			} catch(UnityException e){
				retrievedObject = Instantiate (_gameObject, _position, _rotation) as GameObject;
			}
		}catch(ArgumentNullException e){
			throw new UnityException ("Object pool for " + _gameObject.name + " has not been initialized. Object can't be retrieved.");			
		}
		return retrievedObject;
	}



}
