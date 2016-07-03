using UnityEngine;
using System.Collections;

public class ReloadBar : MonoBehaviour {

	private Vector3 empty;
	private Vector3 full;

	//private Vector3 position;

	private SpriteRenderer spriteRenderer;
	private float width;
	private float leftBoundX;


	public void Awake(){
		empty = new Vector3 (0, transform.localScale.y);
		full = new Vector3 (transform.localScale.x, transform.localScale.y);

		spriteRenderer = GetComponent<SpriteRenderer> ();
		width = spriteRenderer.bounds.size.x;
		//position = transform.position;
		leftBoundX = transform.position.x - width / 2;
	}

	public void SetBar (int percentage)
	{
		//TODO reuse in all bars
		//TODO not sure why we have to divide percentage by 2...
		transform.localScale = Vector3.Lerp (empty, full, Time.deltaTime * percentage/2);
		float actualWidth = transform.localScale.x * width;
		transform.position = new Vector3(transform.parent.transform.position.x + actualWidth/2, transform.position.y);
	}
}
