using UnityEngine;
using System.Collections;

public class CylinderBackgroundMovement : MonoBehaviour {

    public float scrollSpeed;

    private PlayerMovement playerMovement;
    private float reversedScrollSpeed;
    private float initialPositionZ;
    private float initialPositionY;

    // Use this for initialization
    void Start () {
        playerMovement = GameObject.Find(NameContainer.PLAYER).GetComponent<PlayerMovement>();
        reversedScrollSpeed = 1 * scrollSpeed / 100;

        initialPositionZ = transform.position.z;
        initialPositionY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Camera.main.transform.position.x, initialPositionY, initialPositionZ);

        // Blender vertical axis is Z (Unity: Y)
        transform.Rotate(new Vector3(0, 0, playerMovement.Velocity.x * reversedScrollSpeed));
    }
}
