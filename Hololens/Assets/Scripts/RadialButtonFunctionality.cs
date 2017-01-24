using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialButtonFunctionality : MonoBehaviour {

    public GameObject[] socialMedia;
    public GameObject[] collapsableItems; //used for both Parent and Done
    public float movementPadding;
    public float timeDelay = .3f;
    public float smoothing = 2;
    public Material toggleOn;
    public Material toggleOff;
    private Vector3 position;
    private Vector3 maxPosition;
    private Vector3 minPosition;
    private Vector3 prevPosition;
    private Vector3 destPosition;
    private float x;
    private float y;
    private bool hasNewPosition;
    private bool toggle = false;
    private bool isMenuCollapsed = false;

    private float xVelocity = 0f;
    private float yVelocity = 0f;

	// Use this for initialization
	void Start () {
        position = gameObject.GetComponent<Transform>().position; //gets initial position of object
        
        Debug.Log("movementPadding is: " + movementPadding);
        maxPosition = new Vector3(transform.position.x + movementPadding, transform.position.y + movementPadding, transform.position.z);
        minPosition = new Vector3(transform.position.x - movementPadding, transform.position.y - movementPadding, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
      //move(); //for some reason this on multiple objects causes a huge problem and I haven't been able to fix it yet
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
            }
        }
        float newPositionX = Mathf.SmoothDamp(transform.position.x, destPosition.x, ref xVelocity, smoothing);
        float newPositionY = Mathf.SmoothDamp(transform.position.y, destPosition.y, ref yVelocity, smoothing);
        gameObject.transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
        prevPosition = gameObject.transform.position;
    }

    public void toggleMenu() //to be used only by the top(parent) element of the collapsible menu
    {
        if (isMenuCollapsed)
        {
            maximizeMenu();
        } else
        {
            minimizeMenu();
        }
    }

    public void toggleSelectAll() //to be used only by SelectAll 
    {
        int check = 0;
        
        foreach (GameObject media in socialMedia){
            if (media.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial == toggleOff){
                media.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = toggleOn;
            } else{
                check++;
            }
        }
        if (check == socialMedia.Length) //meaning all are on, we will turn them off
        {
            foreach (GameObject media in socialMedia){
                media.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = toggleOff;
            }
        }
    }

    public void toggleSelf()
    {
        if(transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial == toggleOff)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = toggleOn;
        } else
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = toggleOff;
        }
    }

    public void minimizeMenu() //to be used only by Done
    {
        foreach(GameObject item in collapsableItems)
        {
            item.SetActive(false);
        }
        isMenuCollapsed = true;
    }

    public void maximizeMenu()
    {
        foreach(GameObject item in collapsableItems)
        {
            item.SetActive(true);
        }
        isMenuCollapsed = false;
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }
}
