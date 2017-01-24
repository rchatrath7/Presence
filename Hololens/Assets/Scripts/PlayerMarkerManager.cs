using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerManager : MonoBehaviour {

    public GameObject personalUI;
    private bool isActive;

    void Start()
    {
        isActive = false;
        personalUI.SetActive(isActive);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ToggleUI();
        }
    }

	public void ToggleUI() {
        isActive = !isActive;
        personalUI.SetActive(isActive);
    }

    public void DebugObject(string message)
    {
        Debug.Log(message);
    }
		
}
