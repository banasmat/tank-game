using UnityEngine;
using System.Collections;

public class SkyMovement : BackgroundMovement {

	protected override float GetScrollSpeed(){
		//TODO ground width might change
		return sprite.bounds.size.x / groundSprite.bounds.size.x;
	}
}
