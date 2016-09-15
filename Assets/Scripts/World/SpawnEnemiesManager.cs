using UnityEngine;
using System.Collections;

public class SpawnEnemiesManager : MonoBehaviour
{
	public Camera mainCamera;
	//public Player playerHealth;       // Reference to the player's heatlh.
	private ArrayList spawnPoints;         // An array of the spawn points this enemy can spawn from.
	private int cameraWidth;

	void Start ()
	{
        mainCamera = GameObject.Find(NameContainer.MAIN_CAMERA).GetComponent<Camera>();
		GameObject[] _spawnPoints = GameObject.FindGameObjectsWithTag(TagContainer.SPAWN_POINT);
		spawnPoints = new ArrayList (_spawnPoints);
		cameraWidth = (int)(mainCamera.aspect * mainCamera.orthographicSize);
	}

	// Spawn enemy when camera is close to one of the spawn points
	void Update () {
		foreach(GameObject spawnPoint in spawnPoints){
			if ((int)mainCamera.transform.position.x >= (int)spawnPoint.transform.position.x - cameraWidth * 2) {
				Spawn (spawnPoint);
				spawnPoints.Remove (spawnPoint);
				break;
			} else {
				// Checking only closest spawn point
				//break;
			}
		}
	}

	//Instantiate enemy and make him run towards the tank
	void Spawn (GameObject spawnPoint)
	{
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		GameObject clonedEnemy = Instantiate (spawnPoint.GetComponent<SpawnPoint>().Enemy, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
		clonedEnemy.gameObject.tag = TagContainer.ENEMY;
		Destroy (spawnPoint);
	}
}
