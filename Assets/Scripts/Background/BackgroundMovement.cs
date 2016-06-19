using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public GameObject gameObjectPrefab;
	public float scrollSpeed;
	public float positionAboveGround; // Y position in relation to the ground level

	private Vector3 startPosition;
	private GameObject ground;
	private Sprite sprite;
	private Sprite groundSprite;
	private Transform groundTransform;

	private bool cloned;
	private float reversedScrollSpeed;
	private float cameraWidth;
	private float cameraRightEdgePosition;
	private float spriteRightEdgePosition;
	private float yPosition;
	private float spriteSizeHalf;
	private float cameraWidthDoubled;

	void Awake ()
	{
		sprite = GetComponent<SpriteRenderer> ().sprite;

		ground = GameObject.FindGameObjectWithTag (TagContainer.GROUND);
		groundSprite = ground.GetComponent<SpriteRenderer> ().sprite;
		groundTransform = ground.GetComponent<Transform> ();
		cloned = false;
		cameraWidth = Camera.main.orthographicSize;

		spriteSizeHalf = sprite.bounds.size.x / 2;
		cameraWidthDoubled = cameraWidth * 2;

		reversedScrollSpeed = -1 * (scrollSpeed - 1); 

		yPosition = groundTransform.position.y + positionAboveGround;
	}

	void Start(){
		startPosition = new Vector3(transform.position.x, yPosition);
	}

	//TODO optimize move some calculations to variables
	void FixedUpdate ()
	{
		transform.position = new Vector3(startPosition.x + Camera.main.transform.position.x * reversedScrollSpeed, yPosition);

		cameraRightEdgePosition = Camera.main.transform.position.x + cameraWidth;
		spriteRightEdgePosition = transform.position.x + spriteSizeHalf;

		float differenceAhead = spriteRightEdgePosition - cameraRightEdgePosition;

		// If image end is close to the camera right bound, create a new one
		if (differenceAhead < cameraWidthDoubled && differenceAhead > 0) {
			if (false == cloned) {
				// Make sure that new tile is intersected a bit with the old one ( - 0.1f )
				//TODO When Camera.main.transform.position.x gets higher, new object's x is too low. Temporarily fixed with changing Y position ( yPosition - 10 )
				GameObject clonedBackground = Instantiate (this.gameObjectPrefab, new Vector3(spriteRightEdgePosition + spriteSizeHalf - Camera.main.transform.position.x * reversedScrollSpeed - 0.1f, yPosition - 10), transform.rotation) as GameObject;
				cloned = true;
			}
		}

		// If sprite is left behind the camera, destroy it
		if ((Camera.main.transform.position.x - cameraWidth - spriteRightEdgePosition) > cameraWidthDoubled) {
			Destroy (gameObject);
		}
	}
}


