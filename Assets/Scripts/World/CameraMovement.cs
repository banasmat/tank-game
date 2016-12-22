using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Camera mainCamera;
    private Transform player;

    private float cameraWidth;
    private float cameraOffset;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find(NameContainer.PLAYER).GetComponentInChildren<PlayerMovement>().transform;

        float height = 2f * mainCamera.orthographicSize;
        cameraWidth = height * mainCamera.aspect;
        cameraOffset = cameraWidth / 3;
    }

	void Update () {
        transform.position = new Vector3(player.position.x + cameraOffset, player.position.y, -20);
    }
}

