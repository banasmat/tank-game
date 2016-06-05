using UnityEngine;
using System.Collections;

public class SpawnEnemiesManager : MonoBehaviour
{
	public Camera mainCamera;
	//public Player playerHealth;       // Reference to the player's heatlh.
	public GameObject enemy;                // The enemy prefab to be spawned.
	private ArrayList spawnPoints;         // An array of the spawn points this enemy can spawn from.

	void Start ()
	{
		GameObject[] _spawnPoints = GameObject.FindGameObjectsWithTag(TagContainer.SPAWN_POINT);
		spawnPoints = new ArrayList (_spawnPoints);
	}

	// Spawn enemy when camera is close to one of the spawn points
	void Update () {
		int cameraWidth = (int)(mainCamera.aspect * mainCamera.orthographicSize);

		//TODO bad solution for performance
		foreach(GameObject spawnPoint in spawnPoints){
			if ((int)mainCamera.transform.position.x >= (int)spawnPoint.transform.position.x - cameraWidth) {
				Spawn (spawnPoint);
				spawnPoints.Remove (spawnPoint);
				break;
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
