using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	public GameObject gameObjectPrefab;
	public float scrollSpeed;

    [HideInInspector]
    public float YPosition;

    private PlayerMovement playerMovement;

	private Vector3 startPosition;
	private ObjectPoolManager objectPoolManager;

    private bool cloned;
	private float reversedScrollSpeed;
	private float cameraWidth;
	private float cameraRightEdgePosition;
	private float spriteRightEdgePosition;
	
	private float objectSizeHalf;
	private float cameraWidthDoubled;
    private float cameraWidthHalf;


    void Awake ()
	{
        playerMovement = GameObject.Find(NameContainer.PLAYER).GetComponent<PlayerMovement>();

        objectPoolManager = ObjectPoolManager.Instance;
		objectPoolManager.CreatePool (gameObjectPrefab, 3);


        Transform groundTransform = GameObject.Find(NameContainer.GROUND).GetComponent<Transform> ();
        
        // TODO hardcoded for now. Hard to retrieve from system.
		cameraWidth = 14;

        objectSizeHalf = GetComponent<RectTransform>().rect.width / 2;

        cameraWidthDoubled = cameraWidth * 2;
        cameraWidthHalf = cameraWidth / 2;

        reversedScrollSpeed = -1 * (scrollSpeed - 1) / 100; 

		if(0 == YPosition)
        {
            YPosition = transform.position.y;
        }
	}

	void Start(){
		cloned = false;
		startPosition = new Vector3(transform.position.x, YPosition);
	}

	void Update ()
	{
        // Correct y position
        if(transform.position.y != YPosition)
        {
            transform.position = new Vector3(transform.position.x, YPosition);
        }

        transform.Translate(new Vector3(playerMovement.Velocity.x * reversedScrollSpeed, 0));

        spriteRightEdgePosition = transform.position.x + objectSizeHalf;

        if (false == cloned)
        {

            cameraRightEdgePosition = Camera.main.transform.position.x + cameraWidthHalf;

            float differenceAhead = spriteRightEdgePosition - cameraRightEdgePosition;

		    // If image end is close to the camera right bound, create a new one
		    if (differenceAhead < cameraWidthDoubled && differenceAhead > 0) {
			
				//TODO When Camera.main.transform.position.x gets higher, new object's x is too low. Temporarily fixed with changing Y position ( yPosition - 10 )
				GameObject clonedBackground = objectPoolManager.Retrieve(this.gameObjectPrefab, new Vector3 (spriteRightEdgePosition + objectSizeHalf - Camera.main.transform.position.x * reversedScrollSpeed - 1f, YPosition - 10), transform.rotation);
				cloned = true;
                clonedBackground.GetComponent<BackgroundMovement>().YPosition = transform.position.y;

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


