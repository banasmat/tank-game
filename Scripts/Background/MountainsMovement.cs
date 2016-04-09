using UnityEngine;
using System.Collections;

//TODO use inheritance -> only getScrollSpeed should vary?
public class MountainsMovement : MonoBehaviour {

	private float scrollSpeed;
	private Vector3 startPosition;

	void Awake ()
	{
		startPosition = transform.position;
		Sprite sprite = GetComponent<SpriteRenderer> ().sprite;
		GameObject ground = GameObject.FindGameObjectWithTag (TagContainer.GROUND);
		Sprite groundSprite = ground.GetComponent<SpriteRenderer> ().sprite;
		Transform groundTransform = ground.GetComponent<Transform> ();
		//TODO this might change when ground is sliced
		scrollSpeed = sprite.bounds.size.x / (groundSprite.bounds.size.x * groundTransform.localScale.x) ;
	}

	void FixedUpdate ()
	{
		transform.position = startPosition + Camera.main.transform.position * scrollSpeed;
	}
}
