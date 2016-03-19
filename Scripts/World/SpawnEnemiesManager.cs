﻿using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemiesManager : MonoBehaviour
{
	public Camera mainCamera;
	//public PlayerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	private GameObject[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	private int spawnPointsCounter;

	void Start ()
	{
		spawnPointsCounter = 0;
		spawnPoints = GameObject.FindGameObjectsWithTag(TagContainer.SPAWN_POINT);
	}

	// Spawn enemy when camera is close to one of the spawn points
	void Update () {
		int cameraWidth = (int)(mainCamera.aspect * mainCamera.orthographicSize);

		//TODO might use a dynamic array to unset destroyed objects from array
		for (int i = spawnPointsCounter; i < spawnPoints.Length; i++) {
			if (null != spawnPoints [i]) {
				if ((int)mainCamera.transform.position.x >= (int)spawnPoints [i].transform.position.x - cameraWidth) {
					Spawn (spawnPoints [i]);
					break;
				}
			}
		}
	}

	//Instantiate enemy and make him run towards the tank
	void Spawn (GameObject spawnPoint)
	{
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		GameObject clonedEnemy;
		clonedEnemy = Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
		clonedEnemy.gameObject.tag = TagContainer.ENEMY;
		Destroy (spawnPoint);
	}
}
