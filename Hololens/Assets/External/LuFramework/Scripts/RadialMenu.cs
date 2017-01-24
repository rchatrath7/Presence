using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RadialMenu : MonoBehaviour {

    [Header("Objects")]
    public List<GameObject> buttons;

    [Header("Toggle Button Stuff")]
    public GameObject toggleButton;
    public GameObject toggleIcon;
    public Material matToggleActive;
    public Material matToggleInactive;

    private bool isOpen = false;
    
	void Start () {
        isOpen = false;
        GetButtons();
	}

    public void ToggleMenu()
    {
        Debug.Log("Toggling Menu");
        if(isOpen)
        {
            foreach(Transform t in toggleButton.transform)
            {
                if(t.gameObject.tag == "Button")
                {
                    t.gameObject.GetComponent<Animator>().SetTrigger("Removing");
                }
                toggleIcon.GetComponent<Renderer>().material = matToggleInactive;
                    
            }
            isOpen = false;
        } else
        {
            foreach (Transform t in toggleButton.transform)
            {
                if (t.gameObject.tag == "Button")
                {
                    t.gameObject.GetComponent<Animator>().SetTrigger("Spawning");
                    t.gameObject.SetActive(true);
                }
                toggleIcon.GetComponent<Renderer>().material = matToggleActive;
            }
            isOpen = true;
        }
    }   

    void GetButtons()
    {
        Debug.Log("Buttons built");
        buttons = new List<GameObject>();
        foreach(Transform child in toggleButton.transform)
        {
            if(child.gameObject.tag == "Button")
            {
                buttons.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
        }
    }
}
