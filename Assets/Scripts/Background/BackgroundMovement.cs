using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public GameObject gameObjectPrefab;

	protected float scrollSpeed;
	protected float cameraWidth;
	protected float cameraRightBoundPosition;
	protected float spriteRightBoundPosition;
	protected Vector3 startPosition;
	protected GameObject ground;
	protected Sprite sprite;
	protected Sprite groundSprite;
	protected Transform groundTransform;
	protected bool cloned;

	void Awake ()
	{
		
		sprite = GetComponent<SpriteRenderer> ().sprite;

		ground = GameObject.FindGameObjectWithTag (TagContainer.GROUND);
		groundSprite = ground.GetComponent<SpriteRenderer> ().sprite;
		groundTransform = ground.GetComponent<Transform> ();
		scrollSpeed = GetScrollSpeed() ;
		cloned = false;
		cameraWidth = Camera.main.orthographicSize;
	}

	void Start(){
		startPosition = new Vector3(transform.position.x, transform.position.y);
	}

	//TODO optimize move some calculations to variables
	void FixedUpdate ()
	{
		transform.position = new Vector3(startPosition.x + Camera.main.transform.position.x * scrollSpeed, transform.position.y);

		cameraRightBoundPosition = Camera.main.transform.position.x + cameraWidth;
		spriteRightBoundPosition = transform.position.x + sprite.bounds.size.x / 2;

		float differenceAhead = spriteRightBoundPosition - cameraRightBoundPosition;

		// If image end is close to the camera right bound, create a new one
		if (differenceAhead < cameraWidth * 2 && differenceAhead > 0) {
			if (false == cloned) {
				// Make sure that new object is intersected a bit with the old one
				//FIXME When Camera.main.transform.position.x gets higher, new object's x is too low
				GameObject clonedBackground = Instantiate (this.gameObjectPrefab, new Vector3(spriteRightBoundPosition + (sprite.bounds.size.x / 2) - Camera.main.transform.position.x * scrollSpeed - 0.1f, transform.position.y), transform.rotation) as GameObject;
				cloned = true;
			}
		}

		// If sprite is left behind the camera, destroy it
		if ((Camera.main.transform.position.x - cameraWidth - spriteRightBoundPosition) > cameraWidth * 2) {
			Destroy (gameObject);
		}
	}

	protected virtual float GetScrollSpeed(){
		return 0;
	}
}


