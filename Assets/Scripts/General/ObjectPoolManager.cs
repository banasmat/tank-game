using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolManager : ScriptableObject
{

	private Dictionary<string, ObjectPool> dictionary;
    private int defaultCapacity = 5;

    #region Singleton
    private static readonly ObjectPoolManager instance = ScriptableObject.CreateInstance(typeof(ObjectPoolManager)) as ObjectPoolManager;

    public static ObjectPoolManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    private ObjectPoolManager(){
		dictionary = new Dictionary<string, ObjectPool> ();
	}

	public void CreatePool (GameObject _gameObject, int capacity = 0) {

        if(0 == capacity)
        {
            capacity = defaultCapacity;
        }

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

		} else
        {
            // Object pool has not been initialized. Creating new pool.
			CreatePool(_gameObject, 5);
            Add(_gameObject);
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
            // Object pool has not been initialized. Creating new pool.
            CreatePool(_gameObject, 5);
            return Retrieve(_gameObject,_position, _rotation);
        }

		return retrievedObject;
	}



}
