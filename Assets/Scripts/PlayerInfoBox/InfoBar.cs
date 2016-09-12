using UnityEngine;
using System.Collections;

public class InfoBar : MonoBehaviour
{

	protected Vector3 empty, full;

	protected SpriteRenderer spriteRenderer;
	protected float width;
	protected float leftBoundX;

	public void Awake ()
	{
		empty = new Vector3 (0, transform.localScale.y);
		full = new Vector3 (transform.localScale.x, transform.localScale.y);

		spriteRenderer = GetComponent<SpriteRenderer> ();
		width = spriteRenderer.bounds.size.x;
		//position = transform.position;
		leftBoundX = transform.position.x - width / 2;
	}

	public void SetBarValue (float percentage)
	{
		//TODO not sure why we have to divide percentage by 2...
		transform.localScale = Vector3.Lerp (empty, full, Time.deltaTime * percentage/2);
		float actualWidth = transform.localScale.x * width;
		transform.position = new Vector3(transform.position.x - actualWidth/2, transform.position.y);
	}

}

