using UnityEngine;
using System.Collections;

public class IntroBackgroundMovement : MonoBehaviour {

    public enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public Direction direction;
    public float speed;

    private float xOffset = 0;
    private float yOffset = 0;

    public void Start()
    {
        setUpDirections();
    }



    public void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset);

    }

    private void setUpDirections()
    {
        switch (direction)
        {
            case Direction.UP:
                yOffset = (speed);
                break;
            case Direction.DOWN:
                yOffset = (speed * -1);
                break;
            case Direction.LEFT:
                xOffset = (speed * -1);
                break;
            case Direction.RIGHT:
                xOffset = (speed);
                break;
        }
    }
}
