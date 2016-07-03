using UnityEngine;
using System.Collections;

//TODO rename to PlayerInfoBarEventListener?
public class PlayerHealthBar : MonoBehaviour, IListener
{
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


	void Start ()
	{
		EventManager.Instance.AddListener (EVENT_TYPE.HEALTH_CHANGE, this);
	}

	public void OnEvent (GameEvent GameEvent)
	{
		switch (GameEvent.eventType) {
		case EVENT_TYPE.HEALTH_CHANGE:
			Player player = (Player)GameEvent.component;
			SetBar (player.health);
			break;
		}
	}


		//transform.localScale = new Vector3 ((float)playerHealth.health / 100, transform.localScale.y);

		public void SetBar (int percentage)
		{
			//TODO reuse in all bars
			//TODO not sure why we have to divide percentage by 2...
			transform.localScale = Vector3.Lerp (empty, full, Time.deltaTime * percentage/2);
			float actualWidth = transform.localScale.x * width;
			transform.position = new Vector3(transform.parent.transform.position.x + actualWidth/2, transform.position.y);
		}

}
