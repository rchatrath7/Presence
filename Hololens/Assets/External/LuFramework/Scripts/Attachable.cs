using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachable : MonoBehaviour {

    private bool grabbing;
    private GameObject playerAttachingTo;

    private FixedJoint joint;
    private Rigidbody rb;

    public static int attachedObjectCount = 0;

    void Start()
    {
        grabbing = false;
    }

    public void Grab()
    {
        Debug.Log("Grabbing");
        grabbing = true;
    }

    public void Release()
    {
        Debug.Log("Releasing");
        grabbing = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!grabbing)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Object attached");
                Debug.Log("Total number of objects is " + attachedObjectCount);
                gameObject.transform.parent = other.gameObject.transform;
                attachedObjectCount++;
            }
        }
    }

    private void Update()
    {
        if(grabbing)
        {
            Debug.Log("Object detached");
            gameObject.transform.parent = null;
        }
    }


    // This will probably never happen
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Object detached");
            gameObject.transform.parent = null;
        }
    }
}
