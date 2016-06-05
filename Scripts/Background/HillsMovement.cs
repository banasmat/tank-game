using UnityEngine;
using System.Collections;

public class HillsMovement : BackgroundMovement {

	protected override float GetScrollSpeed(){
		//TODO ground width might change
		return sprite.bounds.size.x / (groundSprite.bounds.size.x * groundTransform.localScale.x) / 2;
	}
}
