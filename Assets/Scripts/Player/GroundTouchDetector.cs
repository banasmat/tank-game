using UnityEngine;

public class GroundTouchDetector : MonoBehaviour {

    private GameObject player;
    private Quaternion originalRotationValue;
    private bool isTouchingGround;

    private float rotationResetSpeed = 0.02f;
    private float maxTimeWithoutTouchingGround = 3f;
    private float stoppedTouchingGroundAt;

	void Start () {
        player = GameObject.Find(NameContainer.PLAYER);
        originalRotationValue = player.transform.rotation;
        isTouchingGround = true;
    }
	
	void Update () {
	    if(false == isTouchingGround)
        {
            if((Time.time - stoppedTouchingGroundAt) > maxTimeWithoutTouchingGround)
            {
                // Rotating player back to initial position
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);

                Debug.Log("rotating player");
            }
        }
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == TagContainer.GROUND)
        {
            isTouchingGround = true;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>());
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == TagContainer.GROUND)
        {
            isTouchingGround = false;
            stoppedTouchingGroundAt = Time.time;
        }
    }
}
