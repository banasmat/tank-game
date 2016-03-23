using UnityEngine;
using System.Collections;

public class SkyMovement : MonoBehaviour {

	public float scrollSpeed;
	private Sprite skySprite;
	private Sprite groundSprite;

	private Vector3 startPosition;

	void Awake ()
	{
		startPosition = transform.position;
		skySprite = GetComponent<SpriteRenderer> ().sprite;
		groundSprite = GameObject.FindGameObjectWithTag (TagContainer.GROUND).GetComponent<SpriteRenderer> ().sprite;
		//TODO this might change when ground is sliced
		scrollSpeed = skySprite.bounds.size.x / groundSprite.bounds.size.x;
	}

	void Update ()
	{
		transform.position = startPosition + Camera.main.transform.position * scrollSpeed;
	}
}
