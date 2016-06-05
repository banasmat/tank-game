using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Camera mainCamera;
    public Transform player;

	void Update () {
		transform.position = new Vector3(player.position.x + 4, 0, -20);
    }
}

