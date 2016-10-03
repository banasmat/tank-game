using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public GameObject gameObjectPrefab;
	public float scrollSpeed;
	public float positionAboveGround; // Y position in relation to the ground level

	private Vector3 startPosition;
	private GameObject ground;
	private Sprite sprite;
	private Transform groundTransform;
	private ObjectPoolManager objectPoolManager;

	private bool cloned;
	private float reversedScrollSpeed;
	private float cameraWidth;
	private float cameraRightEdgePosition;
	private float spriteRightEdgePosition;
	private float yPosition;
	private float spriteSizeHalf;
	private float cameraWidthDoubled;
    private float cameraWidthHalf;


    void Awake ()
	{
        objectPoolManager = ObjectPoolManager.Instance;
		objectPoolManager.CreatePool (gameObjectPrefab, 3);

		sprite = GetComponent<SpriteRenderer> ().sprite;

		ground = GameObject.FindGameObjectWithTag (TagContainer.GROUND);
		groundTransform = ground.GetComponent<Transform> ();
        
        // TODO hardcoded for now. Hard to retrieve from system.
		cameraWidth = 14;

		spriteSizeHalf = sprite.bounds.size.x / 2;
		cameraWidthDoubled = cameraWidth * 2;
        cameraWidthHalf = cameraWidth / 2;

        reversedScrollSpeed = -1 * (scrollSpeed - 1); 

		yPosition = groundTransform.position.y + positionAboveGround;
	}

	void Start(){
		cloned = false;
		startPosition = new Vector3(transform.position.x, yPosition);
	}

	//FIXME not smooth on android
	void FixedUpdate ()
	{
		transform.position = new Vector3(startPosition.x + Camera.main.transform.position.x * reversedScrollSpeed, yPosition);
        
        spriteRightEdgePosition = transform.position.x + spriteSizeHalf;

        if (false == cloned)
        {

            cameraRightEdgePosition = Camera.main.transform.position.x + cameraWidthHalf;

            float differenceAhead = spriteRightEdgePosition - cameraRightEdgePosition;

		    // If image end is close to the camera right bound, create a new one
		    if (differenceAhead < cameraWidthDoubled && differenceAhead > 0) {
			
				//TODO When Camera.main.transform.position.x gets higher, new object's x is too low. Temporarily fixed with changing Y position ( yPosition - 10 )
				GameObject clonedBackground = objectPoolManager.Retrieve(this.gameObjectPrefab, new Vector3 (spriteRightEdgePosition + spriteSizeHalf - Camera.main.transform.position.x * reversedScrollSpeed - 1f, yPosition - 10), transform.rotation);
				cloned = true;
		    }
        } else
        {
            // If sprite is left behind the camera, destroy it
            if ((spriteRightEdgePosition + cameraWidthDoubled) < Camera.main.transform.position.x)
            {
                //Destroy (gameObject);
                objectPoolManager.Add(gameObject);
            }
        }
	}
}


