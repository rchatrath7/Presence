using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid : MonoBehaviour {

    public float movementPadding = 1;
    public float timeDelay = .3f;
    public float smoothing = 2;

    private float x;
    private float y;
    private float xVelocity = 0f;
    private float yVelocity = 0f;

    private Vector3 prevPosition;
    private Vector3 destPosition;

    private Vector3 position;
    private Vector3 maxPosition;
    private Vector3 minPosition;

    private bool hasNewPosition;


    void Start () {
        position = gameObject.GetComponent<Transform>().position; //gets initial position of object

        Debug.Log("movementPadding is: " + movementPadding);
        maxPosition = new Vector3(transform.position.x + movementPadding, transform.position.y + movementPadding, transform.position.z);
        minPosition = new Vector3(transform.position.x - movementPadding, transform.position.y - movementPadding, transform.position.z);
    }
	
	void Update () {
        move();
	}

    private void move()
    {
        hasNewPosition = false;
        while (!hasNewPosition)
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            if (prevPosition.x + x <= maxPosition.x && prevPosition.y + y <= maxPosition.y)
            {
                destPosition = new Vector3(prevPosition.x + x, prevPosition.y + y, prevPosition.z);
                hasNewPosition = true;
            } else
            {
                hasNewPosition = false;
            }
        }
        float newPositionX = Mathf.SmoothDamp(transform.position.x, destPosition.x, ref xVelocity, smoothing);
        float newPositionY = Mathf.SmoothDamp(transform.position.y, destPosition.y, ref yVelocity, smoothing);
        gameObject.transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
        prevPosition = gameObject.transform.position;
    }
}
