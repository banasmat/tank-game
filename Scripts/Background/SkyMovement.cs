using UnityEngine;
using System.Collections;

public class SkyMovement : MonoBehaviour {

	private float scrollSpeed;

	private Vector3 startPosition;

	void Awake ()
	{
		startPosition = transform.position;
		Sprite skySprite = GetComponent<SpriteRenderer> ().sprite;
		Sprite groundSprite = GameObject.FindGameObjectWithTag (TagContainer.GROUND).GetComponent<SpriteRenderer> ().sprite;
		//TODO this might change when ground is sliced
		scrollSpeed = skySprite.bounds.size.x / groundSprite.bounds.size.x;
	}

	void FixedUpdate ()
	{
		transform.position = startPosition + Camera.main.transform.position * scrollSpeed;
	}
}
